using Microsoft.Owin;
using Microsoft.Owin.Extensions;
using Owin;
using System.IO;
using System.Web;

[assembly: OwinStartup(typeof(OwinPipelineDemo.Entrance), "Ololo")]

namespace OwinPipelineDemo
{
    public class Entrance
    {
        public void Ololo(IAppBuilder app)
        {
            app.Use((context, next) =>
            {
                PrintCurrentIntegratedPipelineStage(context, "Middleware 1");
                return next.Invoke();
            });
            app.Use((context, next) =>
            {
                PrintCurrentIntegratedPipelineStage(context, "2nd MW");
                return next.Invoke();
            });
            app.UseStageMarker(PipelineStage.Authenticate);
            app.Run(context =>
            {
                PrintCurrentIntegratedPipelineStage(context, "3rd MW");
                return context.Response.WriteAsync("Hello world");
            });
            app.UseStageMarker(PipelineStage.ResolveCache);
        }
        private void PrintCurrentIntegratedPipelineStage(IOwinContext context, string msg)
        {
            var currentIntegratedpipelineStage = HttpContext.Current.CurrentNotification;
            context.Get<TextWriter>("host.TraceOutput")
                .WriteLine("Current IIS event: " + currentIntegratedpipelineStage + " Msg: " + msg);
        }
    }
}
