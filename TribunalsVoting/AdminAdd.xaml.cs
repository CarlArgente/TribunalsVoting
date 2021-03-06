﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using MySql.Data.MySqlClient;

namespace TribunalsVoting
{
    /// <summary>
    /// Interaction logic for AdminAdd.xaml
    /// </summary>
    public partial class AdminAdd : UserControl
    { 
        private String getTime;

        SimpleAES SAES;
        
        void ExecuteAddAdmin(String query, String errorMessage) 
        {
            try
            {

                getter.conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, getter.conn);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Successfully Added Admin", "Successfully Added", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show(errorMessage);
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
        void ExecuteInsertHistory(String query, String errorMessage)
        {
            try
            {

                getter.conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, getter.conn);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    //nothing to display
                }
                else
                {
                    MessageBox.Show(errorMessage);
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
        public void Reset()
        {
            txtUsername.Text = null;
            txtPassword.Password = null;
            txtConfirmPassword.Password = null;
            txtFullName.Text = null;
        }
        public AdminAdd()
        {
            InitializeComponent();
            SAES = new SimpleAES();
            //GettingMaxID();
            //DisplayMaxID();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var regexItem = new Regex("^[a-zA-Z0-9 ]*$");

            if (txtUsername.Text.Equals("") || txtPassword.Password.Equals("") || txtConfirmPassword.Password.Equals(""))
            {
                MessageBox.Show("Please input properply", "Add Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (!txtPassword.Password.Equals(txtConfirmPassword.Password))
            {
                MessageBox.Show("Password don`t match", "Add Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (!regexItem.IsMatch(txtUsername.Text) || !regexItem.IsMatch(txtPassword.Password))
            {
                MessageBox.Show("Symbols are not allowed.", "Add Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                //for inserting in database
                String sql = "INSERT INTO tbl_admin(Full_Name,Username,Password) VALUES ('"+ txtFullName.Text + "','"+ txtUsername.Text +"','"+ SAES.Encrypt(txtPassword.Password) +"')";
                ExecuteAddAdmin(sql,"Failed to Add Admin");
                //for recording in history
                var time = System.DateTime.Now.DayOfWeek.ToString() + " | " + DateTime.Now;
                getTime = time.ToString();
                String sql1 = "INSERT INTO tbl_history(Admin_ID,Activities,Date_Time) VALUES ('" + getter.getId + "', CONCAT('Added Admin with an ID of ', (SELECT MAX(Candidate_id)FROM tbl_candidates)) , '" + getTime + "')";
                ExecuteInsertHistory(sql1, "Failed to insert in tbl_history");

                Reset();
            }

        }
    }
}
