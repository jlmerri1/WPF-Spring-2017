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
using System.Xml.Linq;

namespace Bookstore_Merrill
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Book> Books = new List<Book>();
        string path = @"C:\Users\admin\Source\Repos\event\Bookstore_Merrill\Bookstore_Merrill\Data\BookData.xml";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Books.Add(new Book() { Title = titleBox.Text, Genre = genreBox.Text, Price = Convert.ToDouble(priceBox.Text) });
            listview.ItemsSource = Books;
            listview.Items.Refresh();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            CreateXMLDocument();
        }

        private void CreateXMLDocument()
        {
            XDocument xmlDocument = new XDocument(
            new XDeclaration("1.0", "utf-8", "yes"),
            new XComment("Creating an XML document for Book Store"),

            new XElement("Books",
                from book in Books
                select new XElement("Book", new XAttribute("Name", book.Title),
                    new XElement("Title", book.Title),
                    new XElement("Genre", book.Genre),
                    new XElement("Price", book.Price))
                    )
            );
            xmlDocument.Save(path);
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            QueryXML();
        }

        public void QueryXML()
        {
            IEnumerable<string> books = from Books in XDocument.Load(path)
                                        .Descendants("Book")
                                        where (double)Books.Element("Price") > Convert.ToDouble(searchBox.Text)
                                        select Books.Element("Title").Value;
            foreach (string title in books)
                listboxBox.Items.Add(title);
        }
    }
}
