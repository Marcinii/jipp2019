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
using System.Data;
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
        SqlConnection sql;
        string insert_query = "INSERT INTO stats " +
            "(timestamp, from_unit, to_unit, before, after) " +
            "VALUES (@timestamp, @from_unit, @to_unit, @before, @after) ";
        public MainWindow()
        {
            InitializeComponent();
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "(localdb)\\MSSQLLocalDB";
            builder.UserID = "testuser";
            builder.Password = "test123";
            builder.InitialCatalog = "Przelicznik";
            sql = new SqlConnection(builder.ConnectionString);
            sql.Open();
        }

        double from;
        double end;
        private void Button_Click_temp(object sender, RoutedEventArgs e)
        {
            from = double.Parse(Frombox.Text);
            //if (from_unit.SelectedIndex.Equals(0) && to_unit.SelectedIndex.Equals(1))
            //{
            //    double end = TemperatureConverter.CelsiusToFarenheit(from);
            //    ResultBox.Text = end.ToString();
            //}
            //else if (from_unit.SelectedIndex.Equals(1) && to_unit.SelectedIndex.Equals(0))
            //{
            //    double end = TemperatureConverter.FarenheitToCelcius(from);
            //    ResultBox.Text = end.ToString();
            //}
            //else if (from_unit.SelectedIndex.Equals(0) && to_unit.SelectedIndex.Equals(2))
            //{
            //    double end = TemperatureConverter.CelsiusToKelvin(from);
            //    ResultBox.Text = end.ToString();
            //}
            //else if (from_unit.SelectedIndex.Equals(1) && to_unit.SelectedIndex.Equals(2))
            //{
            //    double end = TemperatureConverter.FahrenheitToKelvin(from);
            //    ResultBox.Text = end.ToString();
            //}
            //else if (from_unit.SelectedIndex.Equals(2) && to_unit.SelectedIndex.Equals(0))
            //{
            //    double end = TemperatureConverter.KelvinToCelcius(from);
            //    ResultBox.Text = end.ToString();
            //}
            //else if (from_unit.SelectedIndex.Equals(2) && to_unit.SelectedIndex.Equals(1))
            //{
            //    double end = TemperatureConverter.KelvinToFarenheit(from);
            //    ResultBox.Text = end.ToString();
            //}
            int back = from_unit.SelectedIndex;
            int to = to_unit.SelectedIndex;
            SqlCommand cmd = new SqlCommand(insert_query, sql);
            switch (back)
                {
                    case 0 when to == 1:
                        end = TemperatureConverter.CelsiusToFarenheit(from);
                    cmd.Parameters.Add("@from_unit", SqlDbType.VarChar).Value = "Celsius";
                    cmd.Parameters.Add("@to_unit", SqlDbType.VarChar).Value = "Fahrenheit";
                        break;
                    case 0 when to == 2:
                        end = TemperatureConverter.CelsiusToKelvin(from);
                    cmd.Parameters.Add("@from_unit", SqlDbType.VarChar).Value = "Celsius";
                    cmd.Parameters.Add("@to_unit", SqlDbType.VarChar).Value = "Kelvin";
                        break;

                    case 1 when to == 0:
                        end = TemperatureConverter.FarenheitToCelcius(from);
                    cmd.Parameters.Add("@to_unit", SqlDbType.VarChar).Value = "Celsius";
                    cmd.Parameters.Add("@from_unit", SqlDbType.VarChar).Value = "Fahrenheit";

                    break;

                    case 1 when to == 2:
                        end = TemperatureConverter.FahrenheitToKelvin(from);
                    cmd.Parameters.Add("@from_unit", SqlDbType.VarChar).Value = "Fahrenheit";
                    cmd.Parameters.Add("@to_unit", SqlDbType.VarChar).Value = "Kelvin";

                    break;
                    case 2 when to == 0:
                        end = TemperatureConverter.KelvinToCelcius(from);
                    cmd.Parameters.Add("@from_unit", SqlDbType.VarChar).Value = "Kelvin";
                    cmd.Parameters.Add("@to_unit", SqlDbType.VarChar).Value = "Celsius";

                    break;
                    case 2 when to == 1:
                        end = TemperatureConverter.KelvinToFarenheit(from);
                    cmd.Parameters.Add("@from_unit", SqlDbType.VarChar).Value = "Kelvin";
                    cmd.Parameters.Add("@to_unit", SqlDbType.VarChar).Value = "Fahrenheit";
                    break;
                    default:
                        ResultBox.Text = from.ToString();
                        break;
                }
            ResultBox.IsEnabled = true;
            ResultBox.Clear();
            ResultBox.Text = end.ToString();
            cmd.Parameters.Add("@timestamp", SqlDbType.DateTime).Value = DateTime.Now;
            cmd.Parameters.Add("@before", SqlDbType.Real).Value = from;
            cmd.Parameters.Add("@after", SqlDbType.Real).Value = end;
            cmd.ExecuteNonQuery();
            }

        private void Fromboxlength_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            Fromboxlength.Clear();
        }

        private void Fromboxlength_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            Fromboxlength.Text = "Input";
        }

        private void MassButton_Click(object sender, RoutedEventArgs e)
        {
            double from = double.Parse(Fromboxmass.Text);
            int back = from_unit_mass.SelectedIndex;
            int to = to_unit_mass.SelectedIndex;
            switch (back)
            {
                case 1 when to == 1:
                    end = from;
                    break;
                case 1 when to == 2:
                    end = MassConverter.KgToLb(from);
                    break;
                case 1 when to == 3:
                    end = MassConverter.KgToCarat(from);
                    break;
                case 2 when to == 1:
                    end = MassConverter.LbToKg(from);
                    break;
                case 2 when to == 2:
                    end = from;
                    break;
                case 2 when to == 3:
                    end = MassConverter.LbToCarat(from);
                    break;
                case 3 when to == 1:
                    end = MassConverter.CaratToKg(from);
                    break;
                case 3 when to == 2:
                    end = MassConverter.CaratToLb(from);
                    break;
                case 3 when to == 3:
                    end = from;
                    break;
            }
            ResultBoxmass.IsEnabled = true;
            ResultBoxmass.Clear();
            ResultBoxmass.Text = end.ToString();
        }

        private void Button_Click_len(object sender, RoutedEventArgs e)
        {
            from = double.Parse(Fromboxlength.Text);
            int back = from_unit_len.SelectedIndex;
            int to = to_unit_len.SelectedIndex;
            switch (back)
            {
                case 1 when to == 1:
                    end = from;
                    break;
                case 1 when to == 2:
                    end = LenConverter.KmToMi(from);
                    break;
                case 1 when to == 3:
                    end = LenConverter.KmToNat(from);
                    break;
                case 2 when to == 1:
                    end = LenConverter.MiToKm(from);
                    break;
                case 2 when to == 2:
                    end = from;
                    break;
                case 2 when to == 3:
                    end = LenConverter.MiToNat(from);
                    break;
                case 3 when to == 1:
                    end = LenConverter.NatToKm(from);
                    break;
                case 3 when to == 2:
                    end = LenConverter.NatToMi(from);
                    break;
                case 3 when to == 3:
                    end = from;
                    break;
            }
            ResultBoxlength.IsEnabled = true;
            ResultBoxlength.Clear();
            ResultBoxlength.Text = end.ToString();
        }

        private void Fromboxmass_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            Fromboxmass.Clear();
        }

        private void Frombox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            Frombox.Clear();
        }

        private void Frombox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            Frombox.Text = "Input";
        }

        private void Fromboxmass_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            Frombox.Text = "Input";
        }

        private void SQLButton_Click(object sender, RoutedEventArgs e)
        {
            string CmdString = "SELECT * FROM stats";
            SqlCommand cmd = new SqlCommand(CmdString, sql);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Stats");
            sda.Fill(dt);
            SQLGrid.ItemsSource = dt.DefaultView;
            
        }
    }
}

