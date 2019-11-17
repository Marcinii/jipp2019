﻿using System;
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
using Konwerter.Services;

namespace Konwerter
{
    public partial class MainWindow : Window
    {
        private IStatisticRepository repository;

        public MainWindow(IStatisticRepository repository, ConvertersService converters)
        {
            this.repository = repository;

            InitializeComponent();

            CategoryComboBox.ItemsSource = converters.GetConverters();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.CategoryComboBox.SelectedItem != null)
            {
                IConverting converter = (IConverting)this.CategoryComboBox.SelectedItem;
                string from = FromComboBox.SelectedItem.ToString();
                string to = ToComboBox.SelectedItem.ToString();
                float amount = float.Parse(FromTextBox.Text);
                float result = converter.Convert(from, to, amount);
                string resultString = "Wynik: " + result.ToString();
                ResultTextBlock.Text = resultString;
                ResultTextBlock.UpdateLayout();

                StatisticDTO statystyki = new StatisticDTO
                {
                    UnitFrom = from,
                    UnitTo = to,
                    DateTime = DateTime.Now,
                    Type = converter.Nazwa,
                    ValueFrom = amount,
                    ValueTo = result
                };
                repository.AddStatistic(statystyki);
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.CategoryComboBox.SelectedItem != null)
            {
                this.FromComboBox.ItemsSource = ((IConverting)this.CategoryComboBox.SelectedItem).ListaJednostek;
                this.ToComboBox.ItemsSource = ((IConverting)this.CategoryComboBox.SelectedItem).ListaJednostek;
            }
        }

        private void StatystykiButton_Click(object sender, RoutedEventArgs e)
        {
            StatisticsWindow statystyki = new StatisticsWindow(repository);
            statystyki.Show();
        }
    }
}
