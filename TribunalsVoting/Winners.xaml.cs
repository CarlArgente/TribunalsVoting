using MySql.Data.MySqlClient;
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

namespace TribunalsVoting
{
    /// <summary>
    /// Interaction logic for Winners.xaml
    /// </summary>
    public partial class Winners : UserControl
    {

        //for updating table
        private void updateTable()
        {
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter("(SELECT tbl_candidates.Candidate_Name as 'Candidate_Name', tbl_candidates.Candidate_Position as " +
                    "'Candidate_Position',tbl_candidates.Candidate_Party as 'Candidate_Party', tbl_votes.Number_Of_Votes FROM tbl_candidates INNER JOIN tbl_votes ON " +
                    "tbl_candidates.Candidate_id = tbl_votes.Candidate_ID WHERE(SELECT MAX(tbl_votes.Number_Of_Votes) FROM tbl_votes)" +
                    " AND tbl_candidates.Candidate_Position='President' ORDER BY tbl_votes.Number_Of_Votes DESC LIMIT 1) UNION (SELECT tbl_candidates.Candidate_Name " +
                    "as 'Candidate_Name', tbl_candidates.Candidate_Position as 'Candidate_Position',tbl_candidates.Candidate_Party as 'Candidate_Party'," +
                    " tbl_votes.Number_Of_Votes FROM tbl_candidates INNER JOIN tbl_votes ON tbl_candidates.Candidate_id = tbl_votes.Candidate_ID " +
                    "WHERE(SELECT MAX(tbl_votes.Number_Of_Votes) FROM tbl_votes) AND tbl_candidates.Candidate_Position='Vice President for Academic Affair' " +
                    "ORDER BY tbl_votes.Number_Of_Votes DESC LIMIT 1) UNION(SELECT tbl_candidates.Candidate_Name as 'Candidate_Name', tbl_candidates.Candidate_Position " +
                    "as 'Candidate_Position',tbl_candidates.Candidate_Party as 'Candidate_Party', tbl_votes.Number_Of_Votes FROM tbl_candidates INNER JOIN tbl_votes ON " +
                    "tbl_candidates.Candidate_id = tbl_votes.Candidate_ID WHERE(SELECT MAX(tbl_votes.Number_Of_Votes) FROM tbl_votes) " +
                    "AND tbl_candidates.Candidate_Position='Vice President For Internal Affair' ORDER BY tbl_votes.Number_Of_Votes DESC LIMIT 1) " +
                    "UNION (SELECT tbl_candidates.Candidate_Name as 'Candidate_Name', tbl_candidates.Candidate_Position as 'Candidate_Position'," +
                    " tbl_candidates.Candidate_Party as 'Candidate_Party', tbl_votes.Number_Of_Votes FROM tbl_candidates INNER JOIN tbl_votes ON " +
                    "tbl_candidates.Candidate_id = tbl_votes.Candidate_ID WHERE(SELECT MAX(tbl_votes.Number_Of_Votes) FROM tbl_votes) " +
                    "AND tbl_candidates.Candidate_Position='Vice President For External Affair' ORDER BY tbl_votes.Number_Of_Votes DESC LIMIT 1) UNION " +
                    "(SELECT tbl_candidates.Candidate_Name as 'Candidate_Name', tbl_candidates.Candidate_Position as 'Candidate_Position', tbl_candidates.Candidate_Party " +
                    "as 'Candidate_Party', tbl_votes.Number_Of_Votes FROM tbl_candidates INNER JOIN tbl_votes ON tbl_candidates.Candidate_id = tbl_votes.Candidate_ID " +
                    "WHERE(SELECT MAX(tbl_votes.Number_Of_Votes) FROM tbl_votes) AND tbl_candidates.Candidate_Position='Vice President For Operation' " +
                    "ORDER BY tbl_votes.Number_Of_Votes DESC LIMIT 1) UNION (SELECT tbl_candidates.Candidate_Name as 'Candidate_Name', tbl_candidates.Candidate_Position " +
                    "as 'Candidate_Position',tbl_candidates.Candidate_Party as 'Candidate_Party', tbl_votes.Number_Of_Votes FROM tbl_candidates INNER JOIN " +
                    "tbl_votes ON tbl_candidates.Candidate_id = tbl_votes.Candidate_ID WHERE(SELECT MAX(tbl_votes.Number_Of_Votes) FROM tbl_votes) AND" +
                    " tbl_candidates.Candidate_Position='Vice President For Finance' ORDER BY tbl_votes.Number_Of_Votes DESC LIMIT 1) " +
                    "UNION (SELECT tbl_candidates.Candidate_Name as 'Candidate_Name', tbl_candidates.Candidate_Position as 'Candidate_Position', " +
                    "tbl_candidates.Candidate_Party as 'Candidate_Party', tbl_votes.Number_Of_Votes FROM tbl_candidates INNER JOIN tbl_votes " +
                    "ON tbl_candidates.Candidate_id = tbl_votes.Candidate_ID WHERE(SELECT MAX(tbl_votes.Number_Of_Votes) FROM tbl_votes) AND " +
                    "tbl_candidates.Candidate_Position='ICT Representative' ORDER BY tbl_votes.Number_Of_Votes DESC LIMIT 1) UNION (SELECT tbl_candidates.Candidate_Name " +
                    "as 'Candidate_Name', tbl_candidates.Candidate_Position as 'Candidate_Position', tbl_candidates.Candidate_Party as 'Candidate_Party', " +
                    "tbl_votes.Number_Of_Votes FROM tbl_candidates INNER JOIN tbl_votes ON tbl_candidates.Candidate_id = tbl_votes.Candidate_ID WHERE" +
                    "(SELECT MAX(tbl_votes.Number_Of_Votes) FROM tbl_votes) AND tbl_candidates.Candidate_Position='Engineering Representative' ORDER BY " +
                    "tbl_votes.Number_Of_Votes DESC LIMIT 1) UNION (SELECT tbl_candidates.Candidate_Name as 'Candidate_Name', tbl_candidates.Candidate_Position " +
                    "as 'Candidate_Position',tbl_candidates.Candidate_Party as 'Candidate_Party', tbl_votes.Number_Of_Votes FROM tbl_candidates INNER JOIN tbl_votes " +
                    "ON tbl_candidates.Candidate_id = tbl_votes.Candidate_ID WHERE(SELECT MAX(tbl_votes.Number_Of_Votes) FROM tbl_votes) AND " +
                    "tbl_candidates.Candidate_Position='Accountancy, Business and Management Representative' ORDER BY tbl_votes.Number_Of_Votes DESC LIMIT 1) UNION " +
                    "(SELECT tbl_candidates.Candidate_Name as 'Candidate_Name', tbl_candidates.Candidate_Position as 'Candidate_Position',tbl_candidates.Candidate_Party " +
                    "as 'Candidate_Party', tbl_votes.Number_Of_Votes FROM tbl_candidates INNER JOIN tbl_votes ON tbl_candidates.Candidate_id = tbl_votes.Candidate_ID " +
                    "WHERE(SELECT MAX(tbl_votes.Number_Of_Votes) FROM tbl_votes) AND tbl_candidates.Candidate_Position='Tourism and Hospitality Representative' " +
                    "ORDER BY tbl_votes.Number_Of_Votes DESC LIMIT 1) UNION (SELECT tbl_candidates.Candidate_Name as 'Candidate_Name', tbl_candidates.Candidate_Position " +
                    "as 'Candidate_Position',tbl_candidates.Candidate_Party as 'Candidate_Party', tbl_votes.Number_Of_Votes FROM tbl_candidates INNER JOIN tbl_votes " +
                    "ON tbl_candidates.Candidate_id = tbl_votes.Candidate_ID WHERE(SELECT MAX(tbl_votes.Number_Of_Votes) FROM tbl_votes) " +
                    "AND tbl_candidates.Candidate_Position='Arts and Science Representative' ORDER BY tbl_votes.Number_Of_Votes DESC LIMIT 1) ", getter.conn);
                    getter.conn.Open();
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGrid1.ItemsSource = ds.Tables[0].DefaultView;
                    getter.conn.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        void SetSizeColumns()
        {
            getter.conn.Close();
            dataGrid1.Columns[0].Width = 130;
            dataGrid1.Columns[1].Width = 300;
            dataGrid1.Columns[2].Width = 130;
            dataGrid1.Columns[2].Width = 130;
        }

        public Winners()
        {
            InitializeComponent();
            updateTable();
        }

        private void DataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DataGrid1_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
