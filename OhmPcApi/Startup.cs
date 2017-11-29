using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using OhmPcApi.Services;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace OhmPcApi
{
    public class Startup
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder)
        {
            LogService.Log("Starting web API...");

            try
            {
                // Configure Web API for self-host. 
                HttpConfiguration config = new HttpConfiguration();
                config.MapHttpAttributeRoutes();
                config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
                config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new StringEnumConverter());
                config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                    new CamelCasePropertyNamesContractResolver();

                appBuilder.UseWebApi(config);
            }
            catch (Exception ex)
            {
                LogService.Log("Web API configuration error:");
                LogService.Log(ex);
            }
        }
    }
}
