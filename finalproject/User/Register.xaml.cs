using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;

namespace finalproject.User
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        
        internal List<Users> usersList = new List<Users>();
        string USERS_FILE_PATH = @"..\..\Xmls\userTest.xml";
        public Register()
        {
            InitializeComponent();
            LoadConfig();
        }
        public void LoadConfig()
        {
            XDocument jobTypes = XDocument.Load(@"..\..\Xmls\jobTypes.xml");
            JobType.Items.Add("Select Job Type");
            foreach (XElement element in jobTypes.Descendants("jobType"))
            {
                JobType.Items.Add(" " + element.Value);
            }

            XDocument provinces = XDocument.Load(@"..\..\Xmls\provinces.xml");
            Province.Items.Add("Select Province");
            foreach (XElement element in provinces.Descendants("province"))
            {
                Province.Items.Add(" " + element.Value);
            }

            XDocument oldUsers = XDocument.Load(@"..\..\Xmls\user.xml");
            foreach (XElement element in oldUsers.Element("users").Elements("user"))
            {
                Users userObject = new Users(element.Element("userId").Value, element.Element("firstName").Value, element.Element("lastName").Value, element.Element("phone").Value, element.Element("email").Value, element.Element("password").Value, element.Element("address1").Value, element.Element("address2").Value, element.Element("city").Value, element.Element("province").Value, element.Element("zipCode").Value, element.Element("jobType").Value, element.Element("education").Value);
                usersList.Add(userObject);
            }

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void FirstName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void LastName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Email_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void PhoneNumber_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Password_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Education_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Address1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Address2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void City_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Province_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void State_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void JobType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void ZipCode_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Users userObject = new Users("4", FirstName.Text, LastName.Text, PhoneNumber.Text, Email.Text, Password.Text, Education.Text, Address1.Text, Address2.Text, City.Text, Province.Text, ZipCode.Text, JobType.Text);
            usersList.Add(userObject);
            SaveUsers();
        }
        private void SaveUsers()
        {

            /************
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";
            XmlWriter xmlObject = XmlWriter.Create(@"..\..\Xmls\userTest.xml", settings);
            xmlObject.WriteStartDocument();
            xmlObject.WriteStartElement("users");

            foreach (var user in usersList)
            {
                xmlObject.WriteStartElement("user");
                xmlObject.WriteElementString("VehicleType", user.FirstName);
                xmlObject.WriteEndElement();
            }
            xmlObject.WriteEndElement();
            xmlObject.Close();
            /************/
        }


    }
}
