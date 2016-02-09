using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data;
using Newtonsoft.Json;
using System.Web.Http;
using MySql.Data.MySqlClient;
using System.Text;
using MODEL;


namespace API.Controllers
{
    public class userController : ApiController
    {
        DBConnect dbconnect = new DBConnect();
        myfunctionController k = new myfunctionController();
        public bool addpeople(user model,int status)
        {
            bool success = false;
            try
            {
                StringBuilder bd = new StringBuilder();
                bd.Append("insert into energyver1.user ");
                bd.Append("(`email`, `password`, `first_name`, `last_name`, `status`, `company_companycode`) ");
                bd.Append("values ("+k.k(model.email)+","+ k.k(model.password) + "," + k.k(model.first_name) + ",");
                bd.Append(k.k(model.last_name) + "," + status + "," + k.k(model.company_companycode) + ")");
                if (dbconnect.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(bd.ToString(), dbconnect.connection);
                    cmd.ExecuteNonQuery();
                    dbconnect.CloseConnection();
                    success = true;
                }
            }
            catch { throw; }
            return success;

        }
        public bool checklogin(string username , string password)
        {
            bool success = false;
            try
            {
                StringBuilder bd = new StringBuilder();
                bd.Append("select * from energyver1.user ");
                bd.Append("where email='" + username + "' and password='" + password + "'");
                if (dbconnect.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(bd.ToString(), dbconnect.connection);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        success = true;
                    }
                }
                dbconnect.CloseConnection();
            }
            catch { throw; }
            return success;
        }
        public string datauser(string username, string password)
        {
            string json = null;
            try
            {
                DataTable dt = new DataTable();
                StringBuilder bd = new StringBuilder();
                bd.Append("select * from energyver1.user ");
                bd.Append("where email='" + username + "' and password='" + password + "'");
                if (dbconnect.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(bd.ToString(), dbconnect.connection);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        dt.Load(dataReader);
                        json = JsonConvert.SerializeObject(dt);
                    }
                    dbconnect.CloseConnection();
                }
            }
            catch { throw; }
            return json;
        }
    }
}
