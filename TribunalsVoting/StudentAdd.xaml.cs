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
    /// Interaction logic for StudentAdd.xaml
    /// </summary>
    public partial class StudentAdd : UserControl
    {
        private String getTime;

        //Fixed Programs
        String[] program = new string[]
        {
            "BACOMM",
            "BMMA",
            "BSA",
            "BSCPE",
            "BSCS",
            "BSHM",
            "BSIT",
            "BSMA",
            "BSTM"
        };
        void ExecuteInsertQuery(String query)
        {
            try
            {
                getter.conn.Close();
                getter.conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, getter.conn);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    //Nothing to display
                    getter.conn.Close();
                }
                else
                {
                  
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

        void InsertStudent()
        {
            if (txtStudentNumber.Text.Equals("") || txtStudentName.Text.Equals("") || cmbProgram.SelectedIndex == -1)
            {
                MessageBox.Show("Please input properly", "Failed", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                try
                {
 
                    getter.conn.Open();
                    MySqlCommand cmd = getter.conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select * from tbl_students where student_number = '" + txtStudentNumber.Text + "' ";
                    MySqlDataReader sqlDataReader = null;
                    sqlDataReader = cmd.ExecuteReader();
                    if (!sqlDataReader.HasRows)
                    {
                        String sql = "INSERT INTO tbl_students VALUES('', '"+txtStudentNumber.Text+"','"+txtStudentName.Text+"','"+cmbProgram.SelectedItem.ToString()+"', 0) ";
                        ExecuteInsertQuery(sql);
                        //for inserting in history
                        var time = System.DateTime.Now.DayOfWeek.ToString() + " | " + DateTime.Now;
                        getTime = time.ToString();
                        String sql1 = "INSERT INTO tbl_history(Admin_ID,Activities,Date_Time) VALUES ('" + getter.getId + "','Added Student with an number of "+txtStudentNumber.Text+" ', '" + getTime + "')";
                        ExecuteInsertQuery(sql1);

                        txtStudentNumber.Text = null;
                        txtStudentName.Text = null;
                        cmbProgram.SelectedItem = null;

                        MessageBox.Show("Successfully Added Student", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                    else
                    {
                        MessageBox.Show("The Student Number already Used", "Failed", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                    sqlDataReader.Close();
                    getter.conn.Close();
                } catch (Exception e) {
                    MessageBox.Show(e.Message);
                }
            }
        }
        public StudentAdd()
        {
            InitializeComponent();
            AddItemInComboBox();
        }
        //for adding items in combobox
        public void AddItemInComboBox()
        {
            foreach (String s in program)
            {
                cmbProgram.Items.Add(s);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            InsertStudent();
        }
    }
}
