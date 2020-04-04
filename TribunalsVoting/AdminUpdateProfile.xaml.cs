using System;
using System.Collections.Generic;
using System.Data;
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
using MySql.Data.MySqlClient;

namespace TribunalsVoting
{
    /// <summary>
    /// Interaction logic for AdminUpdateProfile.xaml
    /// </summary>
    public partial class AdminUpdateProfile : UserControl
    {
        String getUsername;
        int getAdminID;
        void GetProfile()
        {
            getter.conn.Open();
            MySqlCommand cmd = getter.conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM tbl_admin WHERE Admin_ID='"+getter.getId+"' ";
            MySqlDataReader sqlDataReader = null;
            sqlDataReader = cmd.ExecuteReader();
            if (sqlDataReader.Read())
            {
                //for getting value
                getUsername = sqlDataReader["Username"].ToString();
                getAdminID = Int32.Parse(sqlDataReader["Admin_ID"].ToString());
                //for setting value
                txtId.Text = getAdminID.ToString();
                txtUsername.Text = getUsername;
            }

            getter.conn.Close();
        }
        public AdminUpdateProfile()
        {
            InitializeComponent();
            GetProfile();
        }
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {           
            new AdminChangePass().Close();
            new AdminChangePass().Show();
        }
       
     
    }
}
