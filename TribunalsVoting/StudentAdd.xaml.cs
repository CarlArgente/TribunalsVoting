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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TribunalsVoting
{
    /// <summary>
    /// Interaction logic for StudentAdd.xaml
    /// </summary>
    public partial class StudentAdd : UserControl
    {
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

        }
    }
}
