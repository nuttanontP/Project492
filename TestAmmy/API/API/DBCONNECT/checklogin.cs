using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace MODEL_2.Respository
{
    
    public class checklogin
    {
        DBConnect dbconnect = new DBConnect();

    public Boolean checklogins(string username, string password)
        {
            Boolean temp = false;
            string query = "select * from dbo_tb_username where dbo_tb_usernamecol = '" + username + "' and dbo_tb_usernamePW = '" + password+ "' ";
            if (dbconnect.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query,dbconnect.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    string x = dataReader["dbo_tb_usernameID"] +"";
                    temp = true;
                }
            }
           
            return temp;
        }
    }
}
