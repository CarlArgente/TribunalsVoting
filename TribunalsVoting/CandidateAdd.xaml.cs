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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace TribunalsVoting
{
    /// <summary>
    /// Interaction logic for CandidateAdd.xaml
    /// </summary>
    public partial class CandidateAdd : UserControl
    {
       

        private String getTime;

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
        //for click delete button in list view
        void listAchievement_KeyDown(object sender, KeyEventArgs e)
        {
            if (listAchievement.Items.Count > 0)
            {
                if (e.Key == Key.Delete)
                {
                    listAchievement.Items.RemoveAt(listAchievement.Items.IndexOf(listAchievement.SelectedItem));
                }
            }

        }
        //for adding items in combobox
        void AddItemInComboBox()
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
        void executeQuery(String query, String errorMessage)    //lagyan nyo nalang ng another parameter para sa message na gusto nyo
        {
            try
            {

                getter.conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, getter.conn);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    //Display Message for inserting, updating, deleting
                }
                else
                {
                    MessageBox.Show(errorMessage);
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
        void Reset()
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
        public CandidateAdd()
        {
            InitializeComponent();
            AddItemInComboBox();       
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

       
        void listPlatform_KeyDown(object sender, KeyEventArgs e)
        {
            if (listPlatform.Items.Count > 0)
            {
                if (e.Key == Key.Delete)
                {
                    listPlatform.Items.RemoveAt(listPlatform.Items.IndexOf(listPlatform.SelectedItem));
                }
            }
        }
        
        //for inserting data of candidate
        void InsertCandidate()
        {
            if (txtCandidateName.Text.Equals("") || txtCandidateNickname.Text.Equals("") || cmbPosition.SelectedIndex == -1 || cmbPartylist.SelectedIndex == -1 ||
                listAchievement.Items.Count == 0 || listPlatform.Items.Count == 0)
            {
                MessageBox.Show("Please input properly", "Failed", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
            else
            {
                getter.conn.Open();
                MySqlCommand cmd = getter.conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from tbl_candidates where Candidate_Position = '" + cmbPosition.SelectedItem.ToString() + "' AND Candidate_Party = '" + cmbPartylist.SelectedItem.ToString() + "'";
                MySqlDataReader sqlDataReader = null;
                sqlDataReader = cmd.ExecuteReader();
                if (!sqlDataReader.HasRows)
                {
                    getter.conn.Close();
                    //for inserting information of candidate
                    String sql = "INSERT INTO tbl_candidates(Candidate_Name, Candidate_Nickname, Candidate_Position, Candidate_Party) " +
                        "VALUES ('" + txtCandidateName.Text + "', '" + txtCandidateNickname.Text + "', '" + cmbPosition.SelectedItem.ToString() + "', '" + cmbPartylist.SelectedItem.ToString() + "')";
                    executeQuery(sql, "Failed to Insert Candidate");
                    //for insert achievements
                    for (int x = 0; x < listAchievement.Items.Count; x++)
                    {
                        String insertAchievement = "INSERT INTO tbl_candidate_achievement VALUES('', '" + listAchievement.Items[x].ToString() + "', (SELECT MAX(Candidate_id)FROM tbl_candidates)) ";
                        executeQuery(insertAchievement, "Failed to Insert Achievement");
                    }
                    //for inserting Platforms
                    for (int y = 0; y < listPlatform.Items.Count; y++)
                    {
                        String insertPlatform = "INSERT INTO tbl_candidate_platform VALUES('', '" + listPlatform.Items[y].ToString() + "', (SELECT MAX(Candidate_id)FROM tbl_candidates)) ";
                        executeQuery(insertPlatform, "Failed to Insert Platform");
                    }
                    //for inserting in tbl_votes
                    String insertVote = "INSERT INTO tbl_votes(Candidate_ID, Number_Of_Votes) VALUES ((SELECT MAX(Candidate_id) FROM tbl_candidates),0)";
                    executeQuery(insertVote, "Failed to Insert in tbl_votes");
                    //for inserting in history
                    var time = System.DateTime.Now.DayOfWeek.ToString() + " | " + DateTime.Now;
                    getTime = time.ToString();
                    String sql1 = "INSERT INTO tbl_history(Admin_ID,Activities,Date_Time) VALUES ('" + getter.getId + "', CONCAT('Added Candidate with an ID of ', (SELECT MAX(Candidate_id)FROM tbl_candidates)) , '" + getTime + "')";
                    executeQuery(sql1, "Failed to insert in tbl_history");

                    MessageBox.Show("Successfully Added Candidate", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    Reset();
                
                }
                getter.conn.Close();
            }           
        }
        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            Reset();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //for adding candidate
            InsertCandidate();


        }
    }
}
