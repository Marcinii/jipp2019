using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using zal.Logika;
using zal.Logika.Model;
using zal.Logika.Serwisy;

namespace zal
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IStatisticsRepository repository;



        public MainWindow(IStatisticsRepository repo, SerwisConwerterow converters)
        {

            InitializeComponent();

            this.repository = repo;
            this.BD.ItemsSource = repository.GetStatistics();
            this.Typ.ItemsSource = converters.GetConverters();
        }




        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.Typ.SelectedItem != null)
            {
                IConverter converter = (IConverter)this.Typ.SelectedItem;
                decimal result = converter.Convert(
                    this.przed_konwersja.SelectedItem.ToString(),
                    this.po_konwersji.SelectedItem.ToString(),
                    decimal.Parse(this.Dane_przed_konw.Text));

                this.Dane_po_konw.Text = result.ToString();
                StatisticDTO st = new StatisticDTO()
                {
                    DateTime = DateTime.Now,
                    FromUnit = this.przed_konwersja.SelectedItem.ToString(),
                    Type = this.Typ.SelectedItem.ToString(),
                    FromTo = this.po_konwersji.SelectedItem.ToString(),
                    ConvertedValue = this.Dane_po_konw.Text
                };
                this.repository.AddStatistic(st);
                this.BD.ItemsSource = repository.GetStatistics();

            }

        }

        private void Typ_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.Typ.SelectedItem != null)
            {
                this.przed_konwersja.ItemsSource = ((IConverter)this.Typ.SelectedItem).Units;
                this.po_konwersji.ItemsSource = ((IConverter)this.Typ.SelectedItem).Units;
            }
        }

    }
}
