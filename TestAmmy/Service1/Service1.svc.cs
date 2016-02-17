using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Configuration;
using System.ServiceModel.Activation;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Data;
using Newtonsoft.Json;
using System.Collections;

namespace Service1
{

    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        //call database 
        private static string server = ConfigurationManager.AppSettings["server"];
        private static string database = ConfigurationManager.AppSettings["database"];
        private static string username = ConfigurationManager.AppSettings["username"];
        private static string password = ConfigurationManager.AppSettings["password"];
        private static string connectionString = "Server=" + server + "; PORT = 3306 " + "; Database=" + database + "; Uid=" + username + "; Pwd=" + password + "; Charset=utf8;";

        /// <summary>
        /// check login
        /// </summary>
        /// <param name="userlogin">{usename,hashed password }</param>
        /// <returns>1 variables true,false</returns>
        public string login(string[] userlogin)
        {
            bool check = false;
            string CommandText;
            MySqlCommand cmd = null;
            //MySqlDataReader rdr = null;
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();
                CommandText = "SELECT * FROM user where email = @email and password = @password";
                cmd = new MySqlCommand(CommandText, conn);
                //cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@email", userlogin[0]);
                cmd.Parameters.AddWithValue("@password", userlogin[1]);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(dataReader);
                    check = true;
                }

            }
            catch (Exception)
            {
                throw;
            }
            conn.Close();

            return check ? "1" : "0";
        }
        /// <summary>
        /// get all user 
        /// </summary>
        /// <returns>json list user</returns>
        public string getuser()
        {
            string json = "";
            MySqlCommand cmd = null;
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlDataAdapter adap;
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            ArrayList dataArray = new ArrayList();
            string CommandText;
            try
            {
                conn.Open();
                CommandText = "SELECT * FROM user";
                cmd = new MySqlCommand(CommandText, conn);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(dt);
                if (dt.Rows.Count > 0)
                    json = JsonConvert.SerializeObject(dt);
                else
                    json = "no";
                //MySqlDataReader dataReader = cmd.ExecuteReader();

                //if (dataReader.HasRows)
                //{
                //    //DataTable dt = new DataTable();
                //    dt.Load(dataReader);
                //   // json = JsonConvert.SerializeObject(dt);
                //}
            }
            catch
            {
                throw;
            }
            conn.Close();
            return json;
        }
        /// <summary>
        /// Have a people in this system?
        /// </summary>
        /// <param name="user">{username,password}</param>
        /// <returns>yes = data raw of user ,no = wrongemail </returns>
        public string Registerstatus(string[] user)
        {
            string json = "";
            MySqlCommand cmd = null;
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlDataAdapter adap;
            DataTable dt = new DataTable();
            string CommandText;
            try
            {
                conn.Open();
                CommandText = "SELECT * FROM user where email = @email and password = @password";
                cmd = new MySqlCommand(CommandText, conn);
                cmd.Parameters.AddWithValue("@email", user[0]);
                user[1] = CalculateMD5Hash(user[1]);
                cmd.Parameters.AddWithValue("@password", user[1]);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(dt);
                if (dt.Rows.Count > 0)
                    json = JsonConvert.SerializeObject(dt);
                else
                    json = "wrongemail";

            }
            catch
            {
                throw;
            }
            conn.Close();
            return json;

        }
        /// <summary>
        /// add new company when Register in first time
        /// </summary>
        /// <param name="compandy">{companycode,compandyname}</param>
        public void Addnewcompany(string[] compandy)
        {
            MySqlCommand cmd = null;
            MySqlConnection conn = new MySqlConnection(connectionString);
            string CommandText;
            try
            {
                conn.Open();
                CommandText = "INSERT INTO company (companycode,company_name) VALUES (@companycode,@companyname)";
                cmd = new MySqlCommand(CommandText, conn);
                cmd.Parameters.AddWithValue("@companycode", compandy[0]);
                cmd.Parameters.AddWithValue("@companyname", compandy[1]);
                cmd.ExecuteNonQuery();

            }
            catch
            {
                throw;
            }
            conn.Close();
        }
        public string getbuilding(string companycode)
        {
            string json = "";
            MySqlCommand cmd = null;
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlDataAdapter adap;
            DataTable dt = new DataTable();
            string CommandText;
            try
            {
                conn.Open();
                CommandText = "SELECT * FROM building where company_companycode = @companycode";
                cmd = new MySqlCommand(CommandText, conn);
                cmd.Parameters.AddWithValue("@companycode", companycode);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(dt);
                if (dt.Rows.Count > 0)
                    json = JsonConvert.SerializeObject(dt);
                else
                    json = "no";

            }
            catch
            {
                throw;
            }
            conn.Close();
            return json;
        }
        /// <summary>
        /// add user 
        /// </summary>
        /// <param name="user">{email,password,first_name,last_name,status,company_companycode}</param>
        public void Adduser(string[] user)
        {
            MySqlCommand cmd = null;
            MySqlConnection conn = new MySqlConnection(connectionString);
            string CommandText;
            try
            {
                conn.Open();
                CommandText = "INSERT INTO user (email,password,first_name,last_name,status,company_companycode) VALUES (@email,@password,@first_name,@last_name,@status,@company_companycode)";
                cmd = new MySqlCommand(CommandText, conn);
                cmd.Parameters.AddWithValue("@email", user[0]);
                //md5 password
                user[1] = CalculateMD5Hash(user[1]);
                //string x = CalculateMD5Hash(user[1]);
                cmd.Parameters.AddWithValue("@password", user[1]);
                cmd.Parameters.AddWithValue("@first_name", user[2]);
                cmd.Parameters.AddWithValue("@last_name", user[3]);
                cmd.Parameters.AddWithValue("@status", user[4]);
                cmd.Parameters.AddWithValue("@company_companycode", user[5]);
                cmd.ExecuteNonQuery();

            }
            catch
            {
                throw;
            }
            conn.Close();
        }
        /// <summary>
        /// get company code by Email
        /// </summary>
        /// <param name="email">string email</param>
        /// <returns>yes = code,no = </returns>
        public string GetCompandyCodeByEmail(string email)
        {
            string companycode = "nofound";
            MySqlCommand cmd = null;
            MySqlDataReader rdr = null;
            MySqlConnection conn = new MySqlConnection(connectionString);
            string CommandText;
            try
            {
                conn.Open();
                CommandText = "SELECT company_companycode FROM user where email = @email";
                cmd = new MySqlCommand(CommandText, conn);
                cmd.Parameters.AddWithValue("@email", email);
                rdr = cmd.ExecuteReader();
                rdr.Read();
                companycode = rdr["company_companycode"].ToString();
                rdr.Close();
            }
            catch
            {
                throw;
            }
            conn.Close();
            return companycode;
        }

        public string Addbuilding(string[] building)
        {
            string status = "0";
            MySqlCommand cmd = null;
            MySqlConnection conn = new MySqlConnection(connectionString);
            string CommandText;
            try
            {
                conn.Open();
                CommandText = "INSERT INTO building (building_name,building_detail,company_companycode) VALUES (@building_name,@building_detail,@company_companycode)";
                cmd = new MySqlCommand(CommandText, conn);
                cmd.Parameters.AddWithValue("@building_name", building[0]);
                cmd.Parameters.AddWithValue("@building_detail", building[1]);
                cmd.Parameters.AddWithValue("@company_companycode", building[2]);
                cmd.ExecuteNonQuery();
                status = "1";
            }
            catch
            {
                throw;
            }
            conn.Close();
            return status;
        }

        public string CheckPermission(string[] permission)
        {
            string json = "no";
            MySqlCommand cmd = null;
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlDataAdapter adap;
            DataTable dt = new DataTable();
            string CommandText;
            try
            {
                conn.Open();
                CommandText = "SELECT * FROM permissionview where name = @name and building_name = @building_name and energy_name = @energy_name and building_company_companycode = @building_company_companycode ";
                cmd = new MySqlCommand(CommandText, conn);
                cmd.Parameters.AddWithValue("@name", permission[0]);
                cmd.Parameters.AddWithValue("@building_name", permission[1]);
                cmd.Parameters.AddWithValue("@energy_name", permission[2]);
                cmd.Parameters.AddWithValue("@building_company_companycode", permission[3]);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(dt);
                if (dt.Rows.Count > 0)
                    json = JsonConvert.SerializeObject(dt);
                else
                    json = "no";

            }
            catch
            {
                throw;
            }
            conn.Close();
            return json;

        }
        public string ddlpermission(string email)
        {
            string json = "no";
            MySqlCommand cmd = null;
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlDataAdapter adap;
            DataTable dt = new DataTable();
            string CommandText;
            try
            {
                conn.Open();
                CommandText = "SELECT * FROM permissionview where email = @email ";
                cmd = new MySqlCommand(CommandText, conn);
                cmd.Parameters.AddWithValue("@email", email);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(dt);
                if (dt.Rows.Count > 0)
                    json = JsonConvert.SerializeObject(dt);
                else
                    json = "no";

            }
            catch
            {
                throw;
            }
            conn.Close();
            return json;
        }

        public string permissiongrid(string codecompany)
        {
            string json = "no";
            MySqlCommand cmd = null;
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlDataAdapter adap;
            DataTable dt = new DataTable();
            string CommandText;
            try
            {
                conn.Open();
                CommandText = "SELECT * FROM permissionview where building_company_companycode = @code ";
                cmd = new MySqlCommand(CommandText, conn);
                cmd.Parameters.AddWithValue("@code", codecompany);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(dt);
                if (dt.Rows.Count > 0)
                    json = JsonConvert.SerializeObject(dt);
                else
                    json = "no";

            }
            catch
            {
                throw;
            }
            conn.Close();
            return json;
        }

        public string permissionadd(string codecompany)
        {
            string json = "no";
            MySqlCommand cmd = null;
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlDataAdapter adap;
            DataTable dt = new DataTable();
            string CommandText;
            try
            {
                ////////////////////-----1---////////////////////////
                conn.Open();
                CommandText = "SELECT id,CONCAT(first_name,'  ',last_name) AS name FROM user where company_companycode = @code ";
                cmd = new MySqlCommand(CommandText, conn);
                cmd.Parameters.AddWithValue("@code", codecompany);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(dt);
                if (dt.Rows.Count > 0)
                    json = JsonConvert.SerializeObject(dt);
                else
                    json = "no";
                json += "||";
                dt = new DataTable();
                conn.Close();
                ////////////////////-----2---////////////////////////
                conn.Open();
                CommandText = "SELECT buidlingid,building_name FROM building where company_companycode = @code ";
                cmd = new MySqlCommand(CommandText, conn);
                cmd.Parameters.AddWithValue("@code", codecompany);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(dt);
                if (dt.Rows.Count > 0)
                    json += JsonConvert.SerializeObject(dt);
                else
                    json = "no";
                json += "||";
                dt = new DataTable();
                conn.Close();
                //////////////////////-----3---//////////////////////
                conn.Open();
                CommandText = "SELECT energy_id,energy_name FROM energy";
                cmd = new MySqlCommand(CommandText, conn);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(dt);
                if (dt.Rows.Count > 0)
                    json += JsonConvert.SerializeObject(dt);
                else
                    json = "no";
                json += "||";
                dt = new DataTable();
                conn.Close();
            }
            catch
            {
                throw;
            }

            return json;
        }
        public string Addpermission(string[] permission)
        {
            MySqlCommand cmd = null;
            MySqlConnection conn = new MySqlConnection(connectionString);
            string CommandText;
            string json = "no";
            try
            {

                conn.Open();
                // (`user_id`, `building_buidlingid`, `building_company_companycode`, `energy_energy_id`) VALUES ('2', '6', '12345678', '2');
                CommandText = "INSERT INTO permission (user_id,building_buidlingid,building_company_companycode,energy_energy_id) VALUES (@id,@building,@code,@energy)";
                cmd = new MySqlCommand(CommandText, conn);
                cmd.Parameters.AddWithValue("@id", permission[0]);
                cmd.Parameters.AddWithValue("@building", permission[1]);
                cmd.Parameters.AddWithValue("@code", permission[2]);
                cmd.Parameters.AddWithValue("@energy", permission[3]);
                cmd.ExecuteNonQuery();
                json = "yes";
            }
            catch
            {

                //throw;
            }
            conn.Close();
            return json;
        }
        public string Adddata(string[] data_pro)
        {
            MySqlCommand cmd = null;
            MySqlConnection conn = new MySqlConnection(connectionString);
            string CommandText;
            string json = "no";
            try
            {

                conn.Open();
                for (int i = 5; i < data_pro.Count(); i += 2)
                {
                    CommandText = "INSERT INTO electrical (permission_user_id,permission_building_buidlingid,permission_building_company_companycode,permission_energy_energy_id,type,date,`current meter`) VALUES (@userid,@building,@code,@energy,@type,@date,@meter)";
                    cmd = new MySqlCommand(CommandText, conn);
                    cmd.Parameters.AddWithValue("@userid", data_pro[0]);
                    cmd.Parameters.AddWithValue("@building", data_pro[1]);
                    cmd.Parameters.AddWithValue("@code", data_pro[2]);
                    cmd.Parameters.AddWithValue("@energy", data_pro[3]);
                    cmd.Parameters.AddWithValue("@type", "Non-Design");
                    cmd.Parameters.AddWithValue("@date", data_pro[i]);
                    cmd.Parameters.AddWithValue("@meter", data_pro[i + 1]);
                    cmd.ExecuteNonQuery();
                }
                json = "yes";
            }
            catch (Exception ex)
            {
        
                //throw;
            }
            conn.Close();
            return json;
        }
        private string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }


    }
}
