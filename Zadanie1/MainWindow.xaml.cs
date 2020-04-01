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
using System.Diagnostics;
using System.Windows.Controls.Primitives;
using System.Data.SqlClient;



/*
DB Event logging. Events must include:
- Timestamp
- Type(info, warning, error, debug, critical)
- Calculation details(value(int), start(list), end(list), converted(list))

Event:
- PK
- Timestamp
- FK_Type
- FK_Calculation

Type:
- PK_Type
- Level

Calulation:
- PK_Calculation
- Value
- Start_Unit
- End_Unit
- Conversion_Result

Type 1 -> 1 Type 
 1 | 1
Calculation 

Retrieve from SQL data? - can expand on that? sqlcmd raw queries or in the UI?
I think retrieve the saved data and display in app, probs gonna have to make a box to display it in.
Once we get what's going on here we should have no problem implementing the UI for the SQL data.

Yeah nah not worried about the logs just precision. My OCD.
*/

namespace Zadanie1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder;
            builder.DataSource = '(local)\MSSQLLocalDB';
            builder.UserID = "testuser";
            builder.Password = "test123";
            builder.InitialCatalog = "Przelicznik";
        }

        float from;
        float end;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            from = float.Parse(Frombox.Text);
            //if (from_unit.SelectedIndex.Equals(0) && to_unit.SelectedIndex.Equals(1))
            //{
            //    float end = TemperatureConverter.CelsiusToFarenheit(from);
            //    ResultBox.Text = end.ToString();
            //}
            //else if (from_unit.SelectedIndex.Equals(1) && to_unit.SelectedIndex.Equals(0))
            //{
            //    float end = TemperatureConverter.FarenheitToCelcius(from);
            //    ResultBox.Text = end.ToString();
            //}
            //else if (from_unit.SelectedIndex.Equals(0) && to_unit.SelectedIndex.Equals(2))
            //{
            //    float end = TemperatureConverter.CelsiusToKelvin(from);
            //    ResultBox.Text = end.ToString();
            //}
            //else if (from_unit.SelectedIndex.Equals(1) && to_unit.SelectedIndex.Equals(2))
            //{
            //    float end = TemperatureConverter.FahrenheitToKelvin(from);
            //    ResultBox.Text = end.ToString();
            //}
            //else if (from_unit.SelectedIndex.Equals(2) && to_unit.SelectedIndex.Equals(0))
            //{
            //    float end = TemperatureConverter.KelvinToCelcius(from);
            //    ResultBox.Text = end.ToString();
            //}
            //else if (from_unit.SelectedIndex.Equals(2) && to_unit.SelectedIndex.Equals(1))
            //{
            //    float end = TemperatureConverter.KelvinToFarenheit(from);
            //    ResultBox.Text = end.ToString();
            //}
            int back = from_unit.SelectedIndex;
            int to = to_unit.SelectedIndex;
            switch(back)
            {
                case 0 when to == 1:
                    end = TemperatureConverter.CelsiusToFarenheit(from);
                    break;
                case 0 when to == 2:
                    end = TemperatureConverter.CelsiusToKelvin(from);
                    break;

                case 1 when to == 0:
                    end = TemperatureConverter.FarenheitToCelcius(from);
                    break;

                case 1 when to == 2:
                    end = TemperatureConverter.FahrenheitToKelvin(from);
                    break;
                case 2 when to == 0:
                    end = TemperatureConverter.KelvinToCelcius(from);
                    break;
                case 2 when to == 1:
                    end = TemperatureConverter.KelvinToFarenheit(from);
                    break;
                default:
                    ResultBox.Text = from.ToString();
                    break;
            }
            ResultBox.Text = end.ToString();

        }

        private void from_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Frombox_DragOver(object sender, DragEventArgs e)
        {

        }

        private void Fromboxlength_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            Fromboxlength.Text = "";
        }

        private void Fromboxlength_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            Fromboxlength.Text = "Input";
        }

    }
}
