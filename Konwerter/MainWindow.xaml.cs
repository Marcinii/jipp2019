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
using Konwerter.Services;

namespace Konwerter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Statistics repository;

        public MainWindow(Statistics reposit, ConvertersService conv)
        {
            InitializeComponent();


            this.ComboOption.ItemsSource = new List<string>(new[]
       {
                "Temperatura", "Długość", "Masa" ,"Plugin"
            });

            this.repository = reposit;
            this.statisticsDataGrid.ItemsSource = repository.GetStatistics();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EntryInputValue.Text = "";
            ResultOutput.Text = "";
        }
        private void ComboOption_DropDownClosed(object sender, EventArgs e)
        {

            if (ComboOption.Text == "Plugin")
            {
                this.EntryValue.ItemsSource = new List<string>(new[]
                {
                "HP", "kW", "KM"
                });

                this.EndValue.ItemsSource = new List<string>(new[]
                {
                "HP", "kW", "KM"
                });
            }

            if (ComboOption.Text == "Temperatura")
            {
                this.EntryValue.ItemsSource = new List<string>(new[]
                {
                "Celsjusz", "Fahrenheit", "Kelvin", "Rankine"
                });

                            this.EndValue.ItemsSource = new List<string>(new[]
                            {
                "Celsjusz", "Fahrenheit", "Kelvin", "Rankine"
                });
                        }
                        if (ComboOption.Text == "Długość")
                        {
                            this.EntryValue.ItemsSource = new List<string>(new[]
                            {
                "mm", "cm", "dm", "m", "km", "inch", "feet", "yard", "mile"
                });

                            this.EndValue.ItemsSource = new List<string>(new[]
                            {
                "mm", "cm", "dm", "m", "km", "inch", "feet", "yard", "mile"
                });
                        }
                        if (ComboOption.Text == "Masa")
                        {
                            this.EntryValue.ItemsSource = new List<string>(new[]
                            {
                "mg", "g", "dkg", "kg", "T"
                });

                            this.EndValue.ItemsSource = new List<string>(new[]
                            {
                "mg", "g", "dkg", "kg", "T"
                });
                        }
        }
            private void Convert(object sender, RoutedEventArgs e)
        {
            if (ComboOption.Text == "Plugin")
            {
                if (EntryValue.Text == "HP")
                {
                    double value = double.Parse(EntryInputValue.Text);
                    if (EndValue.Text == "KM") ResultOutput.Text = ((value * 1.01)).ToString();
                    if (EndValue.Text == "kW") ResultOutput.Text = (value * 0.75).ToString();
                }

                if (EntryValue.Text == "kW")
                {
                    double value = double.Parse(EntryInputValue.Text);
                    if (EndValue.Text == "HP") ResultOutput.Text = ((value * 1.34)).ToString();
                    if (EndValue.Text == "KM") ResultOutput.Text = (value * 1.36).ToString();
                }

                if (EntryValue.Text == "KM")
                {
                    double value = double.Parse(EntryInputValue.Text);
                    if (EndValue.Text == "HP") ResultOutput.Text = ((value * 0.99)).ToString();
                    if (EndValue.Text == "kW") ResultOutput.Text = (value * 0.74).ToString();
                }
            }

            if (ComboOption.Text == "Temperatura")
            {
                if (EntryValue.Text == "Celsjusz")
                {
                    double value = double.Parse(EntryInputValue.Text);
                    if (EndValue.Text == "Fahrenheit") ResultOutput.Text = ((9 * value / 5 + 32)).ToString();
                    if (EndValue.Text == "Kelvin") ResultOutput.Text = (value - 273.15).ToString();
                    if (EndValue.Text == "Rankine") ResultOutput.Text = (9 * (value + 273.15) / 5).ToString();
                }
                if (EntryValue.Text == "Fahrenheit")
                {
                    double value = double.Parse(EntryInputValue.Text);
                    if (EndValue.Text == "Celsjusz") ResultOutput.Text = (5 * (value - 32) / 9).ToString();
                    if (EndValue.Text == "Kelvin") ResultOutput.Text = (5 * (value + 459.67) / 9).ToString();
                    if (EndValue.Text == "Rankine") ResultOutput.Text = (value + 459.67).ToString();
                }
                if (EntryValue.Text == "Kelvin")
                {
                    double value = double.Parse(EntryInputValue.Text);
                    if (EndValue.Text == "Celsjusz") ResultOutput.Text = (value - 273.15).ToString();
                    if (EndValue.Text == "Fahrenheit") ResultOutput.Text = (9 * value / 5 - 459.67).ToString();
                    if (EndValue.Text == "Rankine") ResultOutput.Text = (value * 9 / 5).ToString();
                }
                if (EntryValue.Text == "Rankine")
                {
                    double value = double.Parse(EntryInputValue.Text);
                    if (EndValue.Text == "Celsjusz") ResultOutput.Text = ((value - 491.67) * 5 / 9).ToString();
                    if (EndValue.Text == "Fahrenheit") ResultOutput.Text = (value - 459.67).ToString();
                    if (EndValue.Text == "Kelvin") ResultOutput.Text = (value * 5 / 9).ToString();
                }
            }

            if (ComboOption.Text == "Długość")
            {
                if (EntryValue.Text == "mm")
                {
                    double value = double.Parse(EntryInputValue.Text);
                    if (EndValue.Text == "cm") ResultOutput.Text = (value * 0.1).ToString();
                    else if (EndValue.Text == "dm") ResultOutput.Text = (value * 0.01).ToString();
                    else if (EndValue.Text == "m") ResultOutput.Text = (value * 0.001).ToString();
                    else if (EndValue.Text == "km") ResultOutput.Text = (value * 0.0001).ToString();
                }
                if (EntryValue.Text == "cm")
                {
                    double value = double.Parse(EntryInputValue.Text);
                    if (EndValue.Text == "mm") ResultOutput.Text = (value * 10).ToString();
                    else if (EndValue.Text == "dm") ResultOutput.Text = (value * 0.1).ToString();
                    else if (EndValue.Text == "m") ResultOutput.Text = (value * 0.01).ToString();
                    else if (EndValue.Text == "km") ResultOutput.Text = (value * 0.001).ToString();
                }
                if (EntryValue.Text == "dm")
                {
                    double value = double.Parse(EntryInputValue.Text);
                    if (EndValue.Text == "mm") ResultOutput.Text = (value * 100).ToString();
                    else if (EndValue.Text == "cm") ResultOutput.Text = (value * 10).ToString();
                    else if (EndValue.Text == "m") ResultOutput.Text = (value * 0.1).ToString();
                    else if (EndValue.Text == "km") ResultOutput.Text = (value * 0.01).ToString();
                }
                if (EntryValue.Text == "m")
                {
                    double value = double.Parse(EntryInputValue.Text);
                    if (EndValue.Text == "mm") ResultOutput.Text = (value * 1000).ToString();
                    if (EndValue.Text == "cm") ResultOutput.Text = (value * 100).ToString();
                    if (EndValue.Text == "dm") ResultOutput.Text = (value * 10).ToString();
                    if (EndValue.Text == "km") ResultOutput.Text = (value * 0.001).ToString();
                }
                if (EntryValue.Text == "km")
                {
                    double value = double.Parse(EntryInputValue.Text);
                    if (EndValue.Text == "mm") ResultOutput.Text = (value * 1000000).ToString();
                    if (EndValue.Text == "cm") ResultOutput.Text = (value * 100000).ToString();
                    if (EndValue.Text == "dm") ResultOutput.Text = (value * 10000).ToString();
                    if (EndValue.Text == "m") ResultOutput.Text = (value * 1000).ToString();
                }
            }

            if (ComboOption.Text == "Masa")
            {
                if (EntryValue.Text == "mg")
                {
                    double value = double.Parse(EntryInputValue.Text);
                    if (EndValue.Text == "g") ResultOutput.Text = (value * 0.001).ToString();
                    else if (EndValue.Text == "dkg") ResultOutput.Text = (value * 0.0001).ToString();
                    else if (EndValue.Text == "kg") ResultOutput.Text = (value * 0.000001).ToString();
                    else if (EndValue.Text == "T") ResultOutput.Text = (value * 0.000000001).ToString();
                }
                if (EntryValue.Text == "g")
                {
                    double value = double.Parse(EntryInputValue.Text);
                    if (EndValue.Text == "mg") ResultOutput.Text = (value * 1000).ToString();
                    else if (EndValue.Text == "dkg") ResultOutput.Text = (value * 0.1).ToString();
                    else if (EndValue.Text == "kg") ResultOutput.Text = (value * 0.001).ToString();
                    else if (EndValue.Text == "T") ResultOutput.Text = (value * 0.000001).ToString();
                }
                if (EntryValue.Text == "dkg")
                {
                    double value = double.Parse(EntryInputValue.Text);
                    if (EndValue.Text == "mg") ResultOutput.Text = (value * 10000).ToString();
                    else if (EndValue.Text == "g") ResultOutput.Text = (value * 10).ToString();
                    else if (EndValue.Text == "kg") ResultOutput.Text = (value * 0.01).ToString();
                    else if (EndValue.Text == "T") ResultOutput.Text = (value * 0.00001).ToString();
                }
                if (EntryValue.Text == "kg")
                {
                    double value = double.Parse(EntryInputValue.Text);
                    if (EndValue.Text == "mg") ResultOutput.Text = (value * 1000).ToString();
                    else if (EndValue.Text == "g") ResultOutput.Text = (value * 1000).ToString();
                    else if (EndValue.Text == "dkg") ResultOutput.Text = (value * 100).ToString();
                    else if (EndValue.Text == "T") ResultOutput.Text = (value * 0.001).ToString();
                }
                if (EntryValue.Text == "T")
                {
                    double value = double.Parse(EntryInputValue.Text);
                    if (EndValue.Text == "mg") ResultOutput.Text = (value * 1000000000).ToString();
                    if (EndValue.Text == "g") ResultOutput.Text = (value * 1000000).ToString();
                    if (EndValue.Text == "dkg") ResultOutput.Text = (value * 100000).ToString();
                    if (EndValue.Text == "kg") ResultOutput.Text = (value * 1000).ToString();
                }
            }



            DataGrid statistic = new DataGrid()
            {
                Date = DateTime.Now,
                Log = "Konwersja z: " + EntryValue.SelectedValue + " "
                   + "na: " + EndValue.SelectedValue + " "
                   + "o wartości: " + EntryInputValue.Text + " " +EntryValue.SelectedValue + " "
                   + "wynik konwersji: " + ResultOutput.Text +" "+ EndValue.SelectedValue,

            };

            this.repository.AddStatistic(statistic);
            this.statisticsDataGrid.ItemsSource = repository.GetStatistics();
        }

    }

}




