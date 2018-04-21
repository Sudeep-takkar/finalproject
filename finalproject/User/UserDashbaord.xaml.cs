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

namespace finalproject.User
{
    /// <summary>
    /// Interaction logic for UserDashbaord.xaml
    /// </summary>
    public partial class UserDashbaord : Window
    {
        //private string userId = null;
        private Users userDetails = null;
        private string userId = null;
        private finalproject.User.BookAppointment appointment = null;
        public UserDashbaord()
        {
            InitializeComponent();
        }
        public UserDashbaord( string userId )
        {
            this.userId = userId;
            InitializeComponent();
            //MessageBox.Show(userId);
            Users user = new Users();
            userDetails =  user.GetUserDetails(userId);
            //MessageBox.Show(userDetails.FirstName);
            UserName.Text = userDetails.FirstName;
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            finalproject.UserLogin userLogin = new finalproject.UserLogin();
            this.Hide();
            userLogin.Show();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void UserName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BookAppointment_Click(object sender, RoutedEventArgs e)
        {
            //appointment = new finalproject.User.BookAppointment(userId);
            appointment = new BookAppointment();
            this.Hide();
            appointment.Show();
        }
    }
}
