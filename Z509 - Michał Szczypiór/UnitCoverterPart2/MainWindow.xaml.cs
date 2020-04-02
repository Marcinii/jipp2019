using System;
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
using UnitCoverterPart2.Services;

namespace UnitCoverterPart2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IStatisticsRepository repository;

        public MainWindow(IStatisticsRepository repo, ConvertersService converters)
        {
            InitializeComponent();

            this.repository = repo;
            this.statisticsDataGrid.ItemsSource = repository.GetStatistics();
            
            this.catergoriesCombobox.ItemsSource = converters.GetConverters(); //new ConvertersService().GetConverters()
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.catergoriesCombobox.SelectedItem != null)
            {
                IConverter converter = (IConverter)this.catergoriesCombobox.SelectedItem;
                decimal result = converter.Convert(
                    this.unitsFromCombobox.SelectedItem.ToString(), 
                    this.unitsToCombobox.SelectedItem.ToString(),
                    decimal.Parse(this.inputTextBox.Text));

                this.outputTextBlock.Text = result.ToString();

                StatisticDTO st = new StatisticDTO()
                {
                    DateTime = DateTime.Now,
                    Type = ((IConverter)this.catergoriesCombobox.SelectedItem).name,
                    UnitFrom = this.unitsFromCombobox.SelectedItem.ToString(),
                    UnitTo = this.unitsFromCombobox.SelectedItem.ToString(),
                    RawValue = decimal.Parse(this.inputTextBox.Text),
                    ConvertedValue = result
            };

                this.repository.AddStatistic(st);
                this.statisticsDataGrid.ItemsSource = repository.GetStatistics();
            }
        }

        private void catergoriesCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(this.catergoriesCombobox.SelectedItem != null)
            {
                this.unitsFromCombobox.ItemsSource = ((IConverter)this.catergoriesCombobox.SelectedItem).Jednostki;
                this.unitsToCombobox.ItemsSource = ((IConverter)this.catergoriesCombobox.SelectedItem).Jednostki;
            }
        }

        private void statisticsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
