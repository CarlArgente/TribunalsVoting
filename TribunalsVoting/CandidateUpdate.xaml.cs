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
    /// Interaction logic for CandidateUpdate.xaml
    /// </summary>
    public partial class CandidateUpdate : UserControl
    {
        //tanggalin mo nalang kung papalitan mo na ng value galing database
        public class DataObject
        {
            public int A { get; set; }
            public String B { get; set; }
        }

        //eto fixed na to
        String[] positions = new String[] {
            "President",
            "Vice President for External Affair",
            "Vice President for Internal Affair",
            "Vice President for Academic Affair",
            "Vice President for Operation",
            "Vice President for Finance",
            "ICT Representative",
            "Engineering Representative",
            "Accountancy, Business and Management Representative",
            "Tourism and Hospitality Representative",
            "Arts and Science Representative"
        };
        String[] partylist = new string[]
        {
            "PartyList1",
            "PartyList2",
            "PartyList3",
            "PartyList4",
        };

        public CandidateUpdate()
        {
            InitializeComponent();
            AddItemInComboBox();

            //tanggalin mo nalang kung papalitan mo na ng value galing database
            var list = new ObservableCollection<DataObject>();

            list.Add(new DataObject() { A = 1, B = "Carl Emerson L. Argente" });
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
        }
        private void Click_btnAchievement(object sender, RoutedEventArgs e)
        {
            listAchievement.Items.Add(txtAchievement.Text);
            txtAchievement.Text = null;
        }
        private void Click_btnPlatform(object sender, RoutedEventArgs e)
        {
            listPlatform.Items.Add(txtPlatform.Text);
            txtPlatform.Text = null;
        }

        //for click delete button in list view
        private void listAchievement_KeyDown(object sender, KeyEventArgs e)
        {
            if (listAchievement.Items.Count > 0)
            {
                if (e.Key == Key.Delete)
                {
                    listAchievement.Items.RemoveAt(listAchievement.Items.IndexOf(listAchievement.SelectedItem));
                }
            }

        }
        private void listPlatform_KeyDown(object sender, KeyEventArgs e)
        {
            if (listPlatform.Items.Count > 0)
            {
                if (e.Key == Key.Delete)
                {
                    listPlatform.Items.RemoveAt(listPlatform.Items.IndexOf(listPlatform.SelectedItem));
                }
            }
        }
        //for adding items in combobox
        public void AddItemInComboBox()
        {
            foreach (String s in positions)
            {
                cmbPosition.Items.Add(s);
            }
            //Note: Not done yet
            foreach (String y in partylist)
            {
                cmbPartylist.Items.Add(y);
            }

        }
    }
}
