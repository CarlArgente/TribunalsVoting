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
    /// Interaction logic for CandidateDelete.xaml
    /// </summary>
    public partial class CandidateDelete : UserControl
    {
        String id, getId, getTime;
        //for updating table
        void UpdateTable()
        {
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT Candidate_id AS ID, Candidate_Name, Candidate_Position FROM tbl_candidates", getter.conn);
                getter.conn.Open();
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGrid1.ItemsSource = ds.Tables[0].DefaultView;
                getter.conn.Close();
            }
            catch (Exception e)
            {
               
            }
        }
        void DisplayCandidateData(String id)
        {
            getter.conn.Close();
            getter.conn.Open();
            MySqlCommand cmd = getter.conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Candidate_id FROM tbl_candidates WHERE Candidate_id='" + id + "' ";
            MySqlDataReader sqlDataReader = null;
            sqlDataReader = cmd.ExecuteReader();
            if (sqlDataReader.Read())
            {
                //for getting value
                getId = sqlDataReader["Candidate_id"].ToString();
                
                txtCandidateID.Text = getId;
            }
            sqlDataReader.Close();
            getter.conn.Close();
        }
        void SetSizeColumns()
        {
            dataGrid1.Columns[0].Width = 70;
            dataGrid1.Columns[1].Width = 200;
            dataGrid1.Columns[2].Width = 380;
        }
        void ExecuteDelete(String query)
        {
            try
            {

                getter.conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, getter.conn);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Successfully Deleted Candidate", "Successfully Added", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("error");
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
        void RecordHistory(String query)  
        {
            try
            {

                getter.conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, getter.conn);
                if (cmd.ExecuteNonQuery() == 1)
                {
                   //nothing to display
                }
                else
                {
                    
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
        public CandidateDelete()
        {         
            InitializeComponent();
            UpdateTable();
            
        }

        private void DataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Click_Delete(object sender, RoutedEventArgs e)
        {
            String deleteQuery = "DELETE FROM tbl_candidates WHERE Candidate_id = '" + txtCandidateID.Text + "' ";
            ExecuteDelete(deleteQuery);

            //for inserting in history
            var time = System.DateTime.Now.DayOfWeek.ToString() + " | " + DateTime.Now;
            getTime = time.ToString();
            String sql1 = "INSERT INTO tbl_history(Admin_ID,Activities,Date_Time) VALUES ('" + getter.getId + "', CONCAT('Deleted Candidate with an ID of ', '" + id + "') , '" + getTime + "')";
            RecordHistory(sql1);

            UpdateTable();
            SetSizeColumns();
            getter.conn.Close();
            txtCandidateID.Text = null;
        }

        private void DataGrid1_Loaded(object sender, RoutedEventArgs e)
        {
            SetSizeColumns();
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            //for searching
            try
            {
                getter.conn.Close();

                if (txtSearch.Text.Equals(""))
                {
                    UpdateTable();
                    SetSizeColumns();
                }
                else
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT Candidate_id AS ID, Candidate_Name, Candidate_Position FROM tbl_candidates WHERE Candidate_id LIKE '" + txtSearch.Text + "%'  OR Candidate_Name LIKE '" + txtSearch.Text + "%' OR Candidate_Position LIKE '" + txtSearch.Text + "%' ", getter.conn);
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

        private void DataGrid1_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            //for displaying
            DataRowView dataRow = dataGrid1.SelectedItem as DataRowView;
            id = dataRow.Row[0].ToString();
            DisplayCandidateData(id);
          
        }
    }
}
