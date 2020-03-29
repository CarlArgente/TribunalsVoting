using System;
using System.Collections.Generic;
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
        MySqlConnection conn;

        public Login()
        {
            InitializeComponent();        
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string connetionString = "server=localhost;database=db_tribunals;uid=root;pwd=;";
            conn = new MySqlConnection(connetionString);

            conn.Open();
            using (conn)
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM tbl_admin WHERE Username ='" + txtUsername.Text + "' AND Password='" + txtPassword.Password + "'", conn);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        MessageBox.Show("Greetings!, Admin", "Login Successful", MessageBoxButton.OK, MessageBoxImage.Information);

                        this.Hide();
                        new AdminModule().Show();
                        this.Close();
                    }
                    reader.Close();
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
