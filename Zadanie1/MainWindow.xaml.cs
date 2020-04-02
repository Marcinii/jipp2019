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
using Azure.Storage;
using System.Reflection;

namespace Zadanie1
{
    /// <summary>
    /// Interaction logic for Window1testxaml.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string converter;
        string[] currentunits;
        string[] plugins;
        private Dictionary<String, Assembly> pluginList = new Dictionary<String, Assembly>();
     SqlConnection sql;
        SqlDataAdapter sda;
        string insert_query = "INSERT INTO stats " +
            "(timestamp, from_unit, to_unit, before, after) " +
            "VALUES (@timestamp, @from_unit, @to_unit, @before, @after) ";
        private static string CmdString = "SELECT * FROM stats";
        DataTable dt = new DataTable("Stats");
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
            SqlCommand cmd = new SqlCommand(CmdString, sql);
            sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            string path = System.IO.Directory.GetCurrentDirectory() + "\\plugins";
            try
            {
                plugins = System.IO.Directory.GetFiles(path, "*.dll");
            }
            catch (Exception)
            {

               
            }

            if (plugins != null)
            {
                foreach (string plugin in plugins)
                {
                    var DLL = Assembly.LoadFile(plugin);
                    foreach (Type type in DLL.GetExportedTypes())
                    {
                        string cat = type.GetField("Category").GetValue(null).ToString();
                        catergoriesCombobox.Items.Add(cat);
                        pluginList.Add(cat, DLL);
                    }
                }
            }
            statisticsDataGrid.ItemsSource = dt.DefaultView;

        }
        private void catergoriesCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            from_unit.Items.Clear();
            to_unit.Items.Clear();
            string cat = catergoriesCombobox.SelectedItem.ToString().Trim().Split(':')[1].Trim();
            converter = cat + "Converter";
            converter.Trim(' ');
            if (! (cat == "Temperature" || cat == "Mass" || cat == "Length"))
            {
                Assembly plugin = pluginList[cat];
                Type myType = plugin.GetType(converter);
                string[] units = myType.GetField("Units").GetValue(null).ToString().Split(',');
                foreach (string un in units)
                {
                    from_unit.Items.Add(un);
                    from_unit.SelectedIndex = 0;
                    to_unit.Items.Add(un);
                    to_unit.SelectedIndex = 1;
                }
            }
            else
            {
                Assembly assem = typeof(MainWindow).Assembly;
                string path = "Converter." + converter;
                Type myType = assem.GetType(path);
                string[] units = myType.GetField("units").GetValue(null).ToString().Split(',');
                Console.WriteLine(units);
                foreach (string un in units)
                {
                    from_unit.Items.Add(un);
                    from_unit.SelectedIndex = 0;
                    to_unit.Items.Add(un);
                    to_unit.SelectedIndex = 1;
                }

            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double after;
            string cat = catergoriesCombobox.SelectedItem.ToString().Split(':')[1].Trim();
            converter = cat + "Converter";
            double from = double.Parse(Frombox.Text);
            string methodname = from_unit.Text + "To" + to_unit.Text.Trim();
            methodname.Trim(' ');
            if (!(cat == "Temperature" || cat == "Mass" || cat == "Length")) {
                Assembly plugin = pluginList[cat];
                Type myType = plugin.GetType(converter);
                object obj = Activator.CreateInstance(myType);
                MethodInfo meth = myType.GetMethod(methodname);
                after = (double)meth.Invoke(obj, new Object[] { from });
            }
            else
            {
                Assembly assem = typeof(MainWindow).Assembly;
                string path = "Converter." + converter;
                Type myType = assem.GetType(path);
                object obj = Activator.CreateInstance(myType);
                MethodInfo meth = myType.GetMethod(methodname);
                after = (double)meth.Invoke(obj, new Object[] { from });
            }
            ResultBox.IsEnabled = true;
            ResultBox.Text = after.ToString();
            SqlCommand cmd = new SqlCommand(insert_query, sql);
            cmd.Parameters.Add("@from_unit", SqlDbType.VarChar).Value = from_unit.Text.Trim();
            cmd.Parameters.Add("@to_unit", SqlDbType.VarChar).Value = to_unit.Text.Trim();
            cmd.Parameters.Add("@timestamp", SqlDbType.DateTime).Value = DateTime.Now;
            cmd.Parameters.Add("@before", SqlDbType.Real).Value = from;
            cmd.Parameters.Add("@after", SqlDbType.Real).Value = after;
            cmd.ExecuteNonQuery();
            SqlCommand sdaupdate = new SqlCommand(CmdString, sql);
            statisticsDataGrid.Items.Refresh();
            
        }

        private void Frombox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (Frombox.Text == "Input")
            {
                Frombox.Clear();
            }
        }
    }
}
