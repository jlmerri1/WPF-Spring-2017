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

namespace buttons
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //btn.ClickMode = ClickMode.Press;
            btn.ClickMode = ClickMode.Hover;
            tggleBtn.IsThreeState = true;
            chckBox1.IsThreeState = true;
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Button thisButton = (Button)sender;
            //or btn....

            txt1.Text = thisButton.IsPressed.ToString();
        }

        private void rBtn_Click(object sender, RoutedEventArgs e)
        {
            pBar.Value += 1;
        }

        private void tggleBtn_Click(object sender, RoutedEventArgs e)
        {

            if (chckBox1.IsChecked == true)
                pBar2.Value = 100;
            else if (chckBox1.IsChecked == false)
                pBar2.Value = 0;
            else
                pBar2.Value = 50;

        }

        
    }
}
