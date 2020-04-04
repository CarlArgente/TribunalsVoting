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
    /// Interaction logic for AdminAdd.xaml
    /// </summary>
    public partial class AdminAdd : UserControl
    {
        //Variables
        private int getId;
        private int incrementedId;

        private String getTime;
        
        void ExecuteAddAdmin(String query, String errorMessage) 
        {
            try
            {

                getter.conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, getter.conn);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Successfully Added Admin", "Successfully Added", MessageBoxButton.OK, MessageBoxImage.Information);
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
        void ExecuteInsertHistory(String query, String errorMessage)
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

        void GettingMaxID()
        {
            getter.conn.Open();
            MySqlCommand cmd = getter.conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT MAX(Admin_ID) AS Max_Admin_ID FROM tbl_admin";
            MySqlDataReader sqlDataReader = null;
            sqlDataReader = cmd.ExecuteReader();
            if (sqlDataReader.Read())
            {
                getId = Int32.Parse(sqlDataReader["Max_Admin_ID"].ToString());
            }
            getter.conn.Close();
        }
        void DisplayMaxID()
        {
            incrementedId = getId + 1;
            txtAdminId.Text = incrementedId.ToString();
        }
        public void Reset()
        {
            GettingMaxID();
            DisplayMaxID();
            txtUsername.Text = null;
            txtPassword.Password = null;
            txtConfirmPassword.Password = null;
        }
        public AdminAdd()
        {
            InitializeComponent();
            GettingMaxID();
            DisplayMaxID();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtUsername.Text.Equals("") || txtPassword.Password.Equals("") || txtConfirmPassword.Password.Equals(""))
            {
                MessageBox.Show("Please input properply", "Add Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (!txtPassword.Password.Equals(txtConfirmPassword.Password))
            {
                MessageBox.Show("Password don`t match", "Add Failed", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                //for inserting in database
                String sql = "INSERT INTO tbl_admin(Username,Password) VALUES ('"+txtUsername.Text+"','"+txtPassword.Password+"')";
                ExecuteAddAdmin(sql,"Failed to Add Admin");
                //for recording in history
                var time = System.DateTime.Now.DayOfWeek.ToString() + " | " + DateTime.Now;
                getTime = time.ToString();
                String sql1 = "INSERT INTO tbl_history(Admin_ID,Activities,Date_Time) VALUES ('" + getter.getId + "','Added Admin with an ID of "+txtAdminId.Text+" ' ,'" + getTime + "')";
                ExecuteInsertHistory(sql1, "Failed to insert in tbl_history");

                Reset();
            }

        }
    }
}
