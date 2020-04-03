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
        public Ballot()
        {
            InitializeComponent();
            NavTextPresident.FontFamily = new FontFamily("Segoe UI Semibold");
            GridPrincipal.Children.Add(new PositionPresident());
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

            //depende on program of student 
            /*
             * if(ICT Student)
             *      Go to ICT Representative Form
             * if(Engineering Student)
             *      Go to Engineering Form
             * */

            GridPrincipal.Children.Clear();
            GridPrincipal.Children.Add(new PositionICTRepresentative());

        }
    }
}
