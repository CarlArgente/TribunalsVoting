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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();        
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new AdminModule().Show();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove(); 
            }
        }

        private void txtUsername_GotFocus(object sender, RoutedEventArgs e)
        {
          
        }

        private void txtUsername_LostFocus(object sender, RoutedEventArgs e)
        {
          
        }

        private void txtPassword_GotFocus(object sender, RoutedEventArgs e)
        {

        }
    }
}
