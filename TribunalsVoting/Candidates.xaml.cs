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
    /// Interaction logic for Candidates.xaml
    /// </summary>
    public partial class Candidates : UserControl
    {
        public String[] achievement = { "Carl Emerson L. Argente", "Carl Emerson L. Argente", "Carl Emerson L. Argente", "Carl Emerson L. Argente", "Carl Emerson L. Argente", "Carl Emerson L. Argente", "Carl Emerson L. Argente", "Carl Emerson L. Argente", "Carl Emerson L. Argente",  };
        public class DataObject
        {
            public int A { get; set; }
            public String B { get; set; }
            public String C { get; set; }
       
        }

        public Candidates()
        {
            InitializeComponent();

            var list = new ObservableCollection<DataObject>();
           
            list.Add(new DataObject() { A = 1, B = "Carl Emerson L. Argente"});
            list.Add(new DataObject() { A = 2, B = "Tan" });
            list.Add(new DataObject() { A = 3, B = "Bersamin" });
            list.Add(new DataObject() { A = 4, B = "Cejo" });
            list.Add(new DataObject() { A = 5, B = "Argente" });
            list.Add(new DataObject() { A = 6, B = "Tan" });
            list.Add(new DataObject() { A = 7, B = "Bersamin" });
            list.Add(new DataObject() { A = 8, B = "Cejo" });
            list.Add(new DataObject() { A = 9, B = "Argente" });
            list.Add(new DataObject() { A = 10, B = "Tan" });
            list.Add(new DataObject() { A = 11, B = "Bersamin" });
            list.Add(new DataObject() { A = 12, B = "Cejo" });
            list.Add(new DataObject() { A = 13, B = "Argente" });
            list.Add(new DataObject() { A = 14, B = "Tan" });
            list.Add(new DataObject() { A = 15, B = "Bersamin" });
            list.Add(new DataObject() { A = 16, B = "Cejo" });
            
            this.dataGrid1.ItemsSource = list;
         
            this.txtAchievement.ItemsSource = achievement;
            this.txtPlatform.ItemsSource = achievement;
        }

        private void DataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
