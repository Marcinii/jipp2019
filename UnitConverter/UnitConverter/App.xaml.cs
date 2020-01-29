﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Autofac;

namespace UnitConverter {
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application {
        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);

            IContainer container = BuildContainer();
            // IStatisticsRepository repository = container.Resolve<IStatisticsRepository>();
            MainWindow = container.Resolve<MainWindow>();
            MainWindow.Show();
        }
        private static IContainer BuildContainer() {
            var containerBuilder = new ContainerBuilder();

            // set statistics repository class using app config
            string statisticsRepositoryConfig = ConfigurationManager.AppSettings["StatisticsRepository"].ToLower();
            if (statisticsRepositoryConfig == "sql") {
                containerBuilder.RegisterType<StatisticsSqlRepository>().As<IStatisticsRepository>();
            } else if (statisticsRepositoryConfig == "azurestorage") {
                containerBuilder.RegisterType<StatisticsAzureStorageRepository>().As<IStatisticsRepository>();
            } else {
                throw new Exception("Błędna konfiguracja StatisticsRepository");
            }

            containerBuilder.RegisterType<MainWindow>();

            return containerBuilder.Build();
        }
    }
}
