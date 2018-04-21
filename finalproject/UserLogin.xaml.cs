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
using System.Xml.Linq;

namespace finalproject
{
    /// <summary>
    /// Interaction logic for UserLogin.xaml
    /// </summary>
    public partial class UserLogin : Window
    {
        private finalproject.User.Users logIn = new finalproject.User.Users();
        private DataSet dataSet = new DataSet();
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
                MessageBox.Show("Welcome " + logIn.FirstName.ToString());

                if (logIn.AccountType.ToString() == "admin")
                {
                    finalproject.Admin.Dashboard dash = new finalproject.Admin.Dashboard(GetUsersDetails());
                    this.Hide();
                    dash.ShowDialog();
                }
                else
                {
                    finalproject.User.UserDashbaord userDash = new finalproject.User.UserDashbaord();
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
    }
}
