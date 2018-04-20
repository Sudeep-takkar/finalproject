using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        public DataSet ds2;
        public Dashboard(DataSet ds)
        {
            //EnumerableRowCollection<DataRow> query = from datatable in ds.Tables[0].AsEnumerable()
            //                                         orderby datatable.Field<string>("firstName")
            //                                         select datatable;
            //view = query.AsDataView();
            //grdInfo.ItemsSource = view;
            ds2 = ds;
            InitializeComponent();
            Loaded += MyWindow_Loaded;
            //cbDate.SelectedIndex = 0;
            cbJobType.SelectedIndex = 0;
            cbTime.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }

        private void MyWindow_Loaded(object sender, EventArgs e)
        {
            Default();
        }

        private void Default()
        {
            DataSet cloneSet = ds2.Copy();
            cloneSet.Tables["appointment"].Columns["jobType"].ColumnName = "Job Type";
            cloneSet.Tables["appointment"].Columns["Name"].ColumnName = "Name";
            cloneSet.Tables["appointment"].Columns["date"].ColumnName = "Date";
            cloneSet.Tables["appointment"].Columns["time"].ColumnName = "Time";
            cloneSet.Tables["appointment"].Columns["status"].ColumnName = "Status";
            cloneSet.Tables["appointment"].Columns["accountType"].ColumnName = "Account Type";
            EnumerableRowCollection<DataRow> query = from datatable in cloneSet.Tables[0].AsEnumerable()
                                                     orderby datatable.Field<string>("Name")
                                                     select datatable;
            DataView view = query.AsDataView();
            var table = view.ToTable(false, "Name", "Job Type", "Date", "Time", "Status", "Account Type");
            grdInfo.ItemsSource = table.AsDataView();
        }

        private void cbJobType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataSet cloneSet = ds2.Copy();
            cloneSet.Tables["appointment"].Columns["jobType"].ColumnName = "Job Type";
            cloneSet.Tables["appointment"].Columns["Name"].ColumnName = "Name";
            cloneSet.Tables["appointment"].Columns["date"].ColumnName = "Date";
            cloneSet.Tables["appointment"].Columns["time"].ColumnName = "Time";
            cloneSet.Tables["appointment"].Columns["status"].ColumnName = "Status";
            cloneSet.Tables["appointment"].Columns["accountType"].ColumnName = "Account Type";
            ComboBoxItem cb = (ComboBoxItem)cbJobType.SelectedItem;
            if (cb.Content.ToString().ToLower() != "all")
            {
                EnumerableRowCollection<DataRow> query = from datatable in cloneSet.Tables[0].AsEnumerable()
                                                         .Where(r => r.Field<string>("Job Type").ToLower() == cb.Content.ToString().ToLower())
                                                         orderby datatable.Field<string>("name")
                                                         select datatable;

                DataView view = query.AsDataView();
                var table = view.ToTable(false, "Name", "Job Type", "Date", "Time", "Status", "Account Type");
                grdInfo.ItemsSource = table.AsDataView();
            }
            else
            {
                Default();
            }
        }

        private void cbDate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cbTime_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataSet cloneSet = ds2.Copy();
            cloneSet.Tables["appointment"].Columns["jobType"].ColumnName = "Job Type";
            cloneSet.Tables["appointment"].Columns["Name"].ColumnName = "Name";
            cloneSet.Tables["appointment"].Columns["date"].ColumnName = "Date";
            cloneSet.Tables["appointment"].Columns["time"].ColumnName = "Time";
            cloneSet.Tables["appointment"].Columns["status"].ColumnName = "Status";
            cloneSet.Tables["appointment"].Columns["accountType"].ColumnName = "Account Type";
            ComboBoxItem cb = (ComboBoxItem)cbTime.SelectedItem;
            if (cb.Content.ToString().ToLower() != "all")
            {
                EnumerableRowCollection<DataRow> query = from datatable in cloneSet.Tables[0].AsEnumerable()
                                                         .Where(r => r.Field<string>("Time").ToLower() == cb.Content.ToString().ToLower())
                                                         orderby datatable.Field<string>("name")
                                                         select datatable;

                DataView view = query.AsDataView();
                var table = view.ToTable(false, "Name", "Job Type", "Date", "Time", "Status", "Account Type");
                grdInfo.ItemsSource = table.AsDataView();
            }
            else
            {
                Default();
            }
        }
    }
}
