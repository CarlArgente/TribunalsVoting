using MySql.Data.MySqlClient;
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

namespace TribunalsVoting
{
    /// <summary>
    /// Interaction logic for StudentNumberForm.xaml
    /// </summary>
    public partial class StudentNumberForm : Window
    {
        public StudentNumberForm()
        {
            InitializeComponent();
        }
        private void txtStudentNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                try
                {
                    Byte hasVoted = 0;
                    getter.conn.Open();
                    MySqlCommand cmd = getter.conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM tbl_students WHERE student_number='" + txtStudentNumber.Text + "' ";
                    MySqlDataReader sqlDataReader = null;
                    sqlDataReader = cmd.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            hasVoted = sqlDataReader.GetByte("hasVoted");
                            getter.getProgram = sqlDataReader.GetString("program");
                        }

                        if(hasVoted == 0)
                        {
                            this.Hide();
                            new Ballot().Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Sorry you already voted", "Failed", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Please input properly your Student Number or ask the Electoral Tribunals", "Failed", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                    sqlDataReader.Close();
                    getter.conn.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Please input properly your Student Number or ask the Electoral Tribunals", "Failed", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                getter.conn.Close();
            }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new MainWindow().Show();
            this.Close();
        }
    }  
  
}
