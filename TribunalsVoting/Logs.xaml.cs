using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace TribunalsVoting
{
    /// <summary>
    /// Interaction logic for Logs.xaml
    /// </summary>
    public partial class Logs : UserControl
    {
        //tanggalin mo nalang kung papalitan mo na ng value galing database
        public class DataObject
        {
            public int A { get; set; }
            public int B { get; set; }
            public String C { get; set; }
            public String D { get; set; }
        }
        public Logs()
        {
            InitializeComponent();
            //tanggalin mo nalang kung papalitan mo na ng value galing database
            var list = new ObservableCollection<DataObject>();

            list.Add(new DataObject() { A = 1, B = 1001, C = "Login", D = "2020-06-15 09:34:21" });
            list.Add(new DataObject() { A = 2, B = 1001, C = "Logout", D = "2020-06-15 09:34:21" });
            list.Add(new DataObject() { A = 3, B = 1001, C = "Add Account", D = "2020-06-15 09:34:21" });
            list.Add(new DataObject() { A = 4, B = 1001, C = "Delete Account", D = "2020-06-15 09:34:21" });
            list.Add(new DataObject() { A = 5, B = 1001, C = "Add Candidate", D = "2020-06-15 09:34:21" });
            list.Add(new DataObject() { A = 6, B = 1001, C = "Delete Candidate", D = "2020-06-15 09:34:21" });
            list.Add(new DataObject() { A = 7, B = 1001, C = "Update Candidate", D = "2020-06-15 09:34:21" });
            list.Add(new DataObject() { A = 8, B = 1001, C = "Reset Candidate", D = "2020-06-15 09:34:21" });
            list.Add(new DataObject() { A = 9, B = 1001, C = "Login", D = "2020-06-15 09:34:21" });
            list.Add(new DataObject() { A = 10, B = 1001, C = "Logout", D = "2020-06-15 09:34:21" });
            list.Add(new DataObject() { A = 11, B = 1001, C = "Login", D = "2020-06-15 09:34:21" });
            list.Add(new DataObject() { A = 12, B = 1001, C = "Logout", D = "2020-06-15 09:34:21" });
            list.Add(new DataObject() { A = 13, B = 1001, C = "Login", D = "2020-06-15 09:34:21" });
            list.Add(new DataObject() { A = 14, B = 1001, C = "Logout", D = "2020-06-15 09:34:21" });

         
            this.dataGrid1.ItemsSource = list;
        }

        private void DataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
