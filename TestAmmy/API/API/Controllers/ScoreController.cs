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
    public class ScoreController : ApiController
    {
        DBConnect dbconnect = new DBConnect();
        //public String get()
        //{
        //    string json = "";
        //    DataTable dt = new DataTable();
        //    String query = "select * from energyver1.user";
        //    if (dbconnect.OpenConnection() == true)
        //    {
        //        MySqlCommand cmd = new MySqlCommand(query, dbconnect.connection);
        //        MySqlDataReader dataReader = cmd.ExecuteReader();
        //        dt.Load(dataReader);

        //        json = JsonConvert.SerializeObject(dt);
        //        return json;
        //    }
        //    return json;
        //    //return "ddvdv";
        //}
        public IHttpActionResult get()
        {
            string json = "testtest";
            
            // year ye2 = new year {idYear = 1,Year1= "2015" };
            // json = JsonConvert.SerializeObject(ye2);
            return Ok(json);
        }
        public Boolean checklogins(string username, string password)
        {
            Boolean temp = false;
            string query = "select * from energymanagementdb.user where email = '" + username + "' and password = '" + password + "' ";
            if (dbconnect.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, dbconnect.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    string x = dataReader["email"] + "";
                    temp = true;
                }
            }

            return temp;
        }

        public string getUserData(string email)
        {
            DataTable dt = new DataTable();
            string json = "";
            string query = "select * from energymanagementdb.user where email = '" + email + "' ";
            if (dbconnect.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, dbconnect.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                dt.Load(dataReader);

                json = JsonConvert.SerializeObject(dt);
                
                return json;
                
            }
            return json;
        }
        public Boolean InsertPowerElectric(List<int> energy)
        {
            Boolean temp = false;
            String values="";
            foreach(int item in energy)
            {
                if(item == energy.Last())
                {
                    values += "(" + item + ")";
                }
                else
                {
                    values += "(" + item + "),";
                }
                
            }
            string query = "INSERT INTO mydb2.electrical_db (power) VALUES" + values;
            if (dbconnect.OpenConnection() == true)
            {
                try
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, dbconnect.connection);

                    //Execute command
                    cmd.ExecuteNonQuery();

                    //close connection
                    dbconnect.CloseConnection();
                    temp = true;
                }
                catch
                {
                   // throw;
                    temp = false;
                }
                
                
            }
            return temp;
        }
        //public Boolean InsertUser(user model)
        //{
        //    Boolean temp = false;
        //    String values = "(" + "'" + model.email + "'" + "," + "'" + model.name + "'" + "," + "'" + model.surname + "'" + "," + "'" + model.password + "'" + "," + "'" + model.company + "'" + "," + "'" + model.position + "'" + ")";

        //    string query = "INSERT INTO energymanagementdb.user (`email`, `name`, `surname`, `password`, `company`, `position`) VALUES" + values;
        //    if (dbconnect.OpenConnection() == true)
        //    {
        //        try
        //        {
        //            //create command and assign the query and connection from the constructor
        //            MySqlCommand cmd = new MySqlCommand(query, dbconnect.connection);

        //            //Execute command
        //            cmd.ExecuteNonQuery();

        //            //close connection
        //            dbconnect.CloseConnection();
        //            temp = true;
        //        }
        //        catch
        //        {
        //            // throw;
        //            temp = false;
        //        }


        //    }
        //    return temp;
        //}
        public string getEnergyData()
        {
            DataTable dt = new DataTable();
            string json = "";
            string query = "SELECT power FROM mydb2.electrical_db ORDER BY power DESC limit 6";
            if (dbconnect.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, dbconnect.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                dt.Load(dataReader);

                json = JsonConvert.SerializeObject(dt);

                return json;

            }
            return json;
        }


    }
}
