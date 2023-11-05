using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using Newtonsoft.Json;

namespace RegistroUniversitario
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {


            HttpConfiguration configuration = GlobalConfiguration.Configuration;

            var jsonFormatter = configuration.Formatters.JsonFormatter;
            jsonFormatter.SerializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                TypeNameHandling = TypeNameHandling.Objects,
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            };

            configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
            RegisterRoutes(RouteTable.Routes);
            GlobalConfiguration.Configure(WebApiConfig.Register);

           
        }

        void RegisterRoutes(RouteCollection routes)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            var context = HttpContext.Current;
            var response = context.Response;

            // enable CORS
            response.AddHeader("X-Frame-Options", "ALLOW-FROM *");

            if (context.Request.HttpMethod == "OPTIONS")
            {
                response.End();
            }
        }
    }
}