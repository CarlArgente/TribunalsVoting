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
    /// Interaction logic for CandidateDelete.xaml
    /// </summary>
    public partial class CandidateDelete : UserControl
    {
        //tanggalin mo nalang kung papalitan mo na ng value galing database
        public class DataObject
        {
            public int A { get; set; }
            public String B { get; set; }
            public String C { get; set; }
        }

        public CandidateDelete()
        {         
            InitializeComponent();

            //tanggalin mo nalang kung papalitan mo na ng value galing database
            var list = new ObservableCollection<DataObject>();

            list.Add(new DataObject() { A = 1, B = "Carl Emerson L. Argente", C = "Vice President for External Affair" });
            list.Add(new DataObject() { A = 2, B = "Carl Emerson L. Argente", C = "Accountancy, Business and Management Representative" });
            list.Add(new DataObject() { A = 3, B = "Carl Emerson L. Argente", C = "Tourism and Hospitality Representative", });
            list.Add(new DataObject() { A = 4, B = "Carl Emerson L. Argente", C = "Vice President for External Affair" });
            list.Add(new DataObject() { A = 5, B = "Carl Emerson L. Argente", C = "Accountancy, Business and Management Representative" });
            list.Add(new DataObject() { A = 6, B = "Carl Emerson L. Argente", C = "Tourism and Hospitality Representative", });
            list.Add(new DataObject() { A = 7, B = "Carl Emerson L. Argente", C = "Vice President for External Affair" });
            list.Add(new DataObject() { A = 8, B = "Carl Emerson L. Argente", C = "Accountancy, Business and Management Representative" });
            list.Add(new DataObject() { A = 9, B = "Carl Emerson L. Argente", C = "Tourism and Hospitality Representative", });
            list.Add(new DataObject() { A = 10, B = "Carl Emerson L. Argente", C = "Vice President for External Affair" });
            list.Add(new DataObject() { A = 11, B = "Carl Emerson L. Argente", C = "Accountancy, Business and Management Representative" });
            list.Add(new DataObject() { A = 12, B = "Carl Emerson L. Argente", C = "Tourism and Hospitality Representative", });
            this.dataGrid1.ItemsSource = list;

        }

        private void DataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Click_Delete(object sender, RoutedEventArgs e)
        {

        }
    }
}
