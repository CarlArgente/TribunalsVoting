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
    /// Interaction logic for Candidates.xaml
    /// </summary>
    public partial class Candidates : UserControl
    {
        //variables
        String getName, getNickname, getPosition, getPartylist;
     
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
            cmd.CommandText = "SELECT * FROM tbl_candidates WHERE Candidate_id='"+id+"' ";
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
                txtName.Text = getName;
                txtNickName.Text = getNickname;
                txtPosition.Text = getPosition;
                txtPartyList.Text = getPartylist;
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
        void SetSizeColumns()
        {
            dataGrid1.Columns[0].Width = 70;
            dataGrid1.Columns[1].Width = 150;     
        }
        void Reset()
        {
            txtName.Text = null;
            txtNickName.Text = null;
            txtPosition.Text = null;
            txtPartyList.Text = null;
            listAchievement.Items.Clear();
            listPlatform.Items.Clear();
        }

        private void TxtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            //for searching
            try
            {
                if (txtSearch.Text.Equals(""))
                {
                    UpdateTable();
                    SetSizeColumns();
                }
                else
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT Candidate_id, Candidate_Name FROM tbl_candidates WHERE Candidate_id LIKE '" + txtSearch.Text + "%'  OR Candidate_Name LIKE '" + txtSearch.Text + "%' ", getter.conn);
                    getter.conn.Open();
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGrid1.ItemsSource = ds.Tables[0].DefaultView;
                    getter.conn.Close();
                    SetSizeColumns();             
                }
            }
            catch (Exception ex)
            {
            }
        }

        public Candidates()
        {
            InitializeComponent();
            UpdateTable();
          
        }

        private void DataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }
        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            SetSizeColumns();
        }

        private void DataGrid1_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            //for displaying
            DataRowView dataRow = dataGrid1.SelectedItem as DataRowView;
            String id = dataRow.Row[0].ToString();
            DisplayCandidateData(id);
            DisplayAchievementData(id);
            DisplayPlatformData(id);
           

        }
    }
}
