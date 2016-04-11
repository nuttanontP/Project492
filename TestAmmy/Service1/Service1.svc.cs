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
using System.Net;
using System.IO;

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
        private static string folderpath = ConfigurationManager.AppSettings["folderpath"];
        private static string ReCaptcha_Key = ConfigurationManager.AppSettings["ReCaptcha_Key"];
        private static string ReCaptcha_Secret = ConfigurationManager.AppSettings["ReCaptcha_Secret"];
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
        public string getuser(string email)
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
                CommandText = "SELECT * FROM user where email = @email";
                cmd = new MySqlCommand(CommandText, conn);
                cmd.Parameters.AddWithValue("@email", email);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    json = JsonConvert.SerializeObject(dt);
                }
            }
            catch
            {
                throw;
            }
            conn.Close();
            return json;
        }
        public string edituser(string[] data_pro)
        {
            MySqlCommand cmd = null;
            MySqlConnection conn = new MySqlConnection(connectionString);
            string CommandText;
            string json = "no";
            try
            {
                conn.Open();
                CommandText = "UPDATE user set first_name=@first_name,last_name=@last_name,job=@job,dob=@dob,address=@address,phone=@phone where email = @email";
                cmd = new MySqlCommand(CommandText, conn);
                cmd.Parameters.AddWithValue("@first_name", data_pro[0]);
                cmd.Parameters.AddWithValue("@last_name", data_pro[1]);
                cmd.Parameters.AddWithValue("@job", data_pro[2]);
                cmd.Parameters.AddWithValue("@dob", data_pro[3]);
                cmd.Parameters.AddWithValue("@address", data_pro[4]);
                cmd.Parameters.AddWithValue("@phone", data_pro[5]);
                cmd.Parameters.AddWithValue("@email", data_pro[6]);
                cmd.ExecuteNonQuery();
                json = "yes";

            }
            catch
            {

               // throw;
            }
            
            conn.Close();
            json = JsonConvert.SerializeObject(json);
            return json;
        }
        public string getuserbycompany(string company)
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
                CommandText = "SELECT * FROM user where company_companycode = @company";
                cmd = new MySqlCommand(CommandText, conn);
                cmd.Parameters.AddWithValue("@company", company);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    json = JsonConvert.SerializeObject(dt);
                }
            }
            catch
            {
                throw;
            }
            conn.Close();
            return json;
        }
        public string getcompanydetial(string[] data_pro)
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
                CommandText = "SELECT * FROM company where companycode = @companycode";
                cmd = new MySqlCommand(CommandText, conn);
                cmd.Parameters.AddWithValue("@companycode", data_pro[0]);
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

        public string getenergy(string building_id)
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
                CommandText = "SELECT DISTINCT  energy_id,energy_name  FROM permissionview where building_buidlingid = @building_id";
                cmd = new MySqlCommand(CommandText, conn);
                cmd.Parameters.AddWithValue("@building_id", building_id);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(dt);
                if (dt.Rows.Count > 0)
                    json = JsonConvert.SerializeObject(dt);
                else
                    json = JsonConvert.SerializeObject("no");

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
        public string Adduser(string[] user)
        {
            var json = "no";
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
                json = "yes";

            }
            catch
            {

            }
            conn.Close();
            return json;
        }

        public string Grid_electric(string[] data_pro)
        {
            string json = "no";
            MySqlCommand cmd = null;
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlDataAdapter adap;
            DataTable dt = new DataTable();
            string CommandText = "";
            try
            {
                conn.Open();
                string energy_id = data_pro[1].ToLower();
                if (energy_id == "electrical")
                {
                    CommandText = "SELECT date,`current meter`,type,peak,`off peak`,holiday FROM electrical ";
                }
                else if (energy_id == "diesel")
                {
                    CommandText = "SELECT * FROM diesel ";
                }
                else if (energy_id == "gasoline")
                {
                    CommandText = "SELECT * FROM gasoline ";
                }
                else if (energy_id == "lpg")
                {
                    CommandText = "SELECT * FROM lpg ";
                }
                else if (energy_id == "occupancy")
                {
                    CommandText = "SELECT date,Available,Occupied,Number_Guests FROM occupancy ";
                }
                else if (energy_id == "water")
                {
                    CommandText = "SELECT * FROM water ";
                }
                CommandText += " where permission_building_buidlingid =@building_id and month(date)=@month and year(date)=@year  ORDER BY date";
                cmd = new MySqlCommand(CommandText, conn);
                cmd.Parameters.AddWithValue("@building_id", data_pro[0]);
                cmd.Parameters.AddWithValue("@month", data_pro[2]);
                cmd.Parameters.AddWithValue("@year", data_pro[3]);

                adap = new MySqlDataAdapter(cmd);
                adap.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Dictionary<string, List<Dictionary<string, object>>> dict = new Dictionary<string, List<Dictionary<string, object>>>();
                    dict["design"] = new List<Dictionary<string, object>>();
                    dict["non_design"] = new List<Dictionary<string, object>>();

                    foreach (DataRow row in dt.Rows)
                    {
                        var type = (string)row["type"];
                        if (type  == "Design")
                        {
                            Dictionary<string, object> temp = new Dictionary<string, object>();
                            temp.Add("date", (DateTime)row["date"]);
                            temp.Add("peak", (float)row["peak"]);
                            temp.Add("off_peak", (float)row["off peak"]);
                            temp.Add("holiday", (float)row["holiday"]);
                            dict["design"].Add(temp);
                        }
                        else
                        {
                            Dictionary<string, object> temp = new Dictionary<string, object>();
                            temp.Add("date",(DateTime)row["date"]);
                            temp.Add("current", (float)row["current meter"]);
                            dict["non_design"].Add(temp);
                        }
                    }
                    json = JsonConvert.SerializeObject(dict);
                }
                
                else
                    json = JsonConvert.SerializeObject("no");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            conn.Close();
            return json;
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
        public string checkcomcode(string company)
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
                CommandText = "SELECT * FROM company where companycode = @companycode";
                cmd = new MySqlCommand(CommandText, conn);
                cmd.Parameters.AddWithValue("@companycode", company);
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
        public string ddlpermission(string[] data_pro)
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
                CommandText = "SELECT * FROM permissionview where email = @email and energy_id = @energy_id ";
                cmd = new MySqlCommand(CommandText, conn);
                cmd.Parameters.AddWithValue("@email", data_pro[0]);
                cmd.Parameters.AddWithValue("@energy_id", data_pro[1]);
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

      

        public string getdatagraph(string[] data_pro)
        {
            string json = "no";
            MySqlCommand cmd = null;
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlDataAdapter adap;
            DataTable dt = new DataTable();
            string CommandText = "";
            try
            {
                conn.Open();
                string energy_id = data_pro[1].ToLower();
                if (energy_id == "electrical")
                {
                    CommandText = "SELECT * FROM electrical ";
                }
                else if (energy_id == "diesel")
                {
                    CommandText = "SELECT * FROM diesel ";
                }
                else if (energy_id == "gasoline")
                {
                    CommandText = "SELECT * FROM gasoline ";
                }
                else if (energy_id == "lpg")
                {
                    CommandText = "SELECT * FROM lpg ";
                }
                else if (energy_id == "occupancy")
                {
                    CommandText = "SELECT date,Available,Occupied,Number_Guests FROM occupancy ";
                }
                else if (energy_id == "water")
                {
                    CommandText = "SELECT * FROM water ";
                }
                CommandText += " where permission_building_buidlingid =@building_id and date between STR_TO_DATE(@start,'%m/%d/%Y') and STR_TO_DATE(@end,'%m/%d/%Y') ORDER BY date";
                cmd = new MySqlCommand(CommandText, conn);
                cmd.Parameters.AddWithValue("@building_id", data_pro[0]);
                cmd.Parameters.AddWithValue("@start", data_pro[2]);
                cmd.Parameters.AddWithValue("@end", data_pro[3]);

                adap = new MySqlDataAdapter(cmd);
                adap.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    List<object> list = new List<object>();
                    //big list
                    Dictionary<string, object> categories = new Dictionary<string, object>();
                    categories["categories"] = new List<DateTime>();
                    foreach (DataRow row in dt.Rows)
                    {
                        ((List<DateTime>)categories["categories"]).Add((DateTime)row["date"]);
                    }
                    string[] columnNames = dt.Columns.Cast<DataColumn>()
                                 .Select(x => x.ColumnName)
                                 .Where(x => x != "date")
                                 .ToArray();
                    List<Dictionary<string, object>> dict = new List<Dictionary<string, object>>();
                    for (var i = 0; i < columnNames.Length; i++)
                    {
                        Dictionary<string, object> aSeries = new Dictionary<string, object>();
                        aSeries["name"] = columnNames[i];
                        aSeries["data"] = new List<object>();
                        //object[] temp = new object[2];
                        int N = dt.Rows.Count;
                        for (int j = 0; j < N; j++)
                        {
                            object[] temp = { (DateTime)dt.Rows[j]["date"], (int)dt.Rows[j][columnNames[i]] };
                            ((List<object>)aSeries["data"]).Add(temp);
                            // ((List<object>)aSeries["data"]).Add((DateTime)dt.Rows[j]["date"]);
                            //((List<object>)aSeries["data"]).Add((int)dt.Rows[j][columnNames[i]]);
                        }
                        dict.Add(aSeries);
                    }
                    //list.Add(categories);
                    list.Add(dict);
                    json = JsonConvert.SerializeObject(dict);
                }

                else
                    json = JsonConvert.SerializeObject("no");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
                    json += "no";
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
                    json += "no";
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
                for (int i = 3; i < permission.Count(); i++)
                {
                    try
                    {
                        CommandText = "INSERT INTO permission (user_id,building_buidlingid,building_company_companycode,energy_energy_id) VALUES (@id,@building,@code,@energy)";
                        cmd = new MySqlCommand(CommandText, conn);
                        cmd.Parameters.AddWithValue("@id", permission[0]);
                        cmd.Parameters.AddWithValue("@building", permission[1]);
                        cmd.Parameters.AddWithValue("@code", permission[2]);
                        cmd.Parameters.AddWithValue("@energy", permission[i]);
                        cmd.ExecuteNonQuery();
                    }
                    catch
                    {

                    }

                }
                json = "yes";
            }
            catch
            {

                //throw;
            }
            conn.Close();
            return json;
        }
        public string AddElectric(string[] data_pro)
        {
            MySqlCommand cmd = null;
            MySqlConnection conn = new MySqlConnection(connectionString);
            string CommandText;
            string json = "no";
            try
            {

                conn.Open();
                if (data_pro[4] == "1")
                {
                    for (int i = 5; i < data_pro.Count(); i += 2)
                    {
                        CommandText = "INSERT INTO electrical (permission_user_id,permission_building_buidlingid,permission_building_company_companycode,permission_energy_energy_id,type,date,`current meter`) VALUES (@userid,@building,@code,@energy,@type,@date,@meter)";
                        cmd = new MySqlCommand(CommandText, conn);
                        cmd.Parameters.AddWithValue("@userid", data_pro[0]);
                        cmd.Parameters.AddWithValue("@building", data_pro[1]);
                        cmd.Parameters.AddWithValue("@code", data_pro[2]);
                        cmd.Parameters.AddWithValue("@energy", data_pro[3]);
                        cmd.Parameters.AddWithValue("@type", data_pro[4]);
                        cmd.Parameters.AddWithValue("@date", data_pro[i]);
                        cmd.Parameters.AddWithValue("@meter", data_pro[i + 1]);
                        cmd.ExecuteNonQuery();
                    }
                    json = "yes";
                }
                else
                {
                    for (int i = 5; i < data_pro.Count(); i += 4)
                    {
                        CommandText = "INSERT INTO electrical (permission_user_id,permission_building_buidlingid,permission_building_company_companycode,permission_energy_energy_id,type,date,peak,`off peak`,holiday) VALUES (@userid,@building,@code,@energy,@type,@date,@peak,@off,@holiday)";
                        cmd = new MySqlCommand(CommandText, conn);
                        cmd.Parameters.AddWithValue("@userid", data_pro[0]);
                        cmd.Parameters.AddWithValue("@building", data_pro[1]);
                        cmd.Parameters.AddWithValue("@code", data_pro[2]);
                        cmd.Parameters.AddWithValue("@energy", data_pro[3]);
                        cmd.Parameters.AddWithValue("@type", data_pro[4]);
                        cmd.Parameters.AddWithValue("@date", data_pro[i]);
                        cmd.Parameters.AddWithValue("@peak", data_pro[i + 1]);
                        cmd.Parameters.AddWithValue("@off", data_pro[i + 2]);
                        cmd.Parameters.AddWithValue("@holiday", data_pro[i + 3]);
                        cmd.ExecuteNonQuery();
                    }
                    json = "yes";
                }

            }
            catch (Exception)
            {

                //throw;
            }
            conn.Close();
            return json;
        }
        public string AddDiesel(string[] data_pro)
        {
            MySqlCommand cmd = null;
            MySqlConnection conn = new MySqlConnection(connectionString);
            string CommandText;
            string json = "no";
            try
            {
                conn.Open();
                for (int i = 4; i < data_pro.Count(); i += 6)
                {
                    CommandText = "INSERT INTO diesel (permission_user_id,permission_building_buidlingid,permission_building_company_companycode,permission_energy_energy_id,date,purchased,DGSet,Vehicle,OtherPurpose,Runningtime) VALUES (@userid,@building,@code,@energy,@date,@purchased,@dgset,@vehicle,@otherpurpose,@runtime)";
                    cmd = new MySqlCommand(CommandText, conn);
                    cmd.Parameters.AddWithValue("@userid", data_pro[0]);
                    cmd.Parameters.AddWithValue("@building", data_pro[1]);
                    cmd.Parameters.AddWithValue("@code", data_pro[2]);
                    cmd.Parameters.AddWithValue("@energy", data_pro[3]);
                    //date,purchased,DGSet,Vehicle,OtherPurpose,Runningtime
                    //@date,@purchased,@dgset,@vehicle,@otherpurpose,@runtime
                    cmd.Parameters.AddWithValue("@date", data_pro[i]);
                    cmd.Parameters.AddWithValue("@purchased", data_pro[i + 1]);
                    cmd.Parameters.AddWithValue("@dgset", data_pro[i + 2]);
                    cmd.Parameters.AddWithValue("@vehicle", data_pro[i + 3]);
                    cmd.Parameters.AddWithValue("@otherpurpose", data_pro[i + 4]);
                    cmd.Parameters.AddWithValue("@runtime", data_pro[i + 5]);
                    cmd.ExecuteNonQuery();
                }
                json = "yes";
            }
            catch
            {
                throw;
            }
            conn.Close();
            return json;
        }
        public string Addgasoline(string[] data_pro)
        {
            MySqlCommand cmd = null;
            MySqlConnection conn = new MySqlConnection(connectionString);
            string CommandText;
            string json = "no";
            try
            {
                conn.Open();
                for (int i = 4; i < data_pro.Count(); i += 3)
                {
                    CommandText = "INSERT INTO gasoline (permission_user_id,permission_building_buidlingid,permission_building_company_companycode,permission_energy_energy_id,date,purchased,consumed) VALUES (@userid,@building,@code,@energy,@date,@purchased,@consumed)";
                    cmd = new MySqlCommand(CommandText, conn);
                    cmd.Parameters.AddWithValue("@userid", data_pro[0]);
                    cmd.Parameters.AddWithValue("@building", data_pro[1]);
                    cmd.Parameters.AddWithValue("@code", data_pro[2]);
                    cmd.Parameters.AddWithValue("@energy", data_pro[3]);

                    cmd.Parameters.AddWithValue("@date", data_pro[i]);
                    cmd.Parameters.AddWithValue("@purchased", data_pro[i + 1]);
                    cmd.Parameters.AddWithValue("@consumed", data_pro[i + 2]);
                    cmd.ExecuteNonQuery();
                }
                json = "yes";
            }
            catch
            {
                throw;
            }
            conn.Close();
            return json;
        }
        public string AddLPG(string[] data_pro)
        {
            MySqlCommand cmd = null;
            MySqlConnection conn = new MySqlConnection(connectionString);
            string CommandText;
            string json = "no";
            try
            {
                conn.Open();
                for (int i = 4; i < data_pro.Count(); i += 3)
                {
                    CommandText = "INSERT INTO lpg (permission_user_id,permission_building_buidlingid,permission_building_company_companycode,permission_energy_energy_id,date,purchased,consumed) VALUES (@userid,@building,@code,@energy,@date,@purchased,@consumed)";
                    cmd = new MySqlCommand(CommandText, conn);
                    cmd.Parameters.AddWithValue("@userid", data_pro[0]);
                    cmd.Parameters.AddWithValue("@building", data_pro[1]);
                    cmd.Parameters.AddWithValue("@code", data_pro[2]);
                    cmd.Parameters.AddWithValue("@energy", data_pro[3]);
                    cmd.Parameters.AddWithValue("@date", data_pro[i]);
                    cmd.Parameters.AddWithValue("@purchased", data_pro[i + 1]);
                    cmd.Parameters.AddWithValue("@consumed", data_pro[i + 2]);
                    cmd.ExecuteNonQuery();
                }
                json = "yes";
            }
            catch
            {
                throw;
            }
            conn.Close();
            return json;
        }
        public string AddWater(string[] data_pro)
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
                    CommandText = "INSERT INTO water (permission_user_id,permission_building_buidlingid,permission_building_company_companycode,permission_energy_energy_id,type,date,current) VALUES (@userid,@building,@code,@energy,@type,@date,@meter)";
                    cmd = new MySqlCommand(CommandText, conn);
                    cmd.Parameters.AddWithValue("@userid", data_pro[0]);
                    cmd.Parameters.AddWithValue("@building", data_pro[1]);
                    cmd.Parameters.AddWithValue("@code", data_pro[2]);
                    cmd.Parameters.AddWithValue("@energy", data_pro[3]);
                    cmd.Parameters.AddWithValue("@type", data_pro[4]);
                    cmd.Parameters.AddWithValue("@date", data_pro[i]);
                    cmd.Parameters.AddWithValue("@meter", data_pro[i + 1]);
                    cmd.ExecuteNonQuery();
                }
                json = "yes";
            }
            catch (Exception)
            {

                //throw;
            }
            conn.Close();
            return json;
        }
        public string AddOccupancy(string[] data_pro)
        {
            MySqlCommand cmd = null;
            MySqlConnection conn = new MySqlConnection(connectionString);
            string CommandText;
            string json = "no";
            try
            {
                conn.Open();
                for (int i = 4; i < data_pro.Count(); i += 4)
                {
                    CommandText = "INSERT INTO occupancy (permission_user_id,permission_building_buidlingid,permission_building_company_companycode,permission_energy_energy_id,date,Available,Occupied,Number_Guests) VALUES (@userid,@building,@code,@energy,@date,@av_room,@oc_room,@number)";
                    cmd = new MySqlCommand(CommandText, conn);
                    cmd.Parameters.AddWithValue("@userid", data_pro[0]);
                    cmd.Parameters.AddWithValue("@building", data_pro[1]);
                    cmd.Parameters.AddWithValue("@code", data_pro[2]);
                    cmd.Parameters.AddWithValue("@energy", data_pro[3]);
                    cmd.Parameters.AddWithValue("@date", data_pro[i]);
                    cmd.Parameters.AddWithValue("@av_room", data_pro[i + 1]);
                    cmd.Parameters.AddWithValue("@oc_room", data_pro[i + 2]);
                    cmd.Parameters.AddWithValue("@number", data_pro[i + 3]);
                    cmd.ExecuteNonQuery();
                }
                json = "yes";
            }
            catch
            {
                throw;
            }
            conn.Close();
            return json;
        }
        public string delpermission(string[] data_pro)
        {
            string json = "no";
            MySqlCommand cmd = null;
            MySqlConnection conn = new MySqlConnection(connectionString);
            string CommandText;
            try
            {
                conn.Open();
                CommandText = "DELETE FROM permission WHERE user_id = @id and building_buidlingid = @building_id and building_company_companycode = @code and energy_energy_id = @energy_id";
                cmd = new MySqlCommand(CommandText, conn);
                cmd.Parameters.AddWithValue("@id", data_pro[0]);
                cmd.Parameters.AddWithValue("@building_id", data_pro[1]);
                cmd.Parameters.AddWithValue("@code", data_pro[2]);
                cmd.Parameters.AddWithValue("@energy_id", data_pro[3]);
                cmd.ExecuteNonQuery();
                json = "yes";
            }
            catch
            {
                throw;
            }
            conn.Close();
            return json;

        }
        public string delbuilding(string[] data_pro)
        {
            string json = "no";
            MySqlCommand cmd = null;
            MySqlConnection conn = new MySqlConnection(connectionString);
            string CommandText;
            try
            {
                conn.Open();
                CommandText = "DELETE FROM building WHERE buidlingid = @id";
                cmd = new MySqlCommand(CommandText, conn);
                cmd.Parameters.AddWithValue("@id", data_pro[0]);
                cmd.ExecuteNonQuery();
                json = "yes";
            }
            catch
            {
                throw;
            }
            conn.Close();
            return json;
        }
        public string selectdiesel(string[] data_pro)
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
                CommandText = "SELECT * FROM diesel order by date asc";
                cmd = new MySqlCommand(CommandText, conn);
                //cmd.Parameters.AddWithValue("@email", data_pro[0]);
                //cmd.Parameters.AddWithValue("@energy_id", data_pro[1]);
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
        public string selectdiesel2(string[] data_pro)
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
                CommandText = "SELECT * FROM diesel where month(`date`) = @month order by `date` asc";
                cmd = new MySqlCommand(CommandText, conn);
                cmd.Parameters.AddWithValue("@month", data_pro[0]);
                //cmd.Parameters.AddWithValue("@energy_id", data_pro[1]);
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
        public string VerifyCaptcha(string response)
        {
            string url = "https://www.google.com/recaptcha/api/siteverify?secret=" + ReCaptcha_Secret + "&response=" + response;
            return (new WebClient()).DownloadString(url);
        }


    }
}
