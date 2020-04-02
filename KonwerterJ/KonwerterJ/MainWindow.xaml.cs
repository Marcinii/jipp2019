using KonwerterJ.Model;
using System;
using System.Collections.Generic;
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
using KonwerterJ.Services;

namespace KonwerterJ
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    /// jak ci bedzie wywalalo blad klucza w tabeli musisz zamienic  [Id] itd na  [Id]             INT           NOT NULL IDENTITY,
  
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private IStatisticsRepository repository;

        public MainWindow(IStatisticsRepository repo, ConverterService converters)
        {
            InitializeComponent();

            this.repository = repo;
            this.SiatkaStatystyk.ItemsSource = repository.GetStatistics();

            this.Miara.ItemsSource = converters.GetConverters(); //new ConvertersService().GetConverters()
        }

        private void Przelicz_Click(object sender, RoutedEventArgs e)
        {
            if (this.Miara.SelectedItem != null)
            {
                IConverter converter = (IConverter)this.Miara.SelectedItem;
                decimal result = converter.Convert(
                    this.Przedkonwersja.SelectedItem.ToString(),
                    this.PoKonwersja.SelectedItem.ToString(),
                   
                decimal.Parse(this.Liczba.Text));
                this.Wynik.Text = result.ToString();
                StatisticDTO st = new StatisticDTO()
                {
                    DateTime = DateTime.Now,
                    UnitFrom = this.Przedkonwersja.SelectedItem.ToString(),
                    Type = this.Miara.SelectedItem.ToString(),
                    UnitTo = this.PoKonwersja.SelectedItem.ToString(),
                    ConvertedValue = this.Liczba.Text,
                    RawValue = this.Wynik.Text
                   
                };
                
                this.repository.AddStatistic(st);
                this.SiatkaStatystyk.ItemsSource = repository.GetStatistics();
            }
        }


        private void Miara_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (this.Miara.SelectedItem != null)
            {
                this.Przedkonwersja.ItemsSource = ((IConverter)this.Miara.SelectedItem).Units;
                this.PoKonwersja.ItemsSource = ((IConverter)this.Miara.SelectedItem).Units;
            }
        }
    }
}

