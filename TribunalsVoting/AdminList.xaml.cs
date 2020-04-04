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
    /// Interaction logic for AdminList.xaml
    /// </summary>
    public partial class AdminList : UserControl
    {
        //for updating table
        void UpdateTable()
        {
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT Admin_ID, Username FROM tbl_admin", getter.conn);
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

        public AdminList()
        {
            InitializeComponent();

            UpdateTable();

        }

        private void TxtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            //for searching
            try
            {
                if (txtSearch.Text.Equals(""))
                {
                    UpdateTable();               
                }
                else
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT Admin_ID, Username FROM tbl_admin WHERE Admin_ID LIKE '" + txtSearch.Text + "%'  OR Username LIKE '" + txtSearch.Text + "%' ", getter.conn);
                    getter.conn.Open();
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGrid1.ItemsSource = ds.Tables[0].DefaultView;
                    getter.conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
