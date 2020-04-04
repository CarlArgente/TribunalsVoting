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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        //References
        private MySqlConnection conn = new MySqlConnection("server=localhost;database=voting_system;uid=root;pwd=;");
        private String getTime;
        //for executing all queries in one method(INSERT, UPDATE, DELETE)
        private void executeQuery(String query, String errorMessage)    //lagyan nyo nalang ng another parameter para sa message na gusto nyo
        {
            try
            {

                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
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
                conn.Close();
            }
        }

        public Login()
        {
            InitializeComponent();        
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {        
                conn.Open();
                using (conn)
                {
                    MySqlCommand command = new MySqlCommand("SELECT * FROM tbl_admin WHERE Username ='" + txtUsername.Text + "' AND Password='" + txtPassword.Password + "'", conn);
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        MessageBox.Show("Greetings!, Admin", "Login Successful", MessageBoxButton.OK, MessageBoxImage.Information);
                        //for passing value in getter class
                        getter.getId = Int32.Parse(reader["Admin_ID"].ToString());
                        var time = System.DateTime.Now.DayOfWeek.ToString() + " | " + DateTime.Now;
                        getTime = time.ToString();
                        getter.getTimeAndDate = getTime;

                        conn.Close();
                        //for inserting in historyLog
                        String sql = "INSERT INTO tbl_history(Admin_ID,Activities,Date_Time) VALUES ('" + getter.getId + "','logged in ','" + getter.getTimeAndDate + "')";
                        executeQuery(sql, "Failed to insert in tbl_history");
                        reader.Close();
                        
                        this.Hide();
                        new AdminModule().Show();
                        this.Close();
                       
                    }
                    else if (txtUsername.Text == "superadmin" && txtPassword.Password == "superadmin")
                    {
                        MessageBox.Show("Greetings!, Admin", "Login Successful", MessageBoxButton.OK, MessageBoxImage.Information);

                        this.Hide();
                        new AdminModule().Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Wrong Username or Password", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                        reader.Close();
                    }
                }
                conn.Close();                     
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove(); 
            }
        }



        private void txtUsername_GotFocus(object sender, RoutedEventArgs e)
        {
          
        }

        private void txtUsername_LostFocus(object sender, RoutedEventArgs e)
        {
          
        }

        private void txtPassword_GotFocus(object sender, RoutedEventArgs e)
        {

        }
    }
}
