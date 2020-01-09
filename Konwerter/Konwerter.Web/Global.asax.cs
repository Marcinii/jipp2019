﻿using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Konwerter;
using Konwerter.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Konwerter.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            IContainer container = BuildContainer();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configure(WebApiConfig.Register);

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        private static IContainer BuildContainer()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterControllers(typeof(MvcApplication).Assembly); //tego brakowało
            containerBuilder.RegisterApiControllers(typeof(MvcApplication).Assembly); // API nie działało zanim to dodałem

            if (ConfigurationManager.AppSettings["StatisticsRepository"] == "AzureStorage")
            {
                containerBuilder.RegisterType<AzureStorageRepo>().As<IRepo>();
            }
            else
            {
                containerBuilder.RegisterType<SqlRepo>().As<IRepo>();
            }

            containerBuilder.RegisterType<ConvertersService>();
            //containerBuilder.RegisterType<MainWindow>();
            
            var assembly = typeof(ConvertersService).Assembly; //Assembly.GetExecutingAssembly();
            containerBuilder.RegisterAssemblyTypes(assembly).Where(t => t.Name.EndsWith("Konwerter")).AsImplementedInterfaces().AsSelf();
            //.Where(t => t.Name.EndsWith("Konwerter")).AsImplementedInterfaces();


            RegisterPlugins(containerBuilder);


            return containerBuilder.Build();
        }
        private static void RegisterPlugins(ContainerBuilder containerBuilder)
        {
            //string assemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string pluginDirectory = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "bin");// Path.Combine(assemblyDirectory, "plugins");

            var assemblies = Directory.GetFiles(pluginDirectory, "*Plugin.dll").Select(Assembly.LoadFrom).ToList();

            foreach (Assembly assembly in assemblies)
            {
                containerBuilder.RegisterAssemblyTypes(assembly).Where(t => t.Name.EndsWith("Konwerter")).AsImplementedInterfaces().AsSelf();
                //containerBuilder.RegisterAssemblyTypes(assembly).Where(t => t.Name.EndsWith("Konwerter")).AsImplementedInterfaces();
            }
        }
    }
}
