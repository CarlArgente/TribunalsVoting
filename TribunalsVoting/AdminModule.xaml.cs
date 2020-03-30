﻿using System;
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
    /// Interaction logic for AdminModule.xaml
    /// </summary>
    public partial class AdminModule : Window
    {
        public AdminModule()
        {
            InitializeComponent();
            Navigation.Visibility = Visibility.Collapsed;
            GridPrincipal.Children.Clear();
            GridPrincipal.Children.Add(new DashBoard());
        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {
            //Event for Dashboard
            ClickedHome();
        }

        private void ListViewItem_Selected_1(object sender, RoutedEventArgs e)
        {
            //Event for Candidates
            ClickedCandidates();
        }

        private void ListViewItem_Selected_2(object sender, RoutedEventArgs e)
        {
            //Event for Students
            ClickedStudent();
        }

        private void ListViewItem_Selected_3(object sender, RoutedEventArgs e)
        {
            //Event for Admin
            ClickedAdmin();
        }

        private void ListViewItem_Selected_4(object sender, RoutedEventArgs e)
        {
            //Event for Ranking
            ClickedRanking();
        }

        private void ListViewItem_Selected_5(object sender, RoutedEventArgs e)
        {
            //Event for History
            ClickedHistory();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Quit");
        }
        //Event for navigations
        private void nav1_mouseDown(object sender, MouseButtonEventArgs e)
        {
            Nav1Clicked();
        }
        private void nav2_mouseDown(object sender, MouseButtonEventArgs e)
        {
            Nav2Clicked();
        }
        private void nav3_mouseDown(object sender, MouseButtonEventArgs e)
        {
            Nav3Clicked();
        }
        private void nav4_mouseDown(object sender, MouseButtonEventArgs e)
        {
            Nav4Clicked();
        }

        //For clicking Home
        public void ClickedHome()
        {
            txtTitle.Text = "DashBoard";
            Navigation.Visibility = Visibility.Collapsed;
            GridPrincipal.Children.Clear();
            GridPrincipal.Children.Add(new DashBoard());
        }
        //For clicking Candidates
        public void ClickedCandidates()
        {
            txtTitle.Text = "Candidates";
            Navigation.Visibility = Visibility.Visible;
            dashText1.Text = "List of Candidate";
            dashText2.Text = "Add Candidate";
            dashText3.Text = "Update Candidate";
            dashText4.Text = "Delete Candidate";
            dashDash1.Text = "|";
            dashDash2.Text = "|";
            dashDash3.Text = "|";

            GridPrincipal.Children.Clear();
            GridPrincipal.Children.Add(new Candidates());
        }
        //For clicking Student
        public void ClickedStudent()
        {
            txtTitle.Text = "Students";
            Navigation.Visibility = Visibility.Visible;
            dashText1.Text = "List of Student";
            dashText2.Text = "Add Student";
            dashText3.Text = "";
            dashText4.Text = "";
            dashDash1.Text = "|";
            dashDash2.Text = " ";
            dashDash3.Text = " ";
        }
        //For clicking Admin
        public void ClickedAdmin()
        {
            txtTitle.Text = "Admin";
            Navigation.Visibility = Visibility.Visible;
            dashText1.Text = "Admin Accounts";
            dashText2.Text = "Add Admin";
            dashText3.Text = "Update Admin";
            dashText4.Text = "Delete Admin";
            dashDash1.Text = "|";
            dashDash2.Text = "|";
            dashDash3.Text = "|";

        }
        //For clicking Ranking
        public void ClickedRanking()
        {
            txtTitle.Text = "Ranking";
            Navigation.Visibility = Visibility.Visible;
            dashText1.Text = "Winners";
            dashText2.Text = "";
            dashText3.Text = "";
            dashText4.Text = "";
            dashDash1.Text = "";
            dashDash2.Text = "";
            dashDash3.Text = "";

        }
        //For clicking History
        public void ClickedHistory()
        {
            txtTitle.Text = "History";
            Navigation.Visibility = Visibility.Visible;
            dashText1.Text = "Admin Logs";
            dashText2.Text = "Student Logs";
            dashText3.Text = "";
            dashText4.Text = "";
            dashDash1.Text = "|";
            dashDash2.Text = "";
            dashDash3.Text = "";

            GridPrincipal.Children.Clear();
            GridPrincipal.Children.Add(new Logs());
        }
        //For clicking NavigationBar1
        public void Nav1Clicked()
        {
            if(dashText1.Text.Equals("List of Candidate"))
            {
               
                GridPrincipal.Children.Clear();
                GridPrincipal.Children.Add(new Candidates());
            }
            if (dashText1.Text.Equals("Admin Accounts"))
            {
               
                MessageBox.Show("Admin");
            }
            if (dashText1.Text.Equals("List of Student"))
            {
              
                MessageBox.Show("Student");
            }
            if (dashText1.Text.Equals("Winners"))
            {
               
                MessageBox.Show("Winners");
            }
            if (dashText1.Text.Equals("Admin Logs"))
            {
              
                GridPrincipal.Children.Clear();
                GridPrincipal.Children.Add(new Logs());
            }
        }
        //For clicking NavigationBar2
        public void Nav2Clicked()
        {
            if (dashText2.Text.Equals("Add Candidate"))
            {          
                GridPrincipal.Children.Clear();
                GridPrincipal.Children.Add(new CandidateAdd());
            }
            if (dashText2.Text.Equals("Add Student"))
            {
                MessageBox.Show("Add Student");
            }
            if (dashText2.Text.Equals("Add Admin"))
            {
                MessageBox.Show("Add Admin");
            }

            if (dashText2.Text.Equals("Student Logs"))
            {
                MessageBox.Show("Student Logs");
            }
        }
        //For clicking NavigationBar3
        public void Nav3Clicked()
        {
            if (dashText3.Text.Equals("Update Admin"))
            {
                MessageBox.Show("Update Admin");
              
            }

            if (dashText3.Text.Equals("Update Candidate"))
            {
                GridPrincipal.Children.Clear();
                GridPrincipal.Children.Add(new CandidateUpdate());
            }
        }
        //For clicking NavigationBar4
        public void Nav4Clicked()
        {
            if (dashText4.Text.Equals("Delete Admin"))
            {
                MessageBox.Show("Delete Admin");
            }

            if (dashText4.Text.Equals("Delete Candidate"))
            {
                GridPrincipal.Children.Clear();
                GridPrincipal.Children.Add(new CandidateDelete());
            }
        }

    }
}
