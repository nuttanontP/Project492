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

namespace API.Controllers
{
    public class companyController : ApiController
    {
        DBConnect dbconnect = new DBConnect();
        public string addnewcomp(string namecomp)
        {
           //bool success = false;
            string json = null;
            try
            {
                StringBuilder bd = new StringBuilder();
                bd.Append("insert into energyver1.company (company_name) values('" + namecomp + "')");
                if (dbconnect.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(bd.ToString(), dbconnect.connection);
                    cmd.ExecuteNonQuery();
                    dbconnect.CloseConnection();
                    //success = true;
                }
                if (dbconnect.OpenConnection())
                {
                    DataTable dt = new DataTable();
                    bd = new StringBuilder();
                    bd.Clear();
                    bd.Append("select companycode from energyver1.company where company_name ='"+namecomp+"'");
                    MySqlCommand cmd = new MySqlCommand(bd.ToString(), dbconnect.connection);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        dt.Load(dataReader);
                        //user_id = dataReader["idUser"] + "";
                        json = JsonConvert.SerializeObject(dt);

                    }
                    dbconnect.CloseConnection();
                    //success = true;
                }
            }
            catch { throw; }
            return json;

        }
    }
}
