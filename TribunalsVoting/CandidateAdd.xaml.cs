using System;
using System.Collections.Generic;
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
    /// Interaction logic for CandidateAdd.xaml
    /// </summary>
    public partial class CandidateAdd : UserControl
    {
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

        public CandidateAdd()
        {
            InitializeComponent();
            AddItemInComboBox();

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

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            txtCandidateName.Text = null;
            txtCandidateNickname.Text = null;
            cmbPartylist.SelectedItem = null;
            cmbPosition.SelectedItem = null;
            txtAchievement.Text = null;
            txtPlatform.Text = null;
            listAchievement.Items.Clear();
            listPlatform.Items.Clear();
        }
    }
}
