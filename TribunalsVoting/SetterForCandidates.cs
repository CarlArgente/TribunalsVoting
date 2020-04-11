using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace TribunalsVoting
{
    class SetterForCandidates
    {
        public static List<int> listID = new List<int>();
        public static List<String> listName = new List<String>();
        public static List<String> listPartylist = new List<String>();
        public static List<String> listNickname = new List<String>();    
        public static List<String> listAchievement = new List<String>();
        public static List<String> listPlatform = new List<String>();
        static int newID, newID2;


        public static void getCandidateInfo(String text)
        {      
            getter.conn.Close();
            getter.conn.Open();
            MySqlCommand cmd = getter.conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM tbl_candidates WHERE Candidate_Position='"+ text + "' ";
            MySqlDataReader sqlDataReader = null;
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                listID.Add(Int32.Parse(sqlDataReader["Candidate_id"].ToString()));
                listName.Add(sqlDataReader["Candidate_Name"].ToString());
                listPartylist.Add(sqlDataReader["Candidate_Party"].ToString());
                listNickname.Add(sqlDataReader["Candidate_Nickname"].ToString());
            }
            sqlDataReader.Close();
            getter.conn.Close();
            //for loading achievement
            getter.conn.Open();
            MySqlCommand cmd1 = getter.conn.CreateCommand();
            cmd1.CommandType = CommandType.Text;           
            for (int x = 0; x < listID.Count; x++)
            {             
                cmd1.CommandText = "SELECT * FROM tbl_candidate_achievement WHERE Candidate_ID='" + listID[x] + "' ";
                MySqlDataReader sqlDataReader1 = null;
                sqlDataReader1 = cmd1.ExecuteReader();
                if (listID[x] != newID)
                {
                    while (sqlDataReader1.Read())
                    {
                        listAchievement.Add(sqlDataReader1["Achievement_title"].ToString());
                    }
                }
                listAchievement.Add("|");            
                newID = listID[x];                       
                sqlDataReader1.Close();
            }          
            getter.conn.Close();
            //for loading platform
            getter.conn.Open();
            MySqlCommand cmd2 = getter.conn.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            for (int x = 0; x < listID.Count; x++)
            {
                cmd2.CommandText = "SELECT * FROM tbl_candidate_platform WHERE Candidate_ID='" + listID[x] + "' ";
                MySqlDataReader sqlDataReader2 = null;
                sqlDataReader2 = cmd2.ExecuteReader();
                if (listID[x] != newID2)
                {
                    while (sqlDataReader2.Read())
                    {
                        listPlatform.Add(sqlDataReader2["platform"].ToString());
                    }
                }
                listPlatform.Add("|");
                newID2 = listID[x];
                sqlDataReader2.Close();
            }
            getter.conn.Close();
        }

    }
}
