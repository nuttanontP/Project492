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
    public class BuildingController : ApiController
    {
        DBConnect dbconnect = new DBConnect();
        public string gridbuilding()
        {
            string json =  null;
            DataTable dt = new DataTable();
            try
            {

                string query = "select * from energyver1.building";
                if (dbconnect.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, dbconnect.connection);
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
        public DataTable gridbuilding_dt()
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            string query = "select * from energyver1.building";
            if (dbconnect.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, dbconnect.connection);
                //MySqlDataReader dataReader = cmd.ExecuteReader();
                //dt.Load(dataReader);
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                
                //sda.SelectCommand = cmd;
                //DataSet ds = new DataSet();
                sda.Fill(ds);
                //dt.Load(dataReader);
            }
            dbconnect.CloseConnection();
            return dt;
        }
        public bool addbuilding(building model)
        {
            bool success = false;
            try
            {
                StringBuilder bd = new StringBuilder();
                bd.Append("insert into energyver1.building (`building_name`, `building_detail`, `company_companycode`) ");
                bd.Append("values('"+model.building_name+"','"+model.building_detail+"','"+model.company_companycode+"')");
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
        public string comp_code(string email)
        {
            string json = null;
            string comp_code = null;
            try
            {
                DataTable dt = new DataTable();
                StringBuilder bd = new StringBuilder();
                bd.Append("select * from energyver1.user where email='"+email+"'");
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
                    dynamic dynObj = JsonConvert.DeserializeObject(json);
                    comp_code = dynObj[0].company_companycode;
                }
            }
            catch { throw; }

            return comp_code;
        }
    }
}
