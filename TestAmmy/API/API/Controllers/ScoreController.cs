using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//using MODEL;
using MySql.Data.MySqlClient;
using System.Data;
namespace API.Controllers
{
    public class ScoreController : ApiController
    {
        DBConnect dbconnect = new DBConnect();
        public String get()
        {
            string json = "";
            DataTable dt = new DataTable();
            String query = "select * from mydb2.electrical_db ";
            if(dbconnect.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, dbconnect.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                dt.Load(dataReader);
                
                json = JsonConvert.SerializeObject(dt);
                return json;
            }
            return json;
            //return "ddvdv";
        }
        public IHttpActionResult getdv(int id,String x)
        {
            string json = "";
            json = id + x;
           // year ye2 = new year {idYear = 1,Year1= "2015" };
          // json = JsonConvert.SerializeObject(ye2);
            return Ok(json);
        }
        public Boolean checklogins(string username, string password)
        {
            Boolean temp = false;
            string query = "select * from dbo_tb_username where dbo_tb_usernamecol = '" + username + "' and dbo_tb_usernamePW = '" + password + "' ";
            if (dbconnect.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, dbconnect.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    string x = dataReader["dbo_tb_usernameID"] + "";
                    temp = true;
                }
            }

            return temp;
        }




    }
}
