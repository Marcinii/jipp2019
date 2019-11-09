﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KonwerterJedn
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IStatisticsRepository repository;

        public MainWindow(IStatisticsRepository repo)
        {
            InitializeComponent();

            this.repository = repo;
            this.StatsSQL.ItemsSource = repository.GetStatistics();
        }

        private void TempRB_Checked_1(object sender, RoutedEventArgs e)
        {
            TemperaturaFrom.ItemsSource = new List<string>(new[] { "Celciusz", "Kelvin", "Ferenheit", "Rankin" });
            TemperaturaTo.ItemsSource = new List<string>(new[] { "Celciusz", "Kelvin", "Ferenheit", "Rankin" });

        }

        private void OdlRB_Checked_1(object sender, RoutedEventArgs e)
        {
            OdlegloscFrom.ItemsSource = new List<string>(new[] { "mm", "cm", "dcm", "m", "km", "cal", "stopa", "jard", "mila", "kabel", "mila morska" });
            OdlegloscTo.ItemsSource = new List<string>(new[] { "mm", "cm", "dcm", "m", "km", "cal", "stopa", "jard", "mila", "kabel", "mila morska" });

        }

        private void MasaRB_Checked_1(object sender, RoutedEventArgs e)
        {

            MasaFrom.ItemsSource = new List<string>(new[] { "mg", "g", "dkg", "kg", "t", "uncja", "funt", "karat", "kwintal" });
            MasaTo.ItemsSource = new List<string>(new[] { "mg", "g", "dkg", "kg", "t", "uncja", "funt", "karat", "kwintal" });

        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
           
            double Wartosc;
            Wartosc = double.Parse(WartoscTemp.Text);

            Temp Temp1 = new Temp(TemperaturaFrom.Text, TemperaturaTo.Text, Wartosc);
            WynikTemp.Text = Temp1.PodajWynik();
            

                StatisticDTO St = new StatisticDTO()
                {
                    UnitFrom = TemperaturaFrom.Text,
                    UnitTo = TemperaturaTo.Text,
                    ValueFrom = this.WartoscTemp.Text,
                    ValueTo = this.WynikTemp.Text,
                    Type = Temp1.Type,
                    DateTime = DateTime.Now
                };
                this.repository.AddStatistic(St);
                this.StatsSQL.ItemsSource = repository.GetStatistics();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
          
            double Wartosc;
            Wartosc = double.Parse(WartoscOdl.Text);

            Odl Odl1 = new Odl(OdlegloscFrom.Text, OdlegloscTo.Text, Wartosc);
            WynikOdl.Text = Odl1.PodajWynik();

            StatisticDTO St = new StatisticDTO()
            {

                    UnitFrom = OdlegloscFrom.Text,
                    UnitTo = OdlegloscTo.Text,
                    ValueFrom = this.WartoscOdl.Text,
                    ValueTo = this.WynikOdl.Text,
                    Type = Odl1.Type,
                    DateTime = DateTime.Now

            };
            this.repository.AddStatistic(St);
            this.StatsSQL.ItemsSource = repository.GetStatistics();
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
          
            double Wartosc;
            Wartosc = double.Parse(WartoscMasa.Text);

            Mas Mas1 = new Mas(MasaFrom.Text, MasaTo.Text, Wartosc);
            WynikMasa.Text = Mas1.PodajWynik();
            StatisticDTO St = new StatisticDTO()
            {

                UnitFrom = MasaFrom.Text,
                    UnitTo = MasaTo.Text,
                    ValueFrom = this.WartoscMasa.Text,
                    ValueTo = this.WynikMasa.Text,
                    Type = Mas1.Type,
                    DateTime = DateTime.Now


            };
             
            this.repository.AddStatistic(St);
            this.StatsSQL.ItemsSource = repository.GetStatistics();
        }
    }
}


