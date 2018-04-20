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
using System.Windows.Shapes;

namespace finalproject
{
    /// <summary>
    /// Interaction logic for UserLogin.xaml
    /// </summary>
    public partial class UserLogin : Window
    {
        private finalproject.User.Users logIn = new finalproject.User.Users();
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
                MessageBox.Show("Login Successfull" + logIn.FirstName.ToString());
                MessageBox.Show("user type is " + logIn.AccountType.ToString());
            }
            else
            {
                MessageBox.Show("Not valid logins");
            }
            
        }
    }
}
