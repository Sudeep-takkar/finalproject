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
using System.Xml.Linq;

namespace finalproject.User
{
    /// <summary>
    /// Interaction logic for BookAppointment.xaml
    /// </summary>
    public partial class BookAppointment : Window
    {
        private Users userObject = null;
        private string USER_SESSION = @"..\..\Xmls\userSession.xml";

        public BookAppointment()
        {
            InitializeComponent();
            XDocument timeSlots = XDocument.Load(@"..\..\Xmls\TimeSlots.xml");
            ChooseTimeSlot.Items.Add("Select Time");
            foreach (XElement element in timeSlots.Descendants("slot"))
            {
                ChooseTimeSlot.Items.Add(element.Value);
            }
        }
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            finalproject.User.UserDashbaord userDash = new finalproject.User.UserDashbaord();
            this.Hide();
            userDash.Show();
        }
        public void UserData()
        {
            try
            {
                XElement outPut = null;
                if (File.Exists(USER_SESSION))
                {
                    XElement doc = XElement.Load(USER_SESSION);
                    outPut = doc.Element("user");
                    finalproject.User.Users userObject = new finalproject.User.Users(outPut.Element("firstName").Value, outPut.Element("lastName").Value, outPut.Element("phone").Value, outPut.Element("email").Value, outPut.Element("password").Value, outPut.Element("education").Value, outPut.Element("address1").Value, outPut.Element("address2").Value, outPut.Element("city").Value, outPut.Element("province").Value, outPut.Element("zipCode").Value, outPut.Element("jobType").Value);
                    this.userObject =  userObject;
                }
                else
                {

                    throw new System.ArgumentException("Configuration error!", "original");
                }
            }
            catch (Exception ex)
            {
                throw new System.ArgumentException(ex.ToString(), "original");
            }

        }

        private void ConfirmAppoint_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(SelectDate.Text);
            MessageBox.Show(ChooseTimeSlot.Text);

        }

        private void ChooseTimeSlot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
