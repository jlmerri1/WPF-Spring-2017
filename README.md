# WPF-Spring-2017

All files are from an Event Driven Programming class where we are learning WPF.

To use files: Please download the respective folder in order to open the program.  Each folder is a stand alone and does not require any other files to use.  Files may be used on Visual Studio 15.

Example: The code below is an example of the c# code-behind in a project where a user can "create books" with a user determined title, pre-determined list of options for genre, and user determined price.  The user may then "save list" to a XML file for a future search.  The rest of the code for this project is located in the Bookstore_merrill folder.


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

