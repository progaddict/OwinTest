using Owin;

namespace HelloWorldSelfHosted
{
    public class HelloWorld
    {
        public void Configuration(IAppBuilder app)
        {
            app.Run(context =>
            {
                context.Response.ContentType = "text/plain";
                return context.Response.WriteAsync(string.Format("Hello World! My name is {0}.", this.GetType().FullName));
            });
        }
    }
}