using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public string USER_DATA = @"..\..\Xmls\user.xml";
        private finalproject.User.Users logIn = new finalproject.User.Users();
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

            XDocument oldUsers = XDocument.Load(USER_DATA);
            foreach (XElement element in oldUsers.Element("users").Elements("user"))
            {
                Users userObject = new Users( element.Element("firstName").Value, element.Element("lastName").Value, element.Element("phone").Value, element.Element("email").Value, element.Element("password").Value, element.Element("education").Value, element.Element("address1").Value, element.Element("address2").Value, element.Element("city").Value, element.Element("province").Value, element.Element("zipCode").Value, element.Element("jobType").Value);
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
            if (ValdateName(FirstName.Text))
            {
                FirstName.BorderBrush = Brushes.Red;
                FirstName.Focus();
            }
            else
            {
                FirstName.BorderBrush = Brushes.Black;
            }

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
        /***********
                    Users userObject = new Users(FirstName.Text, LastName.Text, PhoneNumber.Text, Email.Text, Password.Text, Education.Text, Address1.Text, Address2.Text, City.Text, Province.Text, ZipCode.Text, JobType.Text);
                    usersList.Add(userObject);
                    // override method
                    MessageBox.Show(userObject.ToString());
                    SaveUsers();
                    finalproject.UserLogin userLogin = new finalproject.UserLogin();
                    this.Hide();
                    userLogin.Show();

        /***********/

            //Users userObject = new Users(FirstName.Text, LastName.Text, PhoneNumber.Text, Email.Text, Password.Text, Education.Text, Address1.Text, Address2.Text, City.Text, Province.Text, ZipCode.Text, JobType.Text);
            //usersList.Add(userObject);

            //MessageBox.Show(userObject.ToString());

            //SaveUsers();

            Users userObject = null;
            bool conditionForSavingData = !string.IsNullOrEmpty(FirstName.Text) && !string.IsNullOrEmpty(PhoneNumber.Text)
                && !string.IsNullOrEmpty(Email.Text) && !string.IsNullOrEmpty(Password.Text) && !string.IsNullOrEmpty(Education.Text)
                && !string.IsNullOrEmpty(Address1.Text) && !string.IsNullOrEmpty(City.Text) && (!string.IsNullOrEmpty(Province.Text) || Province.Text == "Select Province")
                && !string.IsNullOrEmpty(ZipCode.Text) && (!string.IsNullOrEmpty(JobType.Text) || JobType.Text == "Select Job Type");
            if (string.IsNullOrEmpty(FirstName.Text))
            {
                lblFname.Foreground = Brushes.Red;
            }
            else
            {
                lblFname.Foreground = Brushes.Black;
            }
            if (string.IsNullOrEmpty(Email.Text))
            {
                lblEmail.Foreground = Brushes.Red;
            }
            else
            {
                lblEmail.Foreground = Brushes.Black;
            }
            if (string.IsNullOrEmpty(Password.Text))
            {
                lblPassword.Foreground = Brushes.Red;
            }
            else
            {
                lblPassword.Foreground = Brushes.Black;
            }
            if (string.IsNullOrEmpty(Education.Text))
            {
                lblEducation.Foreground = Brushes.Red;
            }
            else
            {
                lblEducation.Foreground = Brushes.Black;
            }
            if (string.IsNullOrEmpty(Address1.Text))
            {
                lblAdd1.Foreground = Brushes.Red;
            }
            else
            {
                lblAdd1.Foreground = Brushes.Black;
            }

            if (string.IsNullOrEmpty(PhoneNumber.Text))
            {
                lblContact.Foreground = Brushes.Red;
                conditionForSavingData = false;
            }
            else
            {
                UInt64 x = 0;
                UInt64.TryParse(PhoneNumber.Text, out x);

                if (x == 0)
                {
                    conditionForSavingData = false;
                    MessageBox.Show("Data type of Phone number is not correct.");
                    lblContact.Foreground = Brushes.Red;
                }
                else if (x < 1000000000 || x > 10000000000)
                {
                    lblContact.Foreground = Brushes.Red;
                    conditionForSavingData = false;
                    MessageBox.Show("Contact number must be of 10 digits.");
                }
                else
                {
                    lblContact.Foreground = Brushes.Black;
                }

            }
            if (string.IsNullOrEmpty(City.Text))
            {
                lblCity.Foreground = Brushes.Red;
            }
            else
            {
                lblCity.Foreground = Brushes.Black;
            }
            if (string.IsNullOrEmpty(Province.Text) || Province.Text == "Select Province")
            {
                lblProvince.Foreground = Brushes.Red;
            }
            else
            {
                lblProvince.Foreground = Brushes.Black;
            }
            if (string.IsNullOrEmpty(ZipCode.Text))
            {
                lblCode.Foreground = Brushes.Red;
            }
            else
            {
                lblCode.Foreground = Brushes.Black;
            }
            if (string.IsNullOrEmpty(JobType.Text) || JobType.Text == "Select Job Type")
            {
                lblJobType.Foreground = Brushes.Red;
            }
            else
            {
                lblJobType.Foreground = Brushes.Black;
            }
            if (conditionForSavingData)
            {
                userObject = new Users(FirstName.Text, LastName.Text, PhoneNumber.Text, Email.Text, Password.Text, Education.Text, Address1.Text, Address2.Text, City.Text, Province.Text, ZipCode.Text, JobType.Text);
                usersList.Add(userObject);

                MessageBox.Show(userObject.ToString());

                SaveUsers();
            }

        }
        private void SaveUsers()
        {

            int userId = 1;            
            /************/
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";
            XmlWriter xmlObject = XmlWriter.Create(USER_DATA, settings);
            xmlObject.WriteStartDocument();
            xmlObject.WriteStartElement("users");

            foreach (var user in usersList)
            {
                xmlObject.WriteStartElement("user");
                xmlObject.WriteElementString("firstName", user.FirstName);
                xmlObject.WriteElementString("lastName", user.LastName);
                xmlObject.WriteElementString("email", user.Email);
                xmlObject.WriteElementString("password", user.Password);
                xmlObject.WriteElementString("phone", user.PhoneNumber);
                xmlObject.WriteElementString("address1", user.Address1);
                xmlObject.WriteElementString("address2", user.Address2);
                xmlObject.WriteElementString("city", user.City);
                xmlObject.WriteElementString("province", user.Province);
                xmlObject.WriteElementString("zipCode", user.ZipCode);
                xmlObject.WriteElementString("education", user.Education);
                xmlObject.WriteElementString("jobType", user.JobType);
                xmlObject.WriteElementString("userId", userId.ToString());
                xmlObject.WriteElementString("accountType", "user");
                xmlObject.WriteEndElement();
                userId++;
            }
            xmlObject.WriteEndElement();
            xmlObject.Close();
            /************/
        }

        private bool ValdateName(string name)
        {
            Regex regex = new Regex("[^a-zA-Z]+");
            if (regex.IsMatch(name))
            {
                return true;
            }
            if (name == "")
            {
                return false;
            }
            return false;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            finalproject.UserLogin userLogin = new finalproject.UserLogin();
            this.Hide();
            userLogin.Show();
        }
    }
}
