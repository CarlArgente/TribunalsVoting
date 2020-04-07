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
    /// Interaction logic for Ranking.xaml
    /// </summary>
    public partial class Ranking : UserControl
    {

        //for updating table
        void UpdateTable()
        {
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT  c.Candidate_Name AS 'Candidate Name', c.Candidate_Position AS 'Candidate Position',c.Candidate_Party AS 'Partylist', " +
                    "v.Number_Of_Votes AS 'Votes' FROM tbl_candidates c INNER JOIN ( SELECT * FROM tbl_votes WHERE Number_Of_Votes <= (SELECT MAX(Number_Of_Votes)FROM tbl_votes)) v " +
                    "ON v.Candidate_ID = c.Candidate_id WHERE c.Candidate_Position = c.Candidate_Position", getter.conn);
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
        }
        void SetSizeColumns()
        {
            getter.conn.Close();
            dataGrid1.Columns[0].Width = 250;
            dataGrid1.Columns[1].Width = 320;
            dataGrid1.Columns[2].Width = 130;
            dataGrid1.Columns[2].Width = 130;
        }
        public Ranking()
        {
            InitializeComponent();
            UpdateTable();
        }

        private void DataGrid1_Loaded(object sender, RoutedEventArgs e)
        {
            SetSizeColumns();
        }

        private void DataGrid1_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
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
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT  c.Candidate_Name AS 'Candidate Name', c.Candidate_Position AS 'Candidate Position',c.Candidate_Party AS 'Partylist', " +
                      "v.Number_Of_Votes AS 'Votes' FROM tbl_candidates c INNER JOIN ( SELECT * FROM tbl_votes WHERE Number_Of_Votes <= (SELECT MAX(Number_Of_Votes)FROM tbl_votes)) v " +
                      "ON v.Candidate_ID = c.Candidate_id WHERE c.Candidate_Name LIKE '" + txtSearch.Text + "%' OR c.Candidate_Position LIKE '" + txtSearch.Text + "%' OR " +
                      "c.Candidate_Party LIKE '" + txtSearch.Text + "%' ", getter.conn);
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
                MessageBox.Show(ex.Message);
            }
        }
    }
}
