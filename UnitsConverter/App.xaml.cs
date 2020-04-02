using Autofac;
using System;
using System.Collections.Generic;

using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using UnitsConverter.Model;
using UnitsConverter.Services;

namespace UnitsConverter
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IContainer container = BuildContainer();

            this.MainWindow = container.Resolve<MainWindow>();
            this.MainWindow.Show();
        }

        private static IContainer BuildContainer()
        {
            var containerBuilder = new ContainerBuilder();

            if (ConfigurationManager.AppSettings["StatisticsRepository"] == "AzureStorage")
            {
                containerBuilder.RegisterType<StatisticAzureRepository>().As<IStatisticsRepository>();
            }
            else
            {
                containerBuilder.RegisterType<StatisticsSqlRepository>().As<IStatisticsRepository>();

            }
            containerBuilder.RegisterType<MainWindow>();
            containerBuilder.RegisterType<ConverterService>();

          //  var assembly = Assembly.GetExecutingAssembly();
              var assembly = typeof(ConverterService).Assembly;

            containerBuilder.RegisterAssemblyTypes(assembly)
                 .Where(t => t.Name.EndsWith("Converter")).AsImplementedInterfaces();
                 

            RegisterPlugins(containerBuilder);
            return containerBuilder.Build();
        }
        private static void RegisterPlugins(ContainerBuilder containerBuilder)
        {
            string pluginFolder = "plugins";
            bool exsits = Directory.Exists(pluginFolder);

            if (!exsits)
                Directory.CreateDirectory(pluginFolder);
            string assemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string pluginDirectory = Path.Combine(assemblyDirectory, pluginFolder);

            var assemblies = Directory.GetFiles(pluginDirectory, "*Plugin.dll").Select(Assembly.LoadFrom).ToList();

            foreach (Assembly assembly in assemblies)
            {
                containerBuilder.RegisterAssemblyTypes(assembly).Where(t => t.Name.EndsWith("Converter")).AsImplementedInterfaces();
            }
        }
    }
}

