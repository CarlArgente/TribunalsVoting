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
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace TribunalsVoting
{
    /// <summary>
    /// Interaction logic for AdminChangePass.xaml
    /// </summary>
    public partial class AdminChangePass : Window
    {
        String getPassword;
        void getOldPassword()
        {
            getter.conn.Open();
            MySqlCommand cmd = getter.conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM tbl_admin WHERE Admin_ID='" + getter.getId + "' ";
            MySqlDataReader sqlDataReader = null;
            sqlDataReader = cmd.ExecuteReader();
            if (sqlDataReader.Read())
            {
                getPassword = sqlDataReader["Password"].ToString();
            }
            sqlDataReader.Close();
            getter.conn.Close();
        }
        void changePass()
        {
            try
            {
                getter.conn.Open();
                MySqlCommand cmd = new MySqlCommand("Update tbl_admin SET Password='" + txtPassword.Password + "' WHERE Admin_ID='" + getter.getId + "' ", getter.conn);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Successfully Changed", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Hide();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to update");
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
        public AdminChangePass()
        {
            InitializeComponent();
            getOldPassword();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtOldPassword.Password != getPassword || txtPassword.Password != txtConfirmPassword.Password)
            {
                MessageBox.Show("Wrong input Please Try Again!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                changePass();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();        
            this.Close();
        }
    }
}
