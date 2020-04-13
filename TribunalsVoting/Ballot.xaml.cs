using MySql.Data.MySqlClient;
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

namespace TribunalsVoting
{
    /// <summary>
    /// Interaction logic for Ballot.xaml
    /// </summary>
    public partial class Ballot : Window
    {
        List<String> listVotedNames = new List<String>();
        List<int> listIDVoted = new List<int>();

        String[] programs = { "BSIT", "BSCS", "BACOMM", "BMMA", "BSA", "BSMA", "BSCPE", "BSHM", "BSTM" };
        String getTime;
        public Ballot()
        {
            InitializeComponent();

            txtPresident.Text = "";
            txtVPAcademicAffair.Text = "";
            txtVPExternalAffair.Text = "";
            txtVPInternalAffair.Text = "";
            txtVPOperation.Text = "";
            txtVPFinance.Text = "";
            txtRepresentative.Text = "";
          

            NavTextPresident.FontFamily = new FontFamily("Segoe UI Semibold");
            GridPrincipal.Children.Add(new PositionPresident());           
        }
        void executeQuery(String query)
        {
            try
            {
                getter.conn.Close();
                getter.conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, getter.conn);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    //nothing do display                 
                }
                else
                {
                    MessageBox.Show("burat");
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
        //for getting ID of voted Candidate
        void getId()
        {
            getter.conn.Open();
            for(int x = 0; x < listVotedNames.Count; x++)
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tbl_candidates WHERE Candidate_Name='" + listVotedNames[x] + "' ", getter.conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listIDVoted.Add(Int32.Parse(reader["Candidate_id"].ToString()));                
                }
                reader.Close();
            }
            getter.conn.Close();
        }
        void SubmitVoteUpdate()
        {
            try
            {
                if (txtPresident.Text.Equals("") || txtVPAcademicAffair.Text.Equals("") || txtVPExternalAffair.Text.Equals("") || txtVPInternalAffair.Text.Equals("") || txtVPOperation.Text.Equals("") || txtVPFinance.Text.Equals("") ||
                    txtRepresentative.Text.Equals(""))
                {
                    MessageBox.Show("Please Vote for every position!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    listVotedNames.Add(txtPresident.Text);
                    listVotedNames.Add(txtVPAcademicAffair.Text);
                    listVotedNames.Add(txtVPExternalAffair.Text);
                    listVotedNames.Add(txtVPInternalAffair.Text);
                    listVotedNames.Add(txtVPOperation.Text);
                    listVotedNames.Add(txtVPFinance.Text);
                    listVotedNames.Add(txtRepresentative.Text);
                    getId();
                    for (int x = 0; x < listVotedNames.Count; x++)
                    {
                        getter.conn.Open();
                        String sql = "UPDATE tbl_votes SET  Number_Of_Votes = Number_Of_Votes + 1 WHERE CANDIDATE_ID = '"+listIDVoted[x]+"' ";
                        executeQuery(sql);                    
                    }
                    String sql1 = "UPDATE tbl_students SET hasVoted = 1  WHERE student_number='"+getter.getStudentNumber+"' ";
                    executeQuery(sql1);
                    //for inserting in historyLog
                    var time = System.DateTime.Now.DayOfWeek.ToString() + " | " + DateTime.Now;
                    String getComputerName = System.Environment.MachineName;
                    getTime = time.ToString();
                    getter.getTimeAndDate = getTime;
                    String sql2 = "INSERT INTO tbl_vote_logs(Student_Number,Computer_Name,Date_Time) VALUES ('" + getter.getStudentNumber + "','" + getComputerName + "','" + getter.getTimeAndDate + "')";
                    executeQuery(sql2);

                    MessageBox.Show("Thank you for your cooperation!");
                    this.Hide();
                    new StudentNumberForm().Show();
                    this.Close();
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GridPrincipal.Children.Clear();
            GridPrincipal.Children.Add(new PositionPresident());        
        }

        private void NavTextPresident_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavTextPresident.FontFamily = new FontFamily("Segoe UI Semibold");
            NavTextAcademicAffair.FontFamily = NavTextExternalAffair.FontFamily = NavTextInternalAffair.FontFamily = NavTextOperation.FontFamily = NavTextFinance.FontFamily = NavTextProgram.FontFamily = new FontFamily("Segoe UI Semilight");

            GridPrincipal.Children.Clear();
            GridPrincipal.Children.Add(new PositionPresident());
        }

        private void NavTextAcademicAffair_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavTextAcademicAffair.FontFamily = new FontFamily("Segoe UI Semibold");
            NavTextPresident.FontFamily = NavTextExternalAffair.FontFamily = NavTextInternalAffair.FontFamily = NavTextOperation.FontFamily = NavTextFinance.FontFamily = NavTextProgram.FontFamily = new FontFamily("Segoe UI Semilight");

            GridPrincipal.Children.Clear();
            GridPrincipal.Children.Add(new PositionVPAcadamicAffair());
        }

        private void NavTextExternalAffair_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavTextExternalAffair.FontFamily = new FontFamily("Segoe UI Semibold");
            NavTextPresident.FontFamily = NavTextAcademicAffair.FontFamily = NavTextInternalAffair.FontFamily = NavTextOperation.FontFamily = NavTextFinance.FontFamily = NavTextProgram.FontFamily = new FontFamily("Segoe UI Semilight");

            GridPrincipal.Children.Clear();
            GridPrincipal.Children.Add(new PositionVPExternalAffair());
        }

        private void NavTextInternalAffair_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavTextInternalAffair.FontFamily = new FontFamily("Segoe UI Semibold");
            NavTextPresident.FontFamily = NavTextAcademicAffair.FontFamily = NavTextExternalAffair.FontFamily = NavTextOperation.FontFamily = NavTextFinance.FontFamily = NavTextProgram.FontFamily = new FontFamily("Segoe UI Semilight");

            GridPrincipal.Children.Clear();
            GridPrincipal.Children.Add(new PositionVPInternalAffair());
        }

        private void NavTextOperation_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavTextOperation.FontFamily = new FontFamily("Segoe UI Semibold");
            NavTextPresident.FontFamily = NavTextAcademicAffair.FontFamily = NavTextExternalAffair.FontFamily = NavTextInternalAffair.FontFamily = NavTextFinance.FontFamily = NavTextProgram.FontFamily = new FontFamily("Segoe UI Semilight");

            GridPrincipal.Children.Clear();
            GridPrincipal.Children.Add(new PositionOperation());
        }

        private void NavTextFinance_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavTextFinance.FontFamily = new FontFamily("Segoe UI Semibold");
            NavTextPresident.FontFamily = NavTextAcademicAffair.FontFamily = NavTextExternalAffair.FontFamily = NavTextInternalAffair.FontFamily = NavTextOperation.FontFamily = NavTextProgram.FontFamily = new FontFamily("Segoe UI Semilight");

            GridPrincipal.Children.Clear();
            GridPrincipal.Children.Add(new PositionFinance());
        }

        private void NavTextProgram_MouseDown(object sender, MouseButtonEventArgs e)
        {     
            NavTextProgram.FontFamily = new FontFamily("Segoe UI Semibold");
            NavTextPresident.FontFamily = NavTextAcademicAffair.FontFamily = NavTextExternalAffair.FontFamily = NavTextInternalAffair.FontFamily = NavTextOperation.FontFamily = NavTextFinance.FontFamily = new FontFamily("Segoe UI Semilight");

            if (getter.getProgram.Equals(programs[0]) || getter.getProgram.Equals(programs[1]))
            {
                //for ICT representative
                GridPrincipal.Children.Clear();
                GridPrincipal.Children.Add(new PositionICTRepresentative());
            }
            else if (getter.getProgram.Equals(programs[2]) || getter.getProgram.Equals(programs[3]))
            {
                //for arts and science representative
                GridPrincipal.Children.Clear();
                GridPrincipal.Children.Add(new PositionArtsScienceRepresentative());
            }
            else if (getter.getProgram.Equals(programs[4]) || getter.getProgram.Equals(programs[5]))
            {
                //for ABM representative
                GridPrincipal.Children.Clear();
                GridPrincipal.Children.Add(new PositionABMRepresentative());
            }
            else if (getter.getProgram.Equals(programs[6]))
            {
                //for engineering representatative
                GridPrincipal.Children.Clear();
                GridPrincipal.Children.Add(new PositionEngineeringRepresentative());
            }
            else if (getter.getProgram.Equals(programs[7]) || getter.getProgram.Equals(programs[8]))
            {
                GridPrincipal.Children.Clear();
                GridPrincipal.Children.Add(new PositionTourismHospitalityRepresentative());
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SubmitVoteUpdate();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new StudentNumberForm().Show();
            this.Close();
        }
    }
}
