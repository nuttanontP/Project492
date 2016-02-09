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
            StringBuilder bd = new StringBuilder();
            bd.Append("select * from energyver1.user ");
            bd.Append("where email='" + username + "' and password='"+password+"'");
          //  string query = "select * from energyver1.user where idUser = '" + username + "' and password = '" + password+ "' ";
            if (dbconnect.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(bd.ToString(),dbconnect.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    string x = dataReader["idUser"] +"";
                    temp = true;
                }
            }
           
            return temp;
        }
    }
}
