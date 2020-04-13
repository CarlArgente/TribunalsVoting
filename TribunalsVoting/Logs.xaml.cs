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
    /// Interaction logic for Logs.xaml
    /// </summary>
    public partial class Logs : UserControl
    {
        //for updating table
        void UpdateTable()
        {
            try
            {
                getter.conn.Close();
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM tbl_history", getter.conn);
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
            dataGrid1.Columns[1].Width = 100;
            dataGrid1.Columns[2].Width = 270;
            dataGrid1.Columns[3].Width = 230;

        }
        public Logs()
        {
            InitializeComponent();
            UpdateTable();         
        }
       
        private void DataGrid1_Loaded(object sender, RoutedEventArgs e)
        {
            SetSizeColumns();
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            //for searching
            try {
                if (txtSearch.Text.Equals(""))
                {
                    UpdateTable();
                    SetSizeColumns();
                }
                else
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM tbl_history WHERE Logs_ID LIKE '" + txtSearch.Text + "%'  OR Activities LIKE '"+txtSearch.Text+ "%' OR Admin_ID LIKE '" + txtSearch.Text + "%' OR Date_Time LIKE '" + txtSearch.Text + "%' ", getter.conn);
                    getter.conn.Open();
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGrid1.ItemsSource = ds.Tables[0].DefaultView;
                    getter.conn.Close();

                    SetSizeColumns();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
