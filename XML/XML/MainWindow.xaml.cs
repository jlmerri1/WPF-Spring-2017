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

namespace XML
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string path = @"C:\Users\admin\Source\Repos\event\XML\XML\Data\StudentData.xml";

        public MainWindow()
        {
            InitializeComponent();
            //CreateXMLDocument();
            //SaveArrayToXML();
            QueryXML();


        }
        public void QueryXML()
        {
            IEnumerable<string> names = from student in XDocument.Load(path)
                                        .Descendants("Student")
                                        where (int)student.Element("Grade") > 69
                                        orderby (int)student.Element("Grade") descending
                                        select student.Element("Name").Value;
            foreach (string name in names)
                lstStdnt.Items.Add(name);
        }
        public void SaveArrayToXML()
        {
            Student[] students = new Student[4];
            students[0] = new Student
            {
                Id = 101,
                Name = "Jack",
                Gender = "Male",
                Grade = 50
            };
            students[1] = new Student
            {
                Id = 102,
                Name = "Morris",
                Gender = "Male",
                Grade = 70
            };
            students[2] = new Student
            {
                Id = 103,
                Name = "Sam",
                Gender = "Female",
                Grade = 100
            };
            students[3] = new Student
            {
                Id = 104,
                Name = "Jen",
                Gender = "Female",
                Grade = 80
            };
            XDocument xmlDocument = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("Students",
                    from student in students
                    select new XElement("Student", new XAttribute("Id", student.Id),
                        new XElement("Name", student.Name),
                        new XElement("Gender", student.Gender),
                        new XElement("Grade", student.Grade)
                                        )
                            )
                );
            xmlDocument.Save(path);
        }

        public void CreateXMLDocument()
        {
            XDocument xmlDocument = new XDocument(
            new XDeclaration("1.0", "utf-8", "yes"),
            new XComment("Creating an XML document for student data"),

            new XElement("Students",

                new XElement("Student", new XAttribute("Id", 101),
                new XElement("Name", "Mark"),
                new XElement("Gender", "Male"),
                new XElement("Grade", 85)),

                new XElement("Student", new XAttribute("Id", 102),
                new XElement("Name", "Jane"),
                new XElement("Gender", "Female"),
                new XElement("Grade", 90)),

                new XElement("Student", new XAttribute("Id", 103),
                new XElement("Name", "John"),
                new XElement("Gender", "Male"),
                new XElement("Grade", 70)),

                new XElement("Student", new XAttribute("Id", 104),
                new XElement("Name", "Pam"),
                new XElement("Gender", "Female"),
                new XElement("Grade", 75))
                )
            );

            xmlDocument.Save(path);
        }
    }
}
