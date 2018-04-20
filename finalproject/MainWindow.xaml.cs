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
using finalproject.Admin;

namespace finalproject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            finalproject.UserLogin userLogin = new finalproject.UserLogin();
            this.Hide();
            userLogin.Show();
        }

        private void btn_Admin_Click(object sender, RoutedEventArgs e)
        {
            Admin.Admin ad = new Admin.Admin();
            this.Hide();
            ad.Show();
        }

        private void btn_JobSeeker_Click(object sender, RoutedEventArgs e)
        {

            finalproject.User.Register reg = new finalproject.User.Register();
            this.Hide();
            reg.Show();
        }
    }
}
