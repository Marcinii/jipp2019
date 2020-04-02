


using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Validation;
using System.Diagnostics;
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
using Autofac;
using UnitsConverter.Model;
using UnitsConverter.Services;

namespace UnitsConverter
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private int value;
        private IStatisticsRepository repository;
      

        public MainWindow(IStatisticsRepository repo ,ConverterService converters)
        {

            InitializeComponent();
            this.repository = repo;
            this.statisticGrid.ItemsSource = repository.GetStatistics();
          this.UnitsComboBox.ItemsSource = converters.GetConverters();
        
        }

        private void UnitsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.UnitsComboBox.SelectedItem != null)
            {
                this.unitsToConvertComboBox.ItemsSource = ((IConverter)this.UnitsComboBox.SelectedItem).Units;
                this.unitsConvertedComboBox.ItemsSource = ((IConverter)this.UnitsComboBox.SelectedItem).Units;
            }
        }

        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.UnitsComboBox.SelectedItem != null)
            {
                IConverter converter = (IConverter)this.UnitsComboBox.SelectedItem;
                try
                {
                    decimal result = converter.Convert(
                        this.unitsToConvertComboBox.SelectedItem.ToString(),
                        this.unitsConvertedComboBox.SelectedItem.ToString(),
                        decimal.Parse(this.UnitsTextBox.Text));
                    this.OutputTextBlock.Text = result.ToString();
                }
                catch
                {

                    this.unitsToConvertComboBox.SelectedItem.ToString();
                    this.unitsConvertedComboBox.SelectedItem.ToString();
                    this.OutputTextBlock.Text = "Nie podano liczby";
                }
                StatisticDTO st = new StatisticDTO()
                {
                    DateTime = DateTime.Now,
                    FromUnit = this.unitsToConvertComboBox.SelectedItem.ToString(),
                    Type = this.UnitsComboBox.SelectedItem.ToString(),
                    FromTo = this.unitsConvertedComboBox.SelectedItem.ToString(),
                    ConvertedValue = this.OutputTextBlock.Text,
                    RawValue = this.UnitsTextBox.Text
                };
                this.repository.AddStatistic(st);
                this.statisticGrid.ItemsSource = repository.GetStatistics();

            }

        }
    }
}


