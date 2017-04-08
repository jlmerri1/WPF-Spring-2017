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

namespace bindingWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<ToDoItem> items = new List<ToDoItem>();
        public MainWindow()
        {
            InitializeComponent();
            items.Add(new ToDoItem() { Title = "Complete grading", Progress = 85 });
            items.Add(new ToDoItem() { Title = "Learn binding", Progress = 10 });
            items.Add(new ToDoItem() { Title = "Finsih class", Progress = 15 });

            ListToDo.ItemsSource = items;
        }
    }

    public class ToDoItem
    {
        public string Title { get; set; }
        public int Progress { get; set; }
    }
}
