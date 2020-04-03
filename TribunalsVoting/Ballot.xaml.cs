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

            GridPrincipal.Children.Clear();
            GridPrincipal.Children.Add(new PositionPresident());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //for back

            GridPrincipal.Children.Clear();
            GridPrincipal.Children.Add(new PositionPresident());
        }
    }
}
