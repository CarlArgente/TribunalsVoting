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
    /// Interaction logic for StudentLogs.xaml
    /// </summary>
    public partial class StudentLogs : UserControl
    {
        //for updating table
        void UpdateTable()
        {
            try
            {
                getter.conn.Close();
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM tbl_vote_logs", getter.conn);
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
            dataGrid1.Columns[0].Width = 100;
            dataGrid1.Columns[1].Width = 150;
            dataGrid1.Columns[2].Width = 250;
            dataGrid1.Columns[3].Width = 250;
        }

        public StudentLogs()
        {
            InitializeComponent();
            UpdateTable();
        }

        private void DataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
         
        }

        private void DataGrid1_Loaded_1(object sender, RoutedEventArgs e)
        {

            SetSizeColumns();
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
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM tbl_vote_logs WHERE Vote_Log_ID LIKE '" + txtSearch.Text + "%'  OR Student_Number LIKE '" + txtSearch.Text + "%' OR Computer_Name LIKE '" + txtSearch.Text + "%' OR Date_Time LIKE '" + txtSearch.Text + "%' ", getter.conn);
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
