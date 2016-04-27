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
using System.Globalization;

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
        public string about_organization(string email)
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
                CommandText = " SELECT first_name,last_name,`status`,companycode,company_name,IFNULL(responsibility,0) as building_control  FROM user LEFT JOIN company ON user.company_companycode = company.companycode LEFT JOIN (select user_id,count(*) as  responsibility from (SELECT DISTINCT user_id,building_buidlingid  FROM `energy2.3`.permission) as a group by a.user_id ) as b ON user.id = b.user_id where email=@email";
                cmd = new MySqlCommand(CommandText, conn);
                cmd.Parameters.AddWithValue("@email", email);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Dictionary<string, object> dict = new Dictionary<string, object>();
                    dict["companycode"] = dt.Rows[0]["companycode"].ToString(); //row["peak"]
                    dict["company_name"] = dt.Rows[0]["company_name"].ToString();
                    dict["building_control"] = dt.Rows[0]["building_control"].ToString();
                    dict["status"] = dt.Rows[0]["status"].ToString();

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
        public string get_organization(string code)
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
                CommandText = "SELECT company_name as Organization,companycode as `Code` , company_join as `join` ,count(*) as Buildings FROM `energy2.3`.company  left join  building on company_companycode = companycode where companycode = @code group by (company_name)";
                cmd = new MySqlCommand(CommandText, conn);
                cmd.Parameters.AddWithValue("@code", code);
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
                CommandText = "SELECT DISTINCT  energy_id,energy_name  FROM permissionview where building_buidlingid = @building_id order by energy_id";
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
                        if (type == "Design")
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
                            temp.Add("date", (DateTime)row["date"]);
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
        public string getprevious(string[] data_pro)
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
                CommandText = "";
                if (data_pro[1] == "admin")
                {
                    if (data_pro[2] == "1")
                    {
                        //SELECT randomID ,date,type,`current meter`,peak`off peak`,holiday,`bath/unit`,CONCAT(`user`.`first_name`,' ',`user`.`last_name`) AS `name`,building_name from electrical left join user on   permission_user_id = user.id left join   building on permission_building_buidlingid = buidlingid
                        CommandText = "SELECT randomID ,date,type,`current meter`,peak,`off peak`,holiday,`bath/unit`,CONCAT(`user`.`first_name`,' ',`user`.`last_name`) AS `name`,building_name from electrical left join user on   permission_user_id = user.id left join   building on permission_building_buidlingid = buidlingid where permission_building_company_companycode = @code and permission_building_buidlingid = permission_building_buidlingid order by date DESC ";
                        cmd = new MySqlCommand(CommandText, conn);
                        cmd.Parameters.AddWithValue("@code", data_pro[0]);
                    }
                    else if (data_pro[2] == "2")
                    {
                        //SELECT randomID,date,purchased,DGSet,Vehicle,OtherPurpose,Runningtime,Dieselcost,`bath/unit`,CONCAT(`user`.`first_name`,' ',`user`.`last_name`) AS `name`,building_name from diesel left join user on   permission_user_id = user.id left join   building on permission_building_buidlingid = buidlingid
                        CommandText = "SELECT randomID,date,purchased,DGSet,Vehicle,OtherPurpose,Runningtime,Dieselcost,`bath/unit`,CONCAT(`user`.`first_name`,' ',`user`.`last_name`) AS `name`,building_name from diesel left join user on   permission_user_id = user.id left join   building on permission_building_buidlingid = buidlingid where permission_building_company_companycode = @code and permission_building_buidlingid = permission_building_buidlingid order by date DESC ";
                        cmd = new MySqlCommand(CommandText, conn);
                        cmd.Parameters.AddWithValue("@code", data_pro[0]);
                    }
                    else if (data_pro[2] == "3")
                    {
                        //SELECT randomID,date,purchased,consumed,`bath/unit`,CONCAT(`user`.`first_name`,' ',`user`.`last_name`) AS `name`,building_name from gasoline left join user on   permission_user_id = user.id left join   building on permission_building_buidlingid = buidlingid
                        CommandText = "SELECT randomID,date,purchased,consumed,`bath/unit`,CONCAT(`user`.`first_name`,' ',`user`.`last_name`) AS `name`,building_name from gasoline left join user on   permission_user_id = user.id left join   building on permission_building_buidlingid = buidlingid where permission_building_company_companycode = @code and permission_building_buidlingid = permission_building_buidlingid order by date DESC ";
                        cmd = new MySqlCommand(CommandText, conn);
                        cmd.Parameters.AddWithValue("@code", data_pro[0]);
                    }
                    else if (data_pro[2] == "4")
                    {
                        //SELECT randomID,date,purchased,consumed,`bath/unit`,CONCAT(`user`.`first_name`,' ',`user`.`last_name`) AS `name`,building_name from lpg left join user on   permission_user_id = user.id left join   building on permission_building_buidlingid = buidlingid
                        CommandText = "SELECT randomID,date,purchased,consumed,`bath/unit`,CONCAT(`user`.`first_name`,' ',`user`.`last_name`) AS `name`,building_name from lpg left join user on   permission_user_id = user.id left join   building on permission_building_buidlingid = buidlingid where permission_building_company_companycode = @code and permission_building_buidlingid = permission_building_buidlingid order by date DESC ";
                        cmd = new MySqlCommand(CommandText, conn);
                        cmd.Parameters.AddWithValue("@code", data_pro[0]);
                    }
                    else if (data_pro[2] == "5")
                    {
                        //SELECT randomID,date,factor,current,type,`bath/unit`,CONCAT(`user`.`first_name`,' ',`user`.`last_name`) AS `name`,building_name from water left join user on   permission_user_id = user.id left join   building on permission_building_buidlingid = buidlingid
                        CommandText = "SELECT randomID,date,factor,current,type,`bath/unit`,CONCAT(`user`.`first_name`,' ',`user`.`last_name`) AS `name`,building_name from water left join user on   permission_user_id = user.id left join   building on permission_building_buidlingid = buidlingid where permission_building_company_companycode = @code and permission_building_buidlingid = permission_building_buidlingid order by date DESC ";
                        cmd = new MySqlCommand(CommandText, conn);
                        cmd.Parameters.AddWithValue("@code", data_pro[0]);
                    }
                    else if (data_pro[2] == "6")
                    {
                        //SELECT randomID,date,Available,Occupied,Number_Guests,CONCAT(`user`.`first_name`,' ',`user`.`last_name`) AS `name`,building_name from occupancy left join user on   permission_user_id = user.id left join   building on permission_building_buidlingid = buidlingid
                        CommandText = "SELECT randomID,date,Available,Occupied,Number_Guests,CONCAT(`user`.`first_name`,' ',`user`.`last_name`) AS `name`,building_name from occupancy left join user on   permission_user_id = user.id left join   building on permission_building_buidlingid = buidlingid where permission_building_company_companycode = @code and permission_building_buidlingid = permission_building_buidlingid order by date DESC ";
                        cmd = new MySqlCommand(CommandText, conn);
                        cmd.Parameters.AddWithValue("@code", data_pro[0]);
                    }

                }
                else
                {
                    if (data_pro[2] == "1")
                    {
                        CommandText = "SELECT randomID ,date,type,`current meter`,peak`off peak`,holiday,`bath/unit`,CONCAT(`user`.`first_name`,' ',`user`.`last_name`) AS `name`,building_name from electrical left join user on   permission_user_id = user.id left join   building on permission_building_buidlingid = buidlingid where permission_building_company_companycode = @code and permission_building_buidlingid = @user_id order by date DESC ";
                        cmd = new MySqlCommand(CommandText, conn);
                        cmd.Parameters.AddWithValue("@code", data_pro[0]);
                        cmd.Parameters.AddWithValue("@user_id", data_pro[1]);
                    }
                    else if (data_pro[2] == "2")
                    {
                        CommandText = "SELECT randomID,date,purchased,DGSet,Vehicle,OtherPurpose,Runningtime,Dieselcost,`bath/unit`,CONCAT(`user`.`first_name`,' ',`user`.`last_name`) AS `name`,building_name from diesel left join user on   permission_user_id = user.id left join   building on permission_building_buidlingid = buidlingid where permission_building_company_companycode = @code and permission_building_buidlingid = @user_id order by date DESC ";
                        cmd = new MySqlCommand(CommandText, conn);
                        cmd.Parameters.AddWithValue("@code", data_pro[0]);
                        cmd.Parameters.AddWithValue("@user_id", data_pro[1]);
                    }
                    if (data_pro[2] == "3")
                    {
                        CommandText = "SELECT randomID,date,purchased,consumed,`bath/unit`,CONCAT(`user`.`first_name`,' ',`user`.`last_name`) AS `name`,building_name from gasoline left join user on   permission_user_id = user.id left join   building on permission_building_buidlingid = buidlingid where permission_building_company_companycode = @code and permission_building_buidlingid = @user_id order by date DESC ";
                        cmd = new MySqlCommand(CommandText, conn);
                        cmd.Parameters.AddWithValue("@code", data_pro[0]);
                        cmd.Parameters.AddWithValue("@user_id", data_pro[1]);
                    }
                    if (data_pro[2] == "4")
                    {
                        CommandText = "SELECT randomID,date,purchased,consumed,`bath/unit`,CONCAT(`user`.`first_name`,' ',`user`.`last_name`) AS `name`,building_name from lpg left join user on   permission_user_id = user.id left join   building on permission_building_buidlingid = buidlingid where permission_building_company_companycode = @code and permission_building_buidlingid = @user_id order by date DESC ";
                        cmd = new MySqlCommand(CommandText, conn);
                        cmd.Parameters.AddWithValue("@code", data_pro[0]);
                        cmd.Parameters.AddWithValue("@user_id", data_pro[1]);
                    }
                    if (data_pro[2] == "5")
                    {
                        CommandText = "SELECT randomID,date,factor,current,type,`bath/unit`,CONCAT(`user`.`first_name`,' ',`user`.`last_name`) AS `name`,building_name from water left join user on   permission_user_id = user.id left join   building on permission_building_buidlingid = buidlingid where permission_building_company_companycode = @code and permission_building_buidlingid = @user_id order by date DESC ";
                        cmd = new MySqlCommand(CommandText, conn);
                        cmd.Parameters.AddWithValue("@code", data_pro[0]);
                        cmd.Parameters.AddWithValue("@user_id", data_pro[1]);
                    }
                    if (data_pro[2] == "6")
                    {
                        CommandText = "SELECT randomID,date,Available,Occupied,Number_Guests,CONCAT(`user`.`first_name`,' ',`user`.`last_name`) AS `name`,building_name from occupancy left join user on   permission_user_id = user.id left join   building on permission_building_buidlingid = buidlingid where permission_building_company_companycode = @code and permission_building_buidlingid = @user_id order by date DESC ";
                        cmd = new MySqlCommand(CommandText, conn);
                        cmd.Parameters.AddWithValue("@code", data_pro[0]);
                        cmd.Parameters.AddWithValue("@user_id", data_pro[1]);
                    }
                }
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
        public string deleteprevious(string[] data_pro)
        {
            string json = "no";
            MySqlCommand cmd = null;
            MySqlConnection conn = new MySqlConnection(connectionString);
            string CommandText = "";
            try
            {
                conn.Open();
                if (data_pro[1] == "1")
                {
                    CommandText = "DELETE FROM `energy2.3`.`electrical` WHERE `randomID`= @id";
                }
                else if (data_pro[1] == "2")
                {
                    CommandText = "DELETE FROM `energy2.3`.`diesel` WHERE `randomID`= @id";
                }
                else if (data_pro[1] == "3")
                {
                    CommandText = "DELETE FROM `energy2.3`.`gasoline` WHERE `randomID`= @id";
                }
                else if (data_pro[1] == "4")
                {
                    CommandText = "DELETE FROM `energy2.3`.`lpg` WHERE `randomID`= @id";
                }
                else if (data_pro[1] == "5")
                {
                    CommandText = "DELETE FROM `energy2.3`.`water` WHERE `randomID`= @id";
                }
                else if (data_pro[1] == "6")
                {
                    CommandText = "DELETE FROM `energy2.3`.`occupancy` WHERE `randomID`= @id";
                }

                cmd = new MySqlCommand(CommandText, conn);
                cmd.Parameters.AddWithValue("@id", data_pro[2]);
                cmd.ExecuteNonQuery();
                json = "yes";
            }
            catch
            {
                throw;
            }
            conn.Close();
            return JsonConvert.SerializeObject(json);
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
                string type = data_pro[4];
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
        public string getdatagrap2h(string[] data_pro)
        {
            string json = "no";
            MySqlCommand cmd = null;
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlDataAdapter adap;
            DataTable dt = new DataTable();
            string CommandText = "";
            try
            {

                string energy_id = data_pro[2].ToLower();
                string type = data_pro[5];
                string kind = data_pro[6];
                //muliti_group 
                if (energy_id == "electrical")
                {
                    if (type == "day")
                    {
                        //day electrical
                        conn.Open();
                        CommandText = "SELECT * from `electrical_day` where building = @building and code = @code and date between STR_TO_DATE(@start,'%m/%d/%Y') and STR_TO_DATE(@end,'%m/%d/%Y') ORDER BY date";
                        cmd = new MySqlCommand(CommandText, conn);
                        cmd.Parameters.AddWithValue("@building", data_pro[0]);
                        cmd.Parameters.AddWithValue("@code", data_pro[1]);
                        cmd.Parameters.AddWithValue("@start", data_pro[3]);
                        cmd.Parameters.AddWithValue("@end", data_pro[4]);
                        adap = new MySqlDataAdapter(cmd);
                        conn.Close();
                        adap.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            string[] columnNames = new string[2];
                            List<string> columnNames2 = new List<string>();
                            columnNames2.Add("Non-Design");
                            columnNames2.Add("Design");
                            if (kind == "current")
                            {
                                columnNames[0] = "current";
                                columnNames[1] = "current_D";
                            }

                            else if (kind == "different")
                            {
                                columnNames[0] = "diff";
                                columnNames[1] = "diff_D";
                            }

                            else if (kind == "money")
                            {
                                columnNames[0] = "money";
                                columnNames[1] = "money_D";
                            }

                            List<Dictionary<string, object>> dict = new List<Dictionary<string, object>>();
                            for (var i = 0; i < 1; i++)
                            {
                                Dictionary<string, object> aSeries = new Dictionary<string, object>();
                                aSeries["name"] = columnNames2[0];
                                aSeries["data"] = new List<object>();
                                Dictionary<string, object> bSeries = new Dictionary<string, object>();
                                bSeries["name"] = columnNames2[1];
                                bSeries["data"] = new List<object>();
                                int N = dt.Rows.Count;
                                for (int j = 0; j < N; j++)
                                {

                                    if (dt.Rows[j]["type"].ToString() == columnNames2[0])
                                    {
                                        object[] temp = { (DateTime)dt.Rows[j]["date"], dt.Rows[j][columnNames[0]] };
                                        ((List<object>)aSeries["data"]).Add(temp);

                                    }
                                    else if (dt.Rows[j]["type"].ToString() == columnNames2[1])
                                    {
                                        object[] temp = { (DateTime)dt.Rows[j]["date"], dt.Rows[j][columnNames[1]] };
                                        ((List<object>)bSeries["data"]).Add(temp);

                                    }


                                }
                                dict.Add(aSeries);
                                dict.Add(bSeries);
                                json = JsonConvert.SerializeObject(dict);
                            }
                        }
                        else
                        {
                            //no row
                            json = JsonConvert.SerializeObject("no");

                        }

                    }

                    else if (type == "month")
                    {
                        //month electrical
                        conn.Open();
                        CommandText = " SELECT DATE_FORMAT(`date`, '%m-%Y') AS `month`,`type` AS `type`,(MAX(`current`) - MIN(`current`)) AS `different_current`,SUM(`diff`) AS `sum_unit`,SUM(`money`) AS `sum_money`,(MAX(`current_D`) - MIN(`current_D`)) AS `different_current_D`,SUM(`diff_D`) AS `sum_unit_D`,SUM(`money_D`) AS `sum_money_D`,`id` AS `id`,`building` AS `building`,`code` AS `code` ";
                        CommandText += " FROM electrical_day WHERE building =@building and code = @code and  (`date` BETWEEN STR_TO_DATE(@start, '%m/%d/%Y') AND STR_TO_DATE(@end, '%m/%d/%Y'))  ";
                        CommandText += " GROUP BY DATE_FORMAT(`date`, '%m-%Y') , `type` , `building` , `code` ";
                        cmd = new MySqlCommand(CommandText, conn);
                        cmd.Parameters.AddWithValue("@building", data_pro[0]);
                        cmd.Parameters.AddWithValue("@code", data_pro[1]);
                        cmd.Parameters.AddWithValue("@start", data_pro[3]);
                        cmd.Parameters.AddWithValue("@end", data_pro[4]);
                        adap = new MySqlDataAdapter(cmd);
                        conn.Close();
                        adap.Fill(dt);
                        string[] columnNames = new string[2];
                        List<string> columnNames2 = new List<string>();
                        columnNames2.Add("Non-Design");
                        columnNames2.Add("Design");
                        if (kind == "current")
                        {
                            columnNames[0] = "different_current";
                            columnNames[1] = "different_current_D";
                        }
                        else if (kind == "different")
                        {
                            columnNames[0] = "sum_unit";
                            columnNames[1] = "sum_unit_D";
                        }
                        else if (kind == "money")
                        {
                            columnNames[0] = "sum_money";
                            columnNames[1] = "sum_money_D";
                        }
                        List<Dictionary<string, object>> dict = new List<Dictionary<string, object>>();
                        for (var i = 0; i < 1; i++)
                        {
                            Dictionary<string, object> aSeries = new Dictionary<string, object>();
                            aSeries["name"] = columnNames2[0];
                            aSeries["data"] = new List<object>();
                            Dictionary<string, object> bSeries = new Dictionary<string, object>();
                            bSeries["name"] = columnNames2[1];
                            bSeries["data"] = new List<object>();
                            //object[] temp = new object[2];
                            int N = dt.Rows.Count;
                            for (int j = 0; j < N; j++)
                            {

                                DateTime datetime = DateTime.ParseExact((string)dt.Rows[j]["month"], "MM-yyyy", CultureInfo.InvariantCulture);
                                if (dt.Rows[j]["type"].ToString() == columnNames2[i])
                                {

                                    object[] temp = { datetime, dt.Rows[j][columnNames[0]] };
                                    ((List<object>)aSeries["data"]).Add(temp);


                                }
                                else if (dt.Rows[j]["type"].ToString() == columnNames2[1])
                                {
                                    object[] temp = { datetime, dt.Rows[j][columnNames[1]] };
                                    ((List<object>)bSeries["data"]).Add(temp);

                                }
                            }

                            dict.Add(aSeries);
                            dict.Add(bSeries);


                        }
                        //list.Add(dict_nont);
                        //list.Add(dict);
                        json = JsonConvert.SerializeObject(dict);

                    }
                    else if (type == "year")
                    {
                        //year electrical
                        conn.Open();
                        CommandText = " SELECT DATE_FORMAT(`date`, '%Y') AS `year`,`type` AS `type`,(MAX(`current`) - MIN(`current`)) AS `different_current`,SUM(`diff`) AS `sum_unit`,SUM(`money`) AS `sum_money`,(MAX(`current_D`) - MIN(`current_D`)) AS `different_current_D`,SUM(`diff_D`) AS `sum_unit_D`,SUM(`money_D`) AS `sum_money_D`,`id` AS `id`,`building` AS `building`,`code` AS `code` ";
                        CommandText += " FROM electrical_day WHERE building =@building and code = @code and  (`date` BETWEEN STR_TO_DATE(@start, '%m/%d/%Y') AND STR_TO_DATE(@end, '%m/%d/%Y'))  ";
                        CommandText += " GROUP BY DATE_FORMAT(`date`, '%Y') , `type` , `building` , `code` ";
                        cmd = new MySqlCommand(CommandText, conn);
                        cmd.Parameters.AddWithValue("@building", data_pro[0]);
                        cmd.Parameters.AddWithValue("@code", data_pro[1]);
                        cmd.Parameters.AddWithValue("@start", data_pro[3]);
                        cmd.Parameters.AddWithValue("@end", data_pro[4]);
                        adap = new MySqlDataAdapter(cmd);
                        conn.Close();
                        adap.Fill(dt);
                        string[] columnNames = new string[2];
                        List<string> columnNames2 = new List<string>();
                        columnNames2.Add("Non-Design");
                        columnNames2.Add("Design");
                        if (kind == "current")
                        {
                            columnNames[0] = "different_current";
                            columnNames[1] = "different_current_D";
                        }
                        else if (kind == "different")
                        {
                            columnNames[0] = "sum_unit";
                            columnNames[1] = "sum_unit_D";
                        }
                        else if (kind == "money")
                        {
                            columnNames[0] = "sum_money";
                            columnNames[1] = "sum_money_D";
                        }
                        List<Dictionary<string, object>> dict = new List<Dictionary<string, object>>();
                        for (var i = 0; i < 1; i++)
                        {
                            Dictionary<string, object> aSeries = new Dictionary<string, object>();
                            aSeries["name"] = columnNames2[0];
                            aSeries["data"] = new List<object>();
                            Dictionary<string, object> bSeries = new Dictionary<string, object>();
                            bSeries["name"] = columnNames2[1];
                            bSeries["data"] = new List<object>();
                            //object[] temp = new object[2];
                            int N = dt.Rows.Count;
                            for (int j = 0; j < N; j++)
                            {

                                DateTime datetime = DateTime.ParseExact((string)dt.Rows[j]["year"], "yyyy", CultureInfo.InvariantCulture);
                                if (dt.Rows[j]["type"].ToString() == columnNames2[i])
                                {

                                    object[] temp = { datetime, dt.Rows[j][columnNames[0]] };
                                    ((List<object>)aSeries["data"]).Add(temp);


                                }
                                else if (dt.Rows[j]["type"].ToString() == columnNames2[1])
                                {
                                    object[] temp = { datetime, dt.Rows[j][columnNames[1]] };
                                    ((List<object>)bSeries["data"]).Add(temp);

                                }
                            }

                            dict.Add(aSeries);
                            dict.Add(bSeries);


                        }
                        //list.Add(dict_nont);
                        //list.Add(dict);
                        json = JsonConvert.SerializeObject(dict);

                    }
                }
                else if (energy_id == "diesel")
                {
                    if (type == "day")
                    {
                        //diesel day
                        conn.Open();
                        CommandText = "SELECT * from `diesel_day` where building = @building and code = @code and date between STR_TO_DATE(@start,'%m/%d/%Y') and STR_TO_DATE(@end,'%m/%d/%Y') ORDER BY date";
                        cmd = new MySqlCommand(CommandText, conn);
                        cmd.Parameters.AddWithValue("@building", data_pro[0]);
                        cmd.Parameters.AddWithValue("@code", data_pro[1]);
                        cmd.Parameters.AddWithValue("@start", data_pro[3]);
                        cmd.Parameters.AddWithValue("@end", data_pro[4]);
                        adap = new MySqlDataAdapter(cmd);
                        conn.Close();
                        adap.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            List<string> columnNames = new List<string>();

                            List<string> columnNames2 = new List<string>();
                            columnNames2.Add("Purchased");
                            columnNames2.Add("Consumed");
                            if (kind == "current")
                            {
                                columnNames.Add("purchased");
                                columnNames.Add("total_litre_use");

                            }

                            else if (kind == "different")
                            {
                                columnNames.Add("diff_purchased");
                                columnNames.Add("diff_use");

                            }

                            else if (kind == "money")
                            {
                                columnNames.Add("cost");
                            }

                            List<Dictionary<string, object>> dict = new List<Dictionary<string, object>>();
                            for (var i = 0; i < columnNames.Count; i++)
                            {
                                
                                    Dictionary<string, object> aSeries = new Dictionary<string, object>();
                                    aSeries["name"] = columnNames2[i];
                                    aSeries["data"] = new List<object>();
                                    int N = dt.Rows.Count;
                                    for (int j = 0; j < N; j++)
                                    {
                                        object[] temp = { (DateTime)dt.Rows[j]["date"], dt.Rows[j][columnNames[i]] };
                                        ((List<object>)aSeries["data"]).Add(temp);
                                    }
                                    dict.Add(aSeries);
                                
                            }
                            json = JsonConvert.SerializeObject(dict);

                        }
                        else
                        {
                            json = JsonConvert.SerializeObject("no");
                        }
                    }
                    else if (type == "month")
                    {
                        conn.Open();
                        CommandText = " SELECT DATE_FORMAT(`date`, '%m-%Y') AS `month`,SUM(`purchased`) AS `sum_purchased`,SUM(`total_litre_use`) AS `sum_total_litre_use`,SUM(`diff_purchased`) AS `sum_diff_purchased`,SUM(`diff_use`) AS `sum_diff_use`,SUM(`cost`) AS `sum_cost`,`id` AS `id`,`building` AS `building`,`code` AS `code` ";
                        CommandText += " FROM `diesel_day`  ";
                        CommandText += " WHERE  building =@building and code = @code and  (`date` BETWEEN STR_TO_DATE(@start, '%m/%d/%Y') AND STR_TO_DATE(@end, '%m/%d/%Y'))  ";
                        CommandText += " GROUP BY DATE_FORMAT(`date`, '%m-%Y') , `building` , `code` ";
                        cmd = new MySqlCommand(CommandText, conn);
                        cmd.Parameters.AddWithValue("@building", data_pro[0]);
                        cmd.Parameters.AddWithValue("@code", data_pro[1]);
                        cmd.Parameters.AddWithValue("@start", data_pro[3]);
                        cmd.Parameters.AddWithValue("@end", data_pro[4]);
                        adap = new MySqlDataAdapter(cmd);
                        conn.Close();
                        adap.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            List<string> columnNames = new List<string>();

                            List<string> columnNames2 = new List<string>();
                            columnNames2.Add("Purchased");
                            columnNames2.Add("Consumed");
                            if (kind == "current")
                            {
                                columnNames.Add("sum_purchased");
                                columnNames.Add("sum_total_litre_use");

                            }

                            else if (kind == "different")
                            {
                                columnNames.Add("sum_diff_purchased");
                                columnNames.Add("sum_diff_use");

                            }

                            else if (kind == "money")
                            {
                                columnNames.Add("sum_cost");
                            }

                            List<Dictionary<string, object>> dict = new List<Dictionary<string, object>>();
                            for (var i = 0; i < columnNames.Count; i++)
                            {
                               
                                    Dictionary<string, object> aSeries = new Dictionary<string, object>();
                                    aSeries["name"] = columnNames2[i];
                                    aSeries["data"] = new List<object>();
                                    int N = dt.Rows.Count;
                                    for (int j = 0; j < N; j++)
                                    {
                                        DateTime datetime = DateTime.ParseExact((string)dt.Rows[j]["month"], "MM-yyyy", CultureInfo.InvariantCulture);
                                        object[] temp = { datetime, dt.Rows[j][columnNames[i]] };
                                        ((List<object>)aSeries["data"]).Add(temp);
                                    }
                                    dict.Add(aSeries);
                               
                            }
                            json = JsonConvert.SerializeObject(dict);

                        }
                        else
                        {
                            json = JsonConvert.SerializeObject("no");
                        }
                    }
                    else if (type == "year")
                    {
                        conn.Open();
                        CommandText = " SELECT DATE_FORMAT(`date`, '%Y') AS `year`,SUM(`purchased`) AS `sum_purchased`,SUM(`total_litre_use`) AS `sum_total_litre_use`,SUM(`diff_purchased`) AS `sum_diff_purchased`,SUM(`diff_use`) AS `sum_diff_use`,SUM(`cost`) AS `sum_cost`,`id` AS `id`,`building` AS `building`,`code` AS `code` ";
                        CommandText += " FROM `diesel_day`  ";
                        CommandText += " WHERE  building =@building and code = @code and  (`date` BETWEEN STR_TO_DATE(@start, '%m/%d/%Y') AND STR_TO_DATE(@end, '%m/%d/%Y'))  ";
                        CommandText += " GROUP BY DATE_FORMAT(`date`, '%Y') , `building` , `code` ";
                        cmd = new MySqlCommand(CommandText, conn);
                        cmd.Parameters.AddWithValue("@building", data_pro[0]);
                        cmd.Parameters.AddWithValue("@code", data_pro[1]);
                        cmd.Parameters.AddWithValue("@start", data_pro[3]);
                        cmd.Parameters.AddWithValue("@end", data_pro[4]);
                        adap = new MySqlDataAdapter(cmd);
                        conn.Close();
                        adap.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            List<string> columnNames = new List<string>();

                            List<string> columnNames2 = new List<string>();
                            columnNames2.Add("Purchased");
                            columnNames2.Add("Consumed");
                            if (kind == "current")
                            {
                                columnNames.Add("sum_purchased");
                                columnNames.Add("sum_total_litre_use");

                            }

                            else if (kind == "different")
                            {
                                columnNames.Add("sum_diff_purchased");
                                columnNames.Add("sum_diff_use");

                            }

                            else if (kind == "money")
                            {
                                columnNames.Add("sum_cost");
                            }

                            List<Dictionary<string, object>> dict = new List<Dictionary<string, object>>();
                            for (var i = 0; i < columnNames.Count; i++)
                            {
                                    Dictionary<string, object> aSeries = new Dictionary<string, object>();
                                    aSeries["name"] = columnNames2[i];
                                    aSeries["data"] = new List<object>();
                                    int N = dt.Rows.Count;
                                    for (int j = 0; j < N; j++)
                                    {
                                        DateTime datetime = DateTime.ParseExact((string)dt.Rows[j]["year"], "yyyy", CultureInfo.InvariantCulture);
                                        object[] temp = { datetime, dt.Rows[j][columnNames[i]] };
                                        ((List<object>)aSeries["data"]).Add(temp);
                                    }
                                    dict.Add(aSeries);
                                    
                            }
                            json = JsonConvert.SerializeObject(dict);

                        }
                        else
                        {
                            json = JsonConvert.SerializeObject("no");
                        }
                    }

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
                    if (type == "day")
                    {
                        //day water
                        conn.Open();
                        CommandText = "SELECT * from `water_day` where building = @building and code = @code and date between STR_TO_DATE(@start,'%m/%d/%Y') and STR_TO_DATE(@end,'%m/%d/%Y') ORDER BY date";
                        cmd = new MySqlCommand(CommandText, conn);
                        cmd.Parameters.AddWithValue("@building", data_pro[0]);
                        cmd.Parameters.AddWithValue("@code", data_pro[1]);
                        cmd.Parameters.AddWithValue("@start", data_pro[3]);
                        cmd.Parameters.AddWithValue("@end", data_pro[4]);
                        adap = new MySqlDataAdapter(cmd);
                        conn.Close();
                        adap.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {

                            Dictionary<string, object> dict_nont = new Dictionary<string, object>();
                            dict_nont["categories"] = new List<DateTime>();
                            foreach (DataRow row in dt.Rows)
                            {
                                ((List<DateTime>)dict_nont["categories"]).Add((DateTime)row["date"]);
                            }
                            string[] columnNames = new string[1];
                            List<string> columnNames2 = new List<string>();
                            columnNames2.Add("supply");
                            columnNames2.Add("ground");
                            columnNames2.Add("both");
                            if (kind == "current")
                                columnNames[0] = "current";
                            else if (kind == "different")
                                columnNames[0] = "diff";
                            else if (kind == "money")
                                columnNames[0] = "money";
                            List<Dictionary<string, object>> dict = new List<Dictionary<string, object>>();
                            for (var i = 0; i < columnNames.Length; i++)
                            {
                                Dictionary<string, object> aSeries = new Dictionary<string, object>();
                                aSeries["name"] = columnNames2[0];
                                aSeries["data"] = new List<object>();
                                Dictionary<string, object> bSeries = new Dictionary<string, object>();
                                bSeries["name"] = columnNames2[1];
                                bSeries["data"] = new List<object>();
                                Dictionary<string, object> cSeries = new Dictionary<string, object>();
                                cSeries["name"] = columnNames2[2];
                                cSeries["data"] = new List<object>();
                                //object[] temp = new object[2];
                                int N = dt.Rows.Count;
                                for (int j = 0; j < N; j++)
                                {

                                    if (dt.Rows[j]["type"].ToString() == "supply")
                                    {
                                        object[] temp = { (DateTime)dt.Rows[j]["date"], dt.Rows[j][columnNames[i]] };
                                        ((List<object>)aSeries["data"]).Add(temp);

                                    }
                                    else if (dt.Rows[j]["type"].ToString() == "ground")
                                    {
                                        object[] temp = { (DateTime)dt.Rows[j]["date"], dt.Rows[j][columnNames[i]] };
                                        ((List<object>)bSeries["data"]).Add(temp);

                                    }
                                    else if (dt.Rows[j]["type"].ToString() == "both")
                                    {
                                        object[] temp = { (DateTime)dt.Rows[j]["date"], dt.Rows[j][columnNames[i]] };
                                        ((List<object>)cSeries["data"]).Add(temp);

                                    }

                                }
                                dict.Add(aSeries);
                                dict.Add(bSeries);
                                dict.Add(cSeries);
                                json = JsonConvert.SerializeObject(dict);

                            }
                        }
                        else
                            json = JsonConvert.SerializeObject("no");

                    }
                    else if (type == "month")
                    {
                        //month water
                        conn.Open();
                        CommandText = " SELECT  DATE_FORMAT(`date`, '%m-%Y') AS `month`, `type` AS `type`, (MAX(`current`) - MIN(`current`)) AS `different_current`, SUM(`diff`) AS `sum_unit`,SUM(`money`) AS `sum_money`, `id` AS `id`, `building` AS `building`,`code` AS `code` ";
                        CommandText += " FROM  `water_day` ";
                        CommandText += " WHERE building = @building and code = @code and (`date` BETWEEN STR_TO_DATE(@start, '%m/%d/%Y') AND STR_TO_DATE(@end, '%m/%d/%Y')) ";
                        CommandText += " GROUP BY DATE_FORMAT(`date`, '%m-%Y') , `type` , `building` , `code` ";
                        cmd = new MySqlCommand(CommandText, conn);
                        cmd.Parameters.AddWithValue("@building", data_pro[0]);
                        cmd.Parameters.AddWithValue("@code", data_pro[1]);
                        cmd.Parameters.AddWithValue("@start", data_pro[3]);
                        cmd.Parameters.AddWithValue("@end", data_pro[4]);
                        adap = new MySqlDataAdapter(cmd);
                        conn.Close();
                        adap.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            List<object> list = new List<object>();
                            Dictionary<string, object> dict_nont = new Dictionary<string, object>();
                            //dict_nont["categories"] = new List<DateTime>();
                            //foreach (DataRow row in dt.Rows)
                            //{
                            //    ((List<DateTime>)dict_nont["categories"]).Add((DateTime)row["month"]);
                            //}

                            List<string> month = new List<string>();
                            foreach (DataRow row in dt.Rows)
                            {
                                month.Add((string)row["month"]);
                            }
                            List<string> noDupes = month.Distinct().ToList();
                            dict_nont["categories"] = noDupes;
                            string[] columnNames = new string[1];
                            List<string> columnNames2 = new List<string>();
                            columnNames2.Add("supply");
                            columnNames2.Add("ground");
                            columnNames2.Add("both");
                            if (kind == "current")
                            {
                                columnNames[0] = "different_current";
                            }


                            else if (kind == "different")
                            {
                                columnNames[0] = "sum_unit";
                            }

                            else if (kind == "money")
                            {
                                columnNames[0] = "sum_money";
                            }


                            List<Dictionary<string, object>> dict = new List<Dictionary<string, object>>();
                            for (var i = 0; i < columnNames.Length; i++)
                            {
                                Dictionary<string, object> aSeries = new Dictionary<string, object>();
                                aSeries["name"] = columnNames2[0];
                                aSeries["data"] = new List<object>();
                                Dictionary<string, object> bSeries = new Dictionary<string, object>();
                                bSeries["name"] = columnNames2[1];
                                bSeries["data"] = new List<object>();
                                Dictionary<string, object> cSeries = new Dictionary<string, object>();
                                cSeries["name"] = columnNames2[2];
                                cSeries["data"] = new List<object>();
                                //object[] temp = new object[2];
                                int N = dt.Rows.Count;
                                for (int j = 0; j < N; j++)
                                {

                                    DateTime datetime = DateTime.ParseExact((string)dt.Rows[j]["month"], "MM-yyyy", CultureInfo.InvariantCulture);
                                    if (dt.Rows[j]["type"].ToString() == "supply")
                                    {

                                        object[] temp = { datetime, dt.Rows[j][columnNames[i]] };
                                        ((List<object>)aSeries["data"]).Add(temp);


                                    }
                                    else if (dt.Rows[j]["type"].ToString() == "ground")
                                    {
                                        object[] temp = { datetime, dt.Rows[j][columnNames[i]] };
                                        ((List<object>)bSeries["data"]).Add(temp);

                                    }
                                    else if (dt.Rows[j]["type"].ToString() == "both")
                                    {
                                        object[] temp = { datetime, dt.Rows[j][columnNames[i]] };
                                        ((List<object>)cSeries["data"]).Add(temp);

                                    }
                                }

                                dict.Add(aSeries);
                                dict.Add(bSeries);
                                dict.Add(cSeries);


                            }
                            //list.Add(dict_nont);
                            //list.Add(dict);
                            json = JsonConvert.SerializeObject(dict);
                        }

                        else
                            json = JsonConvert.SerializeObject("no");


                    }
                    else if (type == "year")
                    {
                        //month water
                        conn.Open();
                        CommandText = " SELECT  DATE_FORMAT(`date`, '%Y') AS `year`, `type` AS `type`, (MAX(`current`) - MIN(`current`)) AS `different_current`, SUM(`diff`) AS `sum_unit`,SUM(`money`) AS `sum_money`, `id` AS `id`, `building` AS `building`,`code` AS `code` ";
                        CommandText += " FROM  `water_day` ";
                        CommandText += " WHERE building = @building and code = @code and (`date` BETWEEN STR_TO_DATE(@start, '%m/%d/%Y') AND STR_TO_DATE(@end, '%m/%d/%Y')) ";
                        CommandText += " GROUP BY DATE_FORMAT(`date`, '%Y') , `type` , `building` , `code` ";
                        cmd = new MySqlCommand(CommandText, conn);
                        cmd.Parameters.AddWithValue("@building", data_pro[0]);
                        cmd.Parameters.AddWithValue("@code", data_pro[1]);
                        cmd.Parameters.AddWithValue("@start", data_pro[3]);
                        cmd.Parameters.AddWithValue("@end", data_pro[4]);
                        adap = new MySqlDataAdapter(cmd);
                        conn.Close();
                        adap.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            List<object> list = new List<object>();
                            Dictionary<string, object> dict_nont = new Dictionary<string, object>();
                            //dict_nont["categories"] = new List<DateTime>();
                            //foreach (DataRow row in dt.Rows)
                            //{
                            //    ((List<DateTime>)dict_nont["categories"]).Add((DateTime)row["month"]);
                            //}

                            List<string> month = new List<string>();
                            foreach (DataRow row in dt.Rows)
                            {
                                month.Add((string)row["year"]);
                            }
                            List<string> noDupes = month.Distinct().ToList();
                            dict_nont["categories"] = noDupes;
                            string[] columnNames = new string[1];
                            List<string> columnNames2 = new List<string>();
                            columnNames2.Add("supply");
                            columnNames2.Add("ground");
                            columnNames2.Add("both");
                            if (kind == "current")
                            {
                                columnNames[0] = "different_current";
                            }


                            else if (kind == "different")
                            {
                                columnNames[0] = "sum_unit";
                            }

                            else if (kind == "money")
                            {
                                columnNames[0] = "sum_money";
                            }


                            List<Dictionary<string, object>> dict = new List<Dictionary<string, object>>();
                            for (var i = 0; i < columnNames.Length; i++)
                            {
                                Dictionary<string, object> aSeries = new Dictionary<string, object>();
                                aSeries["name"] = columnNames2[0];
                                aSeries["data"] = new List<object>();
                                Dictionary<string, object> bSeries = new Dictionary<string, object>();
                                bSeries["name"] = columnNames2[1];
                                bSeries["data"] = new List<object>();
                                Dictionary<string, object> cSeries = new Dictionary<string, object>();
                                cSeries["name"] = columnNames2[2];
                                cSeries["data"] = new List<object>();
                                //object[] temp = new object[2];
                                int N = dt.Rows.Count;
                                for (int j = 0; j < N; j++)
                                {

                                    DateTime datetime = DateTime.ParseExact((string)dt.Rows[j]["year"], "yyyy", CultureInfo.InvariantCulture);
                                    if (dt.Rows[j]["type"].ToString() == "supply")
                                    {
                                        object[] temp = { datetime, dt.Rows[j][columnNames[i]] };
                                        ((List<object>)aSeries["data"]).Add(temp);
                                    }
                                    else if (dt.Rows[j]["type"].ToString() == "ground")
                                    {
                                        object[] temp = { datetime, dt.Rows[j][columnNames[i]] };
                                        ((List<object>)bSeries["data"]).Add(temp);
                                    }
                                    else if (dt.Rows[j]["type"].ToString() == "both")
                                    {
                                        object[] temp = { datetime, dt.Rows[j][columnNames[i]] };
                                        ((List<object>)cSeries["data"]).Add(temp);
                                    }
                                }

                                dict.Add(aSeries);
                                dict.Add(bSeries);
                                dict.Add(cSeries);


                            }
                            //list.Add(dict_nont);
                            //list.Add(dict);
                            json = JsonConvert.SerializeObject(dict);
                        }

                        else
                            json = JsonConvert.SerializeObject("no");


                    }


                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            return json;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data_pro">code,energy,type{day,month},start,end,int(building),building_id,building_id,building_id</param>
        /// <returns></returns>
        public string getdatagraph3(string[] data_pro)
        {
            string json = "no";
            MySqlCommand cmd = null;
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlDataAdapter adap;
            DataTable dt = new DataTable();
            string CommandText = "";
            string code = data_pro[0];
            string energy = data_pro[1].ToLower();
            string type = data_pro[2];
            string kind = data_pro[3];
            string date_start = data_pro[4];
            string date_end = data_pro[5];
            int building_count = Int32.Parse(data_pro[6]);
            string building = data_pro[7];
            int start_building_index = 7;

            if (energy == "electrical")
            {
                if (type == "day")
                {
                    conn.Open();
                    List<string> list_building = new List<string>();
                    CommandText = "SELECT electrical_day.*,b.building_name as `name` from `electrical_day` ";
                    CommandText += " left join  building b on  electrical_day.building = b.buidlingid ";
                    CommandText += "  where code = @code and date between STR_TO_DATE(@start,'%m/%d/%Y') and STR_TO_DATE(@end,'%m/%d/%Y') and ";
                    for (int i = start_building_index; i < data_pro.Count() - 1; i++)
                    {
                        CommandText += "building = " + data_pro[i] + " or ";
                    }
                    CommandText += "building = " + data_pro[data_pro.Count() - 1] + " ";
                    CommandText += " ORDER BY date ";
                    cmd = new MySqlCommand(CommandText, conn);
                    cmd.Parameters.AddWithValue("@building", building);
                    cmd.Parameters.AddWithValue("@code", code);
                    cmd.Parameters.AddWithValue("@start", date_start);
                    cmd.Parameters.AddWithValue("@end", date_end);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                        list_building.Add(reader["name"].ToString());
                    adap = new MySqlDataAdapter(cmd);
                    conn.Close();
                    adap.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        string col = "";
                        if (kind == "current")
                        {
                            col = "current";
                        }
                        else if (kind == "different")
                        {
                            col = "diff";
                        }
                        else if (kind == "money")
                        {
                            col = "money";
                        }
                        List<Dictionary<string, object>> dict = new List<Dictionary<string, object>>();
                        List<string> columnNames = new List<string>(list_building.Distinct().ToArray());
                        for (int i = 0; i < columnNames.Count; i++)
                        {
                            Dictionary<string, object> aSeries = new Dictionary<string, object>();
                            aSeries["name"] = columnNames[i];
                            aSeries["data"] = new List<object>();
                            int N = dt.Rows.Count;
                            for (int j = 0; j < N; j++)
                            {
                                if (dt.Rows[j]["name"].ToString() == columnNames[i])
                                {
                                    if (dt.Rows[j][col].ToString() != "")
                                    {
                                        object[] temp = { (DateTime)dt.Rows[j]["date"], dt.Rows[j][col] };
                                        ((List<object>)aSeries["data"]).Add(temp);
                                    }

                                }
                            }
                            dict.Add(aSeries);
                        }
                        json = JsonConvert.SerializeObject(dict);
                    }
                    else if (type == "month")
                    {

                    }
                    else if (type == "year")
                    {

                    }
                }
            }
            else if (energy == "water")
            {

            }

            return json;
        }

        public string getcirclegraph(string code)
        {

            string json = "no";
            MySqlCommand cmd = null;
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlDataAdapter adap;
            DataTable dt = new DataTable();
            conn.Open();
            string CommandText = " SELECT sum(b.money)+sum(b.money_D) as electrical,sum(a.money) as water , sum(c.cost) as diesel , sum(d.cost) as gasoline ";
            CommandText += " FROM `energy2.3`.water_day a,`energy2.3`.electrical_day b,`energy2.3`.diesel_day c, gasoline_day d ";
            CommandText += "where a.`code` = @code and b.`code` = @code and c.`code` = @code and d.`code` = @code ";
            cmd = new MySqlCommand(CommandText, conn);
            cmd.Parameters.AddWithValue("@code", code);
            adap = new MySqlDataAdapter(cmd);
            conn.Close();
            adap.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                //in this time have 4 electrical , water ,gasoline ,diesel
                string[] strArray = { "#f56954", "#00a65a", "#f39c12", "#00c0ef" };
                string[] columnNames = dt.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();
                List<string> color = new List<string>(strArray);
                List<Dictionary<string, object>> dict = new List<Dictionary<string, object>>();

                for (int i = 0; i < columnNames.Count(); i++)
                {
                    Dictionary<string, object> list = new Dictionary<string, object>();
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {

                        list["value"] = dt.Rows[j][columnNames[i]];
                        list["color"] = color[i];
                        list["highlight"] = color[i];
                        list["label"] = columnNames[i];
                    }
                    dict.Add(list);
                }
                json = JsonConvert.SerializeObject(dict);



            }
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
            string unit = data_pro[5];
            string json = "no";
            int date_ = 6;
            try
            {
                if (unit == "")
                {
                    conn.Open();
                    CommandText = "SELECT `bath/unit` as unit FROM `energy2.3`.electrical where `bath/unit`  is not null and type = " + data_pro[4] + " order by date asc limit 1";
                    cmd = new MySqlCommand(CommandText, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    unit = "6";
                    while (reader.Read())
                        unit = reader["unit"].ToString();
                    conn.Close();
                }
                if (data_pro[4] == "1")
                {
                    for (int i = 6; i < data_pro.Count(); i += 2)
                    {
                        conn.Open();
                        CommandText = "INSERT INTO electrical (permission_user_id,permission_building_buidlingid,permission_building_company_companycode,permission_energy_energy_id,type,date,`current meter`,`bath/unit`) VALUES (@userid,@building,@code,@energy,@type,@date,@meter,@unit)";
                        cmd = new MySqlCommand(CommandText, conn);
                        cmd.Parameters.AddWithValue("@userid", data_pro[0]);
                        cmd.Parameters.AddWithValue("@building", data_pro[1]);
                        cmd.Parameters.AddWithValue("@code", data_pro[2]);
                        cmd.Parameters.AddWithValue("@energy", data_pro[3]);
                        cmd.Parameters.AddWithValue("@type", data_pro[4]);
                        cmd.Parameters.AddWithValue("@unit", unit);
                        cmd.Parameters.AddWithValue("@date", data_pro[i]);
                        cmd.Parameters.AddWithValue("@meter", data_pro[i + 1]);
                        date_ += 2;
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    json = "yes";
                }
                else
                {
                    for (int i = 6; i < data_pro.Count(); i += 4)
                    {
                        conn.Open();
                        CommandText = "INSERT INTO electrical (permission_user_id,permission_building_buidlingid,permission_building_company_companycode,permission_energy_energy_id,type,date,peak,`off peak`,holiday,`bath/unit`) VALUES (@userid,@building,@code,@energy,@type,@date,@peak,@off,@holiday,@unit)";
                        cmd = new MySqlCommand(CommandText, conn);
                        cmd.Parameters.AddWithValue("@userid", data_pro[0]);
                        cmd.Parameters.AddWithValue("@building", data_pro[1]);
                        cmd.Parameters.AddWithValue("@code", data_pro[2]);
                        cmd.Parameters.AddWithValue("@energy", data_pro[3]);
                        cmd.Parameters.AddWithValue("@type", data_pro[4]);
                        cmd.Parameters.AddWithValue("@unit", unit);
                        cmd.Parameters.AddWithValue("@date", data_pro[i]);
                        cmd.Parameters.AddWithValue("@peak", data_pro[i + 1]);
                        cmd.Parameters.AddWithValue("@off", data_pro[i + 2]);
                        cmd.Parameters.AddWithValue("@holiday", data_pro[i + 3]);
                        date_ += 4;
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    json = "yes";
                }

            }
            catch (Exception)
            {
                if (data_pro[4] == "1")
                {
                    json = "the records were added until the exception date:" + data_pro[date_ - 2] + " record and followed records.";
                }
                else
                {
                    json = "the records were added until the exception date:" + data_pro[date_ - 4] + " record and followed records.";
                }
            }
            return JsonConvert.SerializeObject(json);
        }
        public string AddDiesel(string[] data_pro)
        {
            MySqlCommand cmd = null;
            MySqlConnection conn = new MySqlConnection(connectionString);
            string CommandText;
            string unit = data_pro[4];
            string json = "no";
            int date_ = 5;
            try
            {
                if (unit == "")
                {
                    conn.Open();
                    CommandText = "SELECT `bath/unit` as unit FROM `energy2.3`.diesel where `bath/unit`  is not null  order by date asc limit 1";
                    cmd = new MySqlCommand(CommandText, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    unit = "6";
                    while (reader.Read())
                        unit = reader["unit"].ToString();
                    conn.Close();
                }

                for (int i = 5; i < data_pro.Count(); i += 6)
                {
                    conn.Open();
                    CommandText = "INSERT INTO diesel (permission_user_id,permission_building_buidlingid,permission_building_company_companycode,permission_energy_energy_id,date,purchased,DGSet,Vehicle,OtherPurpose,Runningtime,`bath/unit`) VALUES (@userid,@building,@code,@energy,@date,@purchased,@dgset,@vehicle,@otherpurpose,@runtime,@unit)";
                    cmd = new MySqlCommand(CommandText, conn);
                    cmd.Parameters.AddWithValue("@userid", data_pro[0]);
                    cmd.Parameters.AddWithValue("@building", data_pro[1]);
                    cmd.Parameters.AddWithValue("@code", data_pro[2]);
                    cmd.Parameters.AddWithValue("@energy", data_pro[3]);
                    cmd.Parameters.AddWithValue("@unit", unit);
                    cmd.Parameters.AddWithValue("@date", data_pro[i]);
                    cmd.Parameters.AddWithValue("@purchased", data_pro[i + 1]);
                    cmd.Parameters.AddWithValue("@dgset", data_pro[i + 2]);
                    cmd.Parameters.AddWithValue("@vehicle", data_pro[i + 3]);
                    cmd.Parameters.AddWithValue("@otherpurpose", data_pro[i + 4]);
                    cmd.Parameters.AddWithValue("@runtime", data_pro[i + 5]);
                    date_ += 6;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                json = "yes";
            }
            catch (Exception)
            {
                json = "the records were added until the exception date:" + data_pro[date_ - 6] + " record and followed records.";
            }

            return JsonConvert.SerializeObject(json);
        }
        public string Addgasoline(string[] data_pro)
        {
            MySqlCommand cmd = null;
            MySqlConnection conn = new MySqlConnection(connectionString);
            string CommandText;
            string unit = data_pro[4];
            string json = "no";
            int date_ = 3;
            try
            {
                if (unit == "")
                {
                    conn.Open();
                    CommandText = "SELECT `bath/unit` as unit FROM `energy2.3`.gasoline where `bath/unit`  is not null  order by date asc limit 1";
                    cmd = new MySqlCommand(CommandText, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    unit = "6";
                    while (reader.Read())
                        unit = reader["unit"].ToString();
                    conn.Close();
                }
                for (int i = 5; i < data_pro.Count(); i += 3)
                {
                    conn.Open();
                    CommandText = "INSERT INTO gasoline (permission_user_id,permission_building_buidlingid,permission_building_company_companycode,permission_energy_energy_id,date,purchased,consumed,`bath/unit`) VALUES (@userid,@building,@code,@energy,@date,@purchased,@consumed,@unit)";
                    cmd = new MySqlCommand(CommandText, conn);
                    cmd.Parameters.AddWithValue("@userid", data_pro[0]);
                    cmd.Parameters.AddWithValue("@building", data_pro[1]);
                    cmd.Parameters.AddWithValue("@code", data_pro[2]);
                    cmd.Parameters.AddWithValue("@energy", data_pro[3]);
                    cmd.Parameters.AddWithValue("@unit", unit);
                    cmd.Parameters.AddWithValue("@date", data_pro[i]);
                    cmd.Parameters.AddWithValue("@purchased", data_pro[i + 1]);
                    cmd.Parameters.AddWithValue("@consumed", data_pro[i + 2]);
                    date_ += 3;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                json = "yes";
            }
            catch
            {
                json = "the records were added until the exception date:" + data_pro[date_ - 3] + " record and followed records.";
            }

            return JsonConvert.SerializeObject(json);
        }
        public string AddLPG(string[] data_pro)
        {
            MySqlCommand cmd = null;
            MySqlConnection conn = new MySqlConnection(connectionString);
            string CommandText;
            string json = "no";
            string unit = data_pro[4];
            int date_ = 5;

            try
            {
                if (unit == "")
                {
                    conn.Open();
                    CommandText = "SELECT `bath/unit` as unit FROM `energy2.3`.lpg where `bath/unit`  is not null order by date asc limit 1";
                    cmd = new MySqlCommand(CommandText, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    unit = "6";
                    while (reader.Read())
                        unit = reader["unit"].ToString();
                    conn.Close();
                }

                for (int i = 5; i < data_pro.Count(); i += 3)
                {
                    conn.Open();
                    CommandText = "INSERT INTO lpg (permission_user_id,permission_building_buidlingid,permission_building_company_companycode,permission_energy_energy_id,date,purchased,consumed,`bath/unit`) VALUES (@userid,@building,@code,@energy,@date,@purchased,@consumed,@unit)";
                    cmd = new MySqlCommand(CommandText, conn);
                    cmd.Parameters.AddWithValue("@userid", data_pro[0]);
                    cmd.Parameters.AddWithValue("@building", data_pro[1]);
                    cmd.Parameters.AddWithValue("@code", data_pro[2]);
                    cmd.Parameters.AddWithValue("@energy", data_pro[3]);
                    cmd.Parameters.AddWithValue("@unit", unit);
                    cmd.Parameters.AddWithValue("@date", data_pro[i]);
                    cmd.Parameters.AddWithValue("@purchased", data_pro[i + 1]);
                    cmd.Parameters.AddWithValue("@consumed", data_pro[i + 2]);
                    date_ += 3;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                json = "yes";
            }
            catch
            {
                json = "the records were added until the exception date:" + data_pro[date_ - 3] + " record and followed records.";
            }

            return json;
        }
        public string AddWater(string[] data_pro)
        {
            MySqlCommand cmd = null;
            MySqlConnection conn = new MySqlConnection(connectionString);
            string CommandText;
            string json = "no";
            string unit = data_pro[5];
            int temp = 0; //told the row can't add data
            int date_ = 6;
            try
            {
                //5 = factor
                //6 = start
                for (int i = 6; i < data_pro.Count(); i += 2)
                {
                    if (unit != "")
                    {
                        conn.Open();
                        CommandText = "INSERT INTO water (permission_user_id,permission_building_buidlingid,permission_building_company_companycode,permission_energy_energy_id,type,date,current,`bath/unit`) VALUES (@userid,@building,@code,@energy,@type,@date,@meter,@unit)";
                        cmd = new MySqlCommand(CommandText, conn);
                        cmd.Parameters.AddWithValue("@userid", data_pro[0]);
                        cmd.Parameters.AddWithValue("@building", data_pro[1]);
                        cmd.Parameters.AddWithValue("@code", data_pro[2]);
                        cmd.Parameters.AddWithValue("@energy", data_pro[3]);
                        cmd.Parameters.AddWithValue("@type", data_pro[4]);
                        cmd.Parameters.AddWithValue("@unit", unit);
                        cmd.Parameters.AddWithValue("@date", data_pro[i]);
                        cmd.Parameters.AddWithValue("@meter", data_pro[i + 1]);
                        temp++;
                        date_ += 2;
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    else
                    {
                        conn.Open();
                        CommandText = "SELECT `bath/unit` as unit FROM `energy2.3`.water where `bath/unit`  is not null and type = " + data_pro[4] + " order by date asc limit 1";
                        cmd = new MySqlCommand(CommandText, conn);
                        MySqlDataReader reader = cmd.ExecuteReader();
                        unit = "6";
                        while (reader.Read())
                            unit = reader["unit"].ToString();
                        i -= 2;
                        conn.Close();
                    }

                }
                json = "yes";
            }
            catch (Exception ex)
            {

                json = "the records were added until the exception date:" + data_pro[date_ - 2] + " record and followed records.";

            }
            return JsonConvert.SerializeObject(json);
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
            return JsonConvert.SerializeObject(json);
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
        public string insert_importxcel(string data_pro)
        {
            //var list = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, Dictionary<string, object>>>>(data_pro);
            Dictionary<string, dynamic> electric = JsonConvert.DeserializeObject<Dictionary<string, object>>(data_pro);
            var date = electric["nondesign"]["date"];
            var current = electric["nondesign"]["current"];
            List<DateTime> datetime = new List<DateTime>();
            List<string> non_current = new List<string>();
            for (int i = 0; i < date.Count; i++)
            {
                datetime.Add(Convert.ToDateTime(date[i]));
                non_current.Add(current[i].ToString());
            }
            var d_date = electric["design"]["date"];
            var d_peak = electric["design"]["peak"];
            var d_off = electric["design"]["off"];
            var d_holiday = electric["design"]["holiday"];
            List<DateTime> d_datetime = new List<DateTime>();
            List<string> peak = new List<string>();
            List<string> off = new List<string>();
            List<string> holiday = new List<string>();

            for (int i = 0; i < d_date.Count; i++)
            {
                d_datetime.Add(Convert.ToDateTime(date[i]));
                peak.Add(d_peak[i].ToString());
                off.Add(d_off[i].ToString());
                holiday.Add(d_holiday[i].ToString());
            }


            MySqlCommand cmd = null;
            MySqlConnection conn = new MySqlConnection(connectionString);
            string CommandText;
            try
            {
                conn.Open();
                CommandText = "INSERT INTO electrical (permission_user_id,permission_building_buidlingid,permission_building_company_companycode,permission_energy_energy_id) VALUES (@companycode,@companyname)";
                cmd = new MySqlCommand(CommandText, conn);
                //cmd.Parameters.AddWithValue("@companycode", compandy[0]);
                //cmd.Parameters.AddWithValue("@companyname", compandy[1]);
                cmd.ExecuteNonQuery();
                //conn.Close();

            }
            catch
            {
                throw;
            }

            return "d";
        }
        public string get_building_importxcel(string[] data_pro)
        {
            string json = "";
            MySqlCommand cmd = null;
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlDataAdapter adap;
            DataTable dt = new DataTable();
            string CommandText;
            try
            {
                string email = data_pro[0];
                string energy_id = data_pro[1];
                conn.Open();
                CommandText = "SELECT distinct building_buidlingid as building_id ,building_name as building_name FROM `energy2.3`.permission left join building on building_buidlingid=buidlingid where energy_energy_id = @id and  user_id=(select id from user where email = @email)";
                cmd = new MySqlCommand(CommandText, conn);
                cmd.Parameters.AddWithValue("@id", energy_id);
                cmd.Parameters.AddWithValue("@email", email);
                adap = new MySqlDataAdapter(cmd);
                conn.Close();
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
