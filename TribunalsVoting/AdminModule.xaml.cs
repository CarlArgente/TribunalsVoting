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

        public void ClickedHome()
        {
            txtTitle.Text = "DashBoard";
            Navigation.Visibility = Visibility.Collapsed;
            GridPrincipal.Children.Clear();
            GridPrincipal.Children.Add(new DashBoard());
        }
        public void ClickedCandidates()
        {
            txtTitle.Text = "Candidates";
            Navigation.Visibility = Visibility.Visible;
            dashText1.Text = "List of Candidate";
            dashText2.Text = "Add Candidate";
            dashText3.Text = "Reset Candidate";
            dashDash1.Text = "|";
            dashDash2.Text = "|";
        }
        public void ClickedStudent()
        {
            txtTitle.Text = "Students";
            Navigation.Visibility = Visibility.Visible;
            dashText1.Text = "List of Student";
            dashText2.Text = "Add Student";
            dashText3.Text = "";
            dashDash1.Text = "|";
            dashDash2.Text = " ";
        }
        public void ClickedAdmin()
        {
            txtTitle.Text = "Admin";
            Navigation.Visibility = Visibility.Visible;
            dashText1.Text = "Admin Accounts";
            dashText2.Text = "Add Admin";
            dashText3.Text = "";
            dashDash1.Text = "|";
            dashDash2.Text = "";

        }
        public void ClickedRanking()
        {
            txtTitle.Text = "Ranking";
            Navigation.Visibility = Visibility.Visible;
            dashText1.Text = "Winners";
            dashText2.Text = "";
            dashText3.Text = "";
            dashDash1.Text = "";
            dashDash2.Text = "";
        }
        public void ClickedHistory()
        {
            txtTitle.Text = "History";
            Navigation.Visibility = Visibility.Visible;
            dashText1.Text = "Logs";
            dashText2.Text = "";
            dashText3.Text = "";
            dashDash1.Text = "";
            dashDash2.Text = "";
        }
    }
}
