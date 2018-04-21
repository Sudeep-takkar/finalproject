using System;
using System.Collections.Generic;
using System.Data;
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
using finalproject.User;

namespace finalproject
{
    /// <summary>
    /// Interaction logic for UserLogin.xaml
    /// </summary>
    public partial class UserLogin : Window
    {
        private finalproject.User.Users logIn = new finalproject.User.Users();
        private DataSet dataSet = new DataSet();
        //private finalproject.User.Users userObject = null;  
        private string USER_SESSION = @"..\..\Xmls\userSession.xml";

        public UserLogin()
        {
            InitializeComponent();
        }
        private void LoginEmail_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void LoginPassword_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void LoginUser_Click(object sender, RoutedEventArgs e)
        {
            Authonticate authonticate = new Authonticate();
           logIn =  authonticate.AuthonticateUser(LoginEmail.Text, LoginPassword.Text);
            if (logIn.FirstName.ToString() != "" )
            {
                if (logIn.AccountType.ToString() == "admin")
                {
                    finalproject.Admin.Dashboard dash = new finalproject.Admin.Dashboard(GetUsersDetails());
                    this.Hide();
                    dash.ShowDialog();
                }
                else
                {
                    finalproject.User.UserDashbaord userDash = new finalproject.User.UserDashbaord(logIn.UserId.ToString());
                    this.Hide();
                    userDash.Show();
                }
            }
            else
            {
                MessageBox.Show("Not valid logins");
            }
            
        }

        public DataSet GetUsersDetails()
        {
            
            XElement xml = XElement.Load(@"..\..\Xmls\appointments.xml");
            using (var reader = xml.CreateReader())
                dataSet.ReadXml(reader);

            return dataSet;
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            finalproject.User.Register userRegister = new finalproject.User.Register();
            this.Hide();
            userRegister.Show();
        }
        private void SaveUserSession(finalproject.User.Users user)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";
            XmlWriter xmlObject = XmlWriter.Create(USER_SESSION, settings);
            xmlObject.WriteStartDocument();

            xmlObject.WriteStartElement("session");

                xmlObject.WriteStartElement("user");
                xmlObject.WriteElementString("firstName", user.FirstName);
                xmlObject.WriteElementString("lastName", user.LastName);
                xmlObject.WriteElementString("email", user.Email);
                xmlObject.WriteElementString("phone", user.PhoneNumber);
                xmlObject.WriteElementString("address1", user.Address1);
                xmlObject.WriteElementString("address2", user.Address2);
                xmlObject.WriteElementString("city", user.City);
                xmlObject.WriteElementString("province", user.Province);
                xmlObject.WriteElementString("zipCode", user.ZipCode);
                xmlObject.WriteElementString("education", user.Education);
                xmlObject.WriteElementString("jobType", user.JobType);
                xmlObject.WriteElementString("userId", user.UserId);
                xmlObject.WriteEndElement();
            xmlObject.WriteEndElement();
            xmlObject.Close();   
        }

    }
}
