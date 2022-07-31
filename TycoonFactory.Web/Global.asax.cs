using Autofac;
using Autofac.Configuration;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TycoonFactory.IBuss;
namespace TycoonFactory.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterModule(new ConfigurationSettingsReader());

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //var container = ConfigureContainer();
        }

        //private IContainer ConfigureContainer()
        //{
        //    var builder = new ContainerBuilder();
        //    builder.RegisterControllers(typeof(MvcApplication).Assembly);
        //    builder.RegisterModule(new ConfigurationSettingsReader());

        //    var container = builder.Build();
        //    DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            
        //    return container;
        //}
    }
}
