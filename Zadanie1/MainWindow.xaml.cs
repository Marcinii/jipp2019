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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            float f = 
        }
    }
}
