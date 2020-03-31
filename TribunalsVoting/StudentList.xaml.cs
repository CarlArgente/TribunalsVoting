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
    /// Interaction logic for StudentList.xaml
    /// </summary>
    public partial class StudentList : UserControl
    {
        //tanggalin mo nalang kung papalitan mo na ng value galing database
        public class DataObject
        {
            public int A { get; set; }
            public String B { get; set; }
            public String C { get; set; }
            public String D { get; set; }
        }

        public StudentList()
        {
            InitializeComponent();

            //tanggalin mo nalang kung papalitan mo na ng value galing database
            var list = new ObservableCollection<DataObject>();

            list.Add(new DataObject() { A = 2000039203, B = "Carl Emerson L Argente Pogi", C = "BSIT-404", D = "BSIT" });
            list.Add(new DataObject() { A = 2000123547, B = "Justine Andrei Tan Panget", C = "BSIT-404", D = "BMMA" });
            list.Add(new DataObject() { A = 2031456987, B = "Jerric Bersamin Bading", C = "BSIT-404", D = "BSA" });
            list.Add(new DataObject() { A = 2145369874, B = "Maverick Cejo Tatay ni Cloud", C = "BSIT-404", D = "BACOMM" });
            list.Add(new DataObject() { A = 2000039203, B = "Carl Emerson L Argente Pogi", C = "BSIT-404", D = "BSIT" });
            list.Add(new DataObject() { A = 2000123547, B = "Justine Andrei Tan Panget", C = "BSIT-404", D = "BMMA" });
            list.Add(new DataObject() { A = 2031456987, B = "Jerric Bersamin Bading", C = "BSIT-404", D = "BSA" });
            list.Add(new DataObject() { A = 2145369874, B = "Maverick Cejo Tatay ni Cloud", C = "BSIT-404", D = "BACOMM" });
            list.Add(new DataObject() { A = 2000039203, B = "Carl Emerson L Argente Pogi", C = "BSIT-404", D = "BSIT" });
            list.Add(new DataObject() { A = 2000123547, B = "Justine Andrei Tan Panget", C = "BSIT-404", D = "BMMA" });
            list.Add(new DataObject() { A = 2031456987, B = "Jerric Bersamin Bading", C = "BSIT-404", D = "BSA" });
            list.Add(new DataObject() { A = 2145369874, B = "Maverick Cejo Tatay ni Cloud", C = "BSIT-404", D = "BACOMM" });
            list.Add(new DataObject() { A = 2000039203, B = "Carl Emerson L Argente Pogi", C = "BSIT-404", D = "BSIT" });
            list.Add(new DataObject() { A = 2000123547, B = "Justine Andrei Tan Panget", C = "BSIT-404", D = "BMMA" });
            list.Add(new DataObject() { A = 2031456987, B = "Jerric Bersamin Bading", C = "BSIT-404", D = "BSA" });
            list.Add(new DataObject() { A = 2145369874, B = "Maverick Cejo Tatay ni Cloud", C = "BSIT-404", D = "BACOMM" });
            this.dataGrid1.ItemsSource = list;
        }

        private void DataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
