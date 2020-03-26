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
            GridPrincipal.Children.Clear();
            GridPrincipal.Children.Add(new DashBoard());
        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {
            GridPrincipal.Children.Clear();
            GridPrincipal.Children.Add(new DashBoard());
        }
    }
}
