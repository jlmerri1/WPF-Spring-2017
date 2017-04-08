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

namespace DataGridExample2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            dataGrid.ItemsSource = new Record[]
            {
                new Record {
                    FirstName ="Eric",
                    LastName ="Magpatay",
                    IsBillionaire =false,
                    Website =new Uri("http://ericmp.com"),
                    Gender =Gender.Male
                },

                new Record {
                    FirstName ="Jason",
                    LastName ="Merrill",
                    IsBillionaire =false,
                    Website =new Uri("http://howdyjason.com"),
                    Gender =Gender.Male
                }
            };
            dataGrid.IsReadOnly = true;
        }
    }
}
