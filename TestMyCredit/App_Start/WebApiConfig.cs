using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace TestMyCredit
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();

            // No need to recreate IGreeter types, because they are immutable in current implementation
            container.RegisterType<Models.IGreeter, Models.HiGreating>(new ContainerControlledLifetimeManager());

            // Use default(TransientLifetimeManager) lifetime mgr because of re-construction Conrollers on update
            container.RegisterType<Controllers.HiController>(new InjectionConstructor(container.Resolve<Models.IGreeter>()));

            // Same logic for the "Hello" controller
            container.RegisterType<Models.IGreeter, Models.HelloGreating>(new ContainerControlledLifetimeManager());
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
