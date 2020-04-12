using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace TribunalsVoting
{
    class getter
    {
        public static MySqlConnection conn = new MySqlConnection("server=localhost;database=voting_system;uid=root;pwd=;");
        public static int getId;
        public static String getUsername;
        public static String getTimeAndDate;       
    }

}
