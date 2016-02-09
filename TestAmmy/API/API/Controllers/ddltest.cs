using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MODEL;
using MySql.Data.MySqlClient;
using System.Data;

namespace API.Controllers
{
    public class ddltest
    {
        DBConnect dbconnect = new DBConnect();
        public DataTable ddl(string company_code)
        {
            string query = "SELECT idBuilding,building_name  FROM energymanagementdb.building WHERE company_code = "+ company_code;
            DataTable dt = new DataTable();
            if (dbconnect.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, dbconnect.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                dt.Load(dataReader);
            }
                return dt;
        }
    }
}