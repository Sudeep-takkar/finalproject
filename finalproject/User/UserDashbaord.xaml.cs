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
using System.Xml.Linq;

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
        private string APPOINTMENTS = @"..\..\Xmls\appointments.xml";
        private List<Appointments> appointmentList = new List<Appointments>();

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
        public void LoadData()
        {
            XDocument loadAppo = XDocument.Load(APPOINTMENTS);
            foreach (XElement app in loadAppo.Element("appointments").Elements("appointment"))
            {
                Appointments appointment = new Appointments(
                     app.Element("name").Value,
                     app.Element("email").Value,
                     app.Element("jobType").Value,
                     app.Element("date").Value,
                     app.Element("time").Value,
                     app.Element("status").Value,
                     app.Element("userId").Value
                 );
                appointmentList.Add(appointment);
                DataGridDetail.Items.Add(appointment);
            }
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

        private void DataGridDetail_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
