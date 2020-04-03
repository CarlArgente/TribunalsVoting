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
                this.Hide();
                new Ballot().Show();
                this.Close();
            }
        }
    }  
  
}
