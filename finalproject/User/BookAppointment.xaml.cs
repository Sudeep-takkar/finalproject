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
    /// Interaction logic for BookAppointment.xaml
    /// </summary>
    public partial class BookAppointment : Window
    {
        private Users userObject = null;
        private string USER_SESSION = @"..\..\Xmls\userSession.xml";
        private string APPOINTMENTS = @"..\..\Xmls\appointments.xml";
        private List<Appointments> appointmentList = new List<Appointments>();

        public BookAppointment()
        {
            InitializeComponent();
            
            LoadData();
        }
        public void LoadData()
        {
            XDocument loadAppo = XDocument.Load(APPOINTMENTS);
            foreach (XElement app in loadAppo.Element("appointments").Elements("appointment"))
            {

                //MessageBox.Show(app.Element("name").Value);

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
            }

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
        private Users UserData()
        {
            try
            {
                XElement outPut = null;
                if (File.Exists(USER_SESSION))
                {
                    XElement doc = XElement.Load(USER_SESSION);
                    outPut = doc.Element("user");
                    finalproject.User.Users userObject = new finalproject.User.Users(outPut.Element("firstName").Value, outPut.Element("lastName").Value, outPut.Element("phone").Value, outPut.Element("email").Value, outPut.Element("password").Value, outPut.Element("education").Value, outPut.Element("address1").Value, outPut.Element("address2").Value, outPut.Element("city").Value, outPut.Element("province").Value, outPut.Element("zipCode").Value, outPut.Element("jobType").Value);
                    //this.userObject =  userObject;
                    MessageBox.Show(userObject.FirstName);
                    return userObject;
                }
                else
                {
                    MessageBox.Show("File does not exuxts");
                    return userObject;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return userObject;
            }

        }

        private void ConfirmAppoint_Click(object sender, RoutedEventArgs e)
        {
            
            XElement outPut = null;
            XElement doc = XElement.Load(USER_SESSION);
            outPut = doc.Element("user");

            Appointments appointment = new Appointments(
                     outPut.Element("firstName").Value +" "+ outPut.Element("lastName").Value,
                     outPut.Element("email").Value,
                     outPut.Element("jobType").Value,
                     SelectDate.Text,
                     ChooseTimeSlot.Text,
                    "InProgress",
                     outPut.Element("userId").Value
                 );
            appointmentList.Add(appointment);

            SaveAppointments();
            finalproject.User.UserDashbaord userDash = new finalproject.User.UserDashbaord();
            this.Hide();
            userDash.Show();
        }

        private void ChooseTimeSlot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
         private void SaveAppointments()
        {

            int userId = 1;            
            /************/
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";
            XmlWriter xmlObject = XmlWriter.Create(APPOINTMENTS, settings);
            xmlObject.WriteStartDocument();
            xmlObject.WriteStartElement("appointments");

            foreach (var app in appointmentList)
            {
                xmlObject.WriteStartElement("appointment");
                xmlObject.WriteElementString("id", userId.ToString());
                xmlObject.WriteElementString("name", app.Name);
                xmlObject.WriteElementString("email", app.Email);
                xmlObject.WriteElementString("jobType", app.JobType);
                xmlObject.WriteElementString("date", app.Date);
                xmlObject.WriteElementString("time", app.Time);
                xmlObject.WriteElementString("status", app.Status);
                xmlObject.WriteElementString("userId", app.UserId);
                xmlObject.WriteEndElement();
                userId++;
            }
            xmlObject.WriteEndElement();
            xmlObject.Close();
            /************/
        }
    }
}
