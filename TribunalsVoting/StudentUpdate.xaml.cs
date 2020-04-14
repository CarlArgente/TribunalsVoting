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
    /// Interaction logic for StudentUpdate.xaml
    /// </summary>
    public partial class StudentUpdate : UserControl
    {
        String getTime,id,getName,getStudentNumber,getProgram;
        //Fixed Programs
        String[] program = new string[]
        {
            "BACOMM",
            "BMMA",
            "BSA",
            "BCPE",
            "BSCS",
            "BSHM",
            "BSIT",
            "BSMA",
            "BSTM"
        };
        //for updating table
        void UpdateTable()
        {
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT student_number AS 'Student Number', student_name AS 'Student Name', program AS 'Program' FROM tbl_students", getter.conn);
                getter.conn.Open();
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGrid1.ItemsSource = ds.Tables[0].DefaultView;
                getter.conn.Close();
            }
            catch (Exception e)
            {
               // MessageBox.Show(e.Message);
            }
        }
        void SetSizeColumns()
        {
            getter.conn.Close();
            dataGrid1.Columns[0].Width = 130;
            dataGrid1.Columns[1].Width = 300;
            dataGrid1.Columns[2].Width = 130;
         }
        void DisplayData(String id)
        {
            getter.conn.Close();
            getter.conn.Open();
            MySqlCommand cmd = getter.conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM tbl_students WHERE student_number='" + id + "' ";
            MySqlDataReader sqlDataReader = null;
            sqlDataReader = cmd.ExecuteReader();
            if (sqlDataReader.Read())
            {
                //for getting value
                getName = sqlDataReader["student_name"].ToString();
                getStudentNumber = sqlDataReader["student_number"].ToString();
                getProgram = sqlDataReader["program"].ToString();

                //for displaying
                txtStudentName.Text = getName;
                txtStudentNumber.Text = getStudentNumber;
                cmbProgram.SelectedItem = getProgram;
            }
            sqlDataReader.Close();
            getter.conn.Close();
        }
        void ExecuteUpdate(String query)
        {
         
            try
            {
                getter.conn.Close();
                getter.conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, getter.conn);
                if (cmd.ExecuteNonQuery() == 1)
                {
                  
                }
                else
                {
                    MessageBox.Show("error ka boi");
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

        public StudentUpdate()
        {
            InitializeComponent();
            AddItemInComboBox();

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
                    SetSizeColumns();
                }
                else
                {
                    getter.conn.Close();
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT student_number AS 'Student Number', student_name AS 'Student Name', program AS 'Program' FROM tbl_students WHERE student_number LIKE '" + txtSearch.Text + "%'  OR student_name LIKE '" + txtSearch.Text + "%' OR program LIKE '" + txtSearch.Text + "%' ", getter.conn);
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
               
            }
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
            if (txtStudentNumber.Text.Equals("") || txtStudentName.Text.Equals("") || cmbProgram.SelectedIndex == -1)
            {
                MessageBox.Show("Please input properly", "Failed", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                String sql = "UPDATE tbl_students SET student_number='" + txtStudentNumber.Text + "', student_name='" + txtStudentName.Text + "', program='" + cmbProgram.SelectedItem.ToString() + "' WHERE student_number='" + txtStudentNumber.Text + "' ";
                ExecuteUpdate(sql);
                //for inserting in history
                var time = System.DateTime.Now.DayOfWeek.ToString() + " | " + DateTime.Now;
                getTime = time.ToString();
                String sql1 = "INSERT INTO tbl_history(Admin_ID,Activities,Date_Time) VALUES ('" + getter.getId + "','Updated Student with an number of " + txtStudentNumber.Text + " ', '" + getTime + "')";
                ExecuteUpdate(sql1);

                MessageBox.Show("Successfully Updated Student", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                txtStudentName.Text = null;
                txtStudentNumber.Text = null;
                getter.conn.Close();
                UpdateTable();
            }
           
        }

        private void DataGrid1_Loaded(object sender, RoutedEventArgs e)
        {
            SetSizeColumns();
        }

        private void DataGrid1_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            //for displaying
            DataRowView dataRow = dataGrid1.SelectedItem as DataRowView;
            id = dataRow.Row[0].ToString();
            DisplayData(id);
            getter.conn.Close();
        }
    }
}
