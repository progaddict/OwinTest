﻿using Owin;
using System.Web.Http;

namespace WebApiSelfHosted
{
    public class EntryPoint
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            app.UseWebApi(config); 
        }
    }
}
