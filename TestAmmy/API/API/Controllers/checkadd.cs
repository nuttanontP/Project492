using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MODEL;
using MySql.Data.MySqlClient;
using System.Data;


namespace API.Controllers
{
    public class checkadd
    {
        DBConnect dbconnect = new DBConnect();
        public bool addpermision(string email,string company_code,string building,string energytype)
        {
            bool temp = false;
            string user_id="";
            try
            {
                if (dbconnect.OpenConnection())
                {
                    string query = "select * from energymanagementdb.user where email = '" + email + "' ";
                    MySqlCommand cmd = new MySqlCommand(query, dbconnect.connection);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {
                        user_id = dataReader["idUser"] +"";

                    }
                    dbconnect.CloseConnection();
                }
                //INSERT INTO `energymanagementdb`.`permission` (`user_id`, `building`, `energy_id`, `company_code`) VALUES ('1', '2', '4', '23456789');
                string query2 = "INSERT INTO energymanagementdb.permission (user_id,building,energy_id,company_code) VALUES('"+user_id+"','"+building+"','"+energytype+"','"+company_code+"')" ;
                if (dbconnect.OpenConnection())
                {
                    try
                    {
                        MySqlCommand cmd = new MySqlCommand(query2, dbconnect.connection);
                        cmd.ExecuteNonQuery();
                        dbconnect.CloseConnection();
                        temp = true;
                    }
                    catch
                    {
                        temp = false;
                    }
                }
            }
            catch
            {
                temp = false;
            }
            
            return temp;
        }
    }
}