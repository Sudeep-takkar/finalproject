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

namespace finalproject.Admin
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        DataSet dataSet = new DataSet();
        public Admin()
        {
            InitializeComponent();
            GetUsersDetails();
        }

        public void GetUsersDetails()
        {
            try
            {
                //EnumerableRowCollection<DataRow> query;
                if (File.Exists(@"..\..\Xmls\appointments.xml"))
                {
                    dataSet.ReadXml(@"..\..\Xmls\appointments.xml");
                }
                else
                {
                    MessageBox.Show("File does not exist.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                if (row["userType"].ToString() == "Admin")
                {
                    if(row["email"].ToString() == txtEmail.Text && row["password"].ToString() == txtPass.Text)
                    {
                        Dashboard dash = new Dashboard();
                        this.Hide();
                        dash.Show();
                    }
                    else if(row["email"].ToString() == txtEmail.Text && row["password"].ToString() != txtPass.Text)
                    {
                        MessageBox.Show("Please check your details.");
                    }
                    else
                    {
                        MessageBox.Show("Sorry, We are unable to recognize you.");
                    }
                }
            }
        }
    }
}
