using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TorneosITM.Servicios;

namespace TorneosITM
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de Web API

            // Rutas de Web API
            config.MessageHandlers.Add(new TokenValidationHandler());
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
