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
    /// Interaction logic for Ranking.xaml
    /// </summary>
    public partial class Ranking : UserControl
    {
        //tanggalin mo nalang kung papalitan mo na ng value galing database
        public class DataObject
        {
            public String A { get; set; }
            public String B { get; set; }
            public String C { get; set; }
            public String D { get; set; }
        }

        public Ranking()
        {
            InitializeComponent();

            //tanggalin mo nalang kung papalitan mo na ng value galing database
            var list = new ObservableCollection<DataObject>();

            list.Add(new DataObject() { A = "Car Emerson L Argente", B = "Accountancy, Business and management representative", C = "KaISA", D = "1000" });
            list.Add(new DataObject() { A = "Justine Andrei Tan", B = "ICT representative", C = "KaISA", D = "999" });
            list.Add(new DataObject() { A = "Jerric Bersamin", B = "Tourism and Hospitality representative", C = "KaISA", D = "500" });
            list.Add(new DataObject() { A = "Maverick Cejo", B = "Vice President for External Affair", C = "KaISA", D = "800" });
            list.Add(new DataObject() { A = "Car Emerson L Argente", B = "Accountancy, Business and management representative", C = "KaISA", D = "1000" });
            list.Add(new DataObject() { A = "Justine Andrei Tan", B = "ICT representative", C = "KaISA", D = "999" });
            list.Add(new DataObject() { A = "Jerric Bersamin", B = "Tourism and Hospitality representative", C = "KaISA", D = "500" });
            list.Add(new DataObject() { A = "Maverick Cejo", B = "Vice President for External Affair", C = "KaISA", D = "800" });
            list.Add(new DataObject() { A = "Car Emerson L Argente", B = "Accountancy, Business and management representative", C = "KaISA", D = "1000" });
            list.Add(new DataObject() { A = "Justine Andrei Tan", B = "ICT representative", C = "KaISA", D = "999" });
            list.Add(new DataObject() { A = "Jerric Bersamin", B = "Tourism and Hospitality representative", C = "KaISA", D = "500" });
            list.Add(new DataObject() { A = "Maverick Cejo", B = "Vice President for External Affair", C = "KaISA", D = "800" });



            this.dataGrid1.ItemsSource = list;
        }
    }
}
