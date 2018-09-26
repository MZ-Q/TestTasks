using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using Unity.Injection;

namespace TestMyCredit
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();
            container.RegisterType<Models.IGreeter, Models.HiGreating>();
            container.RegisterType<Controllers.HiController>(new InjectionConstructor(container.Resolve<Models.IGreeter>()));
            container.RegisterType<Models.IGreeter, Models.HelloGreating>();
            container.RegisterType<Controllers.HelloController>(new InjectionConstructor(container.Resolve<Models.IGreeter>()));
            config.DependencyResolver = new Resolver.UnityResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}");
        }
    }
}
