using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
namespace TribunalsVoting
{
    /// <summary>
    /// Interaction logic for CandidateUpdate.xaml
    /// </summary>
    public partial class CandidateUpdate : UserControl
    {
        //variables
        String id, getTime, getName, getNickname, getPosition, getPartylist;

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

        //for updating table
        void UpdateTable()
        {
            getter.conn.Close();
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT Candidate_id, Candidate_Name FROM tbl_candidates", getter.conn);
                getter.conn.Open();
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGrid1.ItemsSource = ds.Tables[0].DefaultView;
                getter.conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                getter.conn.Close();
            }
        }
        void DisplayCandidateData(String id)
        {
            getter.conn.Close();
            getter.conn.Open();
            MySqlCommand cmd = getter.conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM tbl_candidates WHERE Candidate_id='" + id + "' ";
            MySqlDataReader sqlDataReader = null;
            sqlDataReader = cmd.ExecuteReader();
            if (sqlDataReader.Read())
            {
                //for getting value
                getName = sqlDataReader["Candidate_name"].ToString();
                getNickname = sqlDataReader["Candidate_Nickname"].ToString();
                getPosition = sqlDataReader["Candidate_Position"].ToString();
                getPartylist = sqlDataReader["Candidate_Party"].ToString();

                //for displaying
                txtCandidateName.Text = getName;
                txtCandidateNickname.Text = getNickname;
                cmbPosition.SelectedItem = getPosition;
                cmbPartylist.SelectedItem = getPartylist;
            }
            sqlDataReader.Close();
            getter.conn.Close();
        }
        //for display achievement
        void DisplayAchievementData(String id)
        {
            getter.conn.Close();
            listAchievement.Items.Clear();
            getter.conn.Open();
            MySqlCommand cmd = getter.conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM tbl_candidate_achievement WHERE Candidate_ID='" + id + "' ";
            MySqlDataReader sqlDataReader = null;
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                listAchievement.Items.Add(sqlDataReader["Achievement_title"].ToString());
            }
            sqlDataReader.Close();
            getter.conn.Close();
        }
        //for displaying platform
        void DisplayPlatformData(String id)
        {
            getter.conn.Close();
            listPlatform.Items.Clear();
            getter.conn.Open();
            MySqlCommand cmd = getter.conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM tbl_candidate_platform WHERE Candidate_ID='" + id + "' ";
            MySqlDataReader sqlDataReader = null;
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                listPlatform.Items.Add(sqlDataReader["platform"].ToString());
            }
            sqlDataReader.Close();
            getter.conn.Close();
        }
        void ExecuteQuery(String query)
        {
            try
            {

                getter.conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, getter.conn);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    //nothing to display
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                getter.conn.Close();
            }
        }
       
        void SetSizeColumns()
        {
            dataGrid1.Columns[0].Width = 70;
            dataGrid1.Columns[1].Width = 150;
        }

        void UpdateCandidate(String id)
        {
            if (txtCandidateName.Text.Equals("") || txtCandidateNickname.Text.Equals("") || cmbPosition.SelectedIndex == -1 || cmbPartylist.SelectedIndex == -1 ||
              listAchievement.Items.Count == 0 || listPlatform.Items.Count == 0)
            {
                MessageBox.Show("Please input properly", "Failed", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                getter.conn.Close();
                String updateData = "UPDATE tbl_candidates SET Candidate_Name='" + txtCandidateName.Text + "', Candidate_Nickname='" + txtCandidateNickname.Text + "', " +
                    "Candidate_Position='"+cmbPosition.SelectedItem.ToString()+"', Candidate_Party = '"+cmbPartylist.SelectedItem.ToString()+"' WHERE Candidate_id='"+id+"' ";
                ExecuteQuery(updateData);

                String dropAchievement = "DELETE FROM tbl_candidate_achievement WHERE Candidate_ID='" + id + "' ";
                String dropPlatform = "DELETE FROM tbl_candidate_platform WHERE Candidate_ID='" + id + "' ";
                ExecuteQuery(dropAchievement);
               //for update achievements
                for (int x = 0; x < listAchievement.Items.Count; x++)
                {
                    String insertAchievement = "INSERT INTO tbl_candidate_achievement VALUES('', '" + listAchievement.Items[x].ToString() + "', (SELECT MAX(Candidate_id)FROM tbl_candidates)) ";
                    ExecuteQuery(insertAchievement);
                }
                //for inserting Platforms
                ExecuteQuery(dropPlatform);
                for (int y = 0; y < listPlatform.Items.Count; y++)
                {
                    String insertPlatform = "INSERT INTO tbl_candidate_platform VALUES('', '" + listPlatform.Items[y].ToString() + "', (SELECT MAX(Candidate_id)FROM tbl_candidates)) ";
                    ExecuteQuery(insertPlatform);
                }

                //for inserting in history
                var time = System.DateTime.Now.DayOfWeek.ToString() + " | " + DateTime.Now;
                getTime = time.ToString();
                String sql1 = "INSERT INTO tbl_history(Admin_ID,Activities,Date_Time) VALUES ('" + getter.getId + "', CONCAT('Updated Candidate with an ID of ', '"+id+"') , '" + getTime + "')";
                ExecuteQuery(sql1);


                MessageBox.Show("Successfully Updated Candidate", "Success", MessageBoxButton.OK, MessageBoxImage.Information);


            }
        }

        public CandidateUpdate()
        {
            InitializeComponent();
            AddItemInComboBox();
            UpdateTable();


        }
        private void Click_btnAchievement(object sender, RoutedEventArgs e)
        {
            if (txtAchievement.Text.Equals(""))
            {
                MessageBox.Show("The Achievement is Empty", "Failed", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                listAchievement.Items.Add(txtAchievement.Text);
                txtAchievement.Text = null;
            }
        }
        private void Click_btnPlatform(object sender, RoutedEventArgs e)
        {
            if (txtPlatform.Text.Equals(""))
            {
                MessageBox.Show("The Platform is Empty", "Failed", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                listPlatform.Items.Add(txtPlatform.Text);
                txtPlatform.Text = null;
            }
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateCandidate(id);
        }

        private void DataGrid1_Loaded(object sender, RoutedEventArgs e)
        {
            SetSizeColumns();
        }
     
        private void DataGrid1_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            //for displaying
            DataRowView dataRow = dataGrid1.SelectedItem as DataRowView;
            id = dataRow.Row[0].ToString();
            DisplayCandidateData(id);
            DisplayAchievementData(id);
            DisplayPlatformData(id);

        }
    }
}
