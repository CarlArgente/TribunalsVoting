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
    /// Interaction logic for StudentDelete.xaml
    /// </summary>
    public partial class StudentDelete : UserControl
    {
        String id,getTime,getStudentNumber;
        //for updating table
        void UpdateTable()
        {
            try
            {
                getter.conn.Close();
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT student_number AS 'Student Number', student_name AS 'Student Name', program AS 'Program', hasVoted AS 'Has Voted' FROM tbl_students", getter.conn);
                getter.conn.Open();
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGrid1.ItemsSource = ds.Tables[0].DefaultView;
                getter.conn.Close();
            }
            catch (Exception e)
            {
             
            }
        }
        void SetSizeColumns()
        {
            getter.conn.Close();
            dataGrid1.Columns[0].Width = 130;
            dataGrid1.Columns[1].Width = 300;
            dataGrid1.Columns[2].Width = 130;
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
                getStudentNumber = sqlDataReader["student_number"].ToString();
                //for displaying        
                txtStudentNumber.Text = getStudentNumber;       
            }
            sqlDataReader.Close();
            getter.conn.Close();
        }
        void ExecuteDelete(String query)
        {
            try
            {

                getter.conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, getter.conn);
                if (cmd.ExecuteNonQuery() == 1)
                {
                }
                else
                {
                    MessageBox.Show("error ka nanaman boi");
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("tanga");
            }
            finally
            {
                getter.conn.Close();
            }
        }
        public StudentDelete()
        {
            InitializeComponent();
            UpdateTable();
        }

        private void DataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Click_Delete(object sender, RoutedEventArgs e)
        {
            if (txtStudentNumber.Text.Equals(""))
            {
                MessageBox.Show("Please input properly", "Failed", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
            else
            {
                String sql = "DELETE FROM tbl_students WHERE student_number='" + txtStudentNumber.Text + "' ";
                ExecuteDelete(sql);

                //for inserting in history
                var time = System.DateTime.Now.DayOfWeek.ToString() + " | " + DateTime.Now;
                getTime = time.ToString();
                String sql1 = "INSERT INTO tbl_history(Admin_ID,Activities,Date_Time) VALUES ('" + getter.getId + "','Deleted Student with an number of " + txtStudentNumber.Text + " ', '" + getTime + "')";
                ExecuteDelete(sql1);

                MessageBox.Show("Successfully Deleted Student", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                txtStudentNumber.Text = null;
                id = null;
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
