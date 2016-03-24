using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestAmmy.webconn;

namespace TestAmmy.User
{
    public partial class user_addWater2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((string)Session["email"] == null)
                {
                    Response.Redirect("../View/login.aspx");
                }
                string[] data_pro = { Session["email"].ToString(), "5" };
                string result = apiconnecter.PostData("ddlpermission", data_pro);
                string s = JsonConvert.DeserializeObject<string>(result);
                if (!s.Equals("no"))
                {
                    DataTable dt = new DataTable();
                    dt = JsonConvert.DeserializeObject<DataTable>(s);
                    ddl_building.DataSource = dt;
                    ddl_building.DataValueField = "building_buidlingid";
                    ddl_building.DataTextField = "building_name";
                    ddl_building.DataBind();

                }

            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string[] date = Request.Form.GetValues("date0");
            date = date.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            string[] current = Request.Form.GetValues("meter0");
            current = current.Select(k => string.IsNullOrEmpty(k) ? "0.00" : k).ToArray();
            List<string> list1 = new List<string>();
            //find usrer_id 

            string result2 = apiconnecter.PostData("getuser", Session["email"].ToString());
            string s2 = JsonConvert.DeserializeObject<string>(result2);
            DataTable dt = JsonConvert.DeserializeObject<DataTable>(s2);
            var row = (from r in dt.AsEnumerable()
                       where r.Field<string>("email") == (string)Session["email"]
                       select r).First();

            string user_id = (row.ItemArray[0]).ToString(); // coloum[0] = id
            list1.Add(user_id); //primary key user_id
            list1.Add(ddl_building.SelectedValue); // building_id
            list1.Add(Session["codecompany"].ToString()); //companycode
            list1.Add("5"); //{energy type } 1:electrical 2:desiel 3: gasoline 4:lpg 5:water
            list1.Add("1"); //ENUM {1 2 3 ,supply ground, ground/supply}
            string[] new_date = new string[date.Count()];
            foreach (var item in date.Select((value, i) => new { i, value }))
            {
                //new_date[item.i] = DateTime.Parse(item.value).ToString("yyyy-MM-dd");
                new_date[item.i] = DateTime.ParseExact(item.value, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
                list1.Add(new_date[item.i]);
                list1.Add(current[item.i]);
            }
            string[] data_pro = list1.ToArray();
            string result = apiconnecter.PostData("AddWater", data_pro);
            string s = JsonConvert.DeserializeObject<string>(result);
            if (s != "no")
            {
                string s_ = "add  ok ";
                ScriptManager.RegisterStartupScript(this.Page, GetType(), "YourUniqueScriptKey38644", "alert('" + s_ + "');window.location.href='admin_addWater.aspx';", true);
                //ScriptManager.RegisterStartupScript(this, GetType(), "YourUniqueScriptKey", "alert('" + s_ + "');", true);
            }
            else
            {
                string s_ = "can't add ";
                ScriptManager.RegisterStartupScript(this.Page, GetType(), "YourUniqueScriptKey73645", "alert('" + s_ + "');window.location.href='admin_dashboard.aspx';", true);
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('"+s_+"')", true);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string[] date = Request.Form.GetValues("date1");
            date = date.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            string[] current = Request.Form.GetValues("meter1");
            current = current.Select(k => string.IsNullOrEmpty(k) ? "0.00" : k).ToArray();
            List<string> list1 = new List<string>();
            //find usrer_id 

            string result2 = apiconnecter.PostData("getuser", Session["email"].ToString());
            string s2 = JsonConvert.DeserializeObject<string>(result2);
            DataTable dt = JsonConvert.DeserializeObject<DataTable>(s2);
            var row = (from r in dt.AsEnumerable()
                       where r.Field<string>("email") == (string)Session["email"]
                       select r).First();

            string user_id = (row.ItemArray[0]).ToString(); // coloum[0] = id
            list1.Add(user_id); //primary key user_id
            list1.Add(ddl_building.SelectedValue); // building_id
            list1.Add(Session["codecompany"].ToString()); //companycode
            list1.Add("5"); //{energy type } 1:electrical 2:desiel 3: gasoline 4:lpg 5:water
            list1.Add("2"); //ENUM {1 2 3,supply ground, ground/supply}
            string[] new_date = new string[date.Count()];
            foreach (var item in date.Select((value, i) => new { i, value }))
            {
                //new_date[item.i] = DateTime.Parse(item.value).ToString("yyyy-MM-dd");
                new_date[item.i] = DateTime.ParseExact(item.value, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
                list1.Add(new_date[item.i]);
                list1.Add(current[item.i]);
            }
            string[] data_pro = list1.ToArray();
            string result = apiconnecter.PostData("AddWater", data_pro);
            string s = JsonConvert.DeserializeObject<string>(result);
            if (s != "no")
            {
                string s_ = "add  ok ";
                ScriptManager.RegisterStartupScript(this.Page, GetType(), "YourUniqueScriptKey38644", "alert('" + s_ + "');window.location.href='admin_addWater.aspx';", true);
                //ScriptManager.RegisterStartupScript(this, GetType(), "YourUniqueScriptKey", "alert('" + s_ + "');", true);
            }
            else
            {
                string s_ = "can't add ";
                ScriptManager.RegisterStartupScript(this.Page, GetType(), "YourUniqueScriptKey73645", "alert('" + s_ + "');window.location.href='admin_dashboard.aspx';", true);
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('"+s_+"')", true);
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string[] date = Request.Form.GetValues("date2");
            date = date.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            string[] current = Request.Form.GetValues("meter2");
            current = current.Select(k => string.IsNullOrEmpty(k) ? "0.00" : k).ToArray();
            List<string> list1 = new List<string>();
            //find usrer_id 

            string result2 = apiconnecter.PostData("getuser", Session["email"].ToString());
            string s2 = JsonConvert.DeserializeObject<string>(result2);
            DataTable dt = JsonConvert.DeserializeObject<DataTable>(s2);
            var row = (from r in dt.AsEnumerable()
                       where r.Field<string>("email") == (string)Session["email"]
                       select r).First();

            string user_id = (row.ItemArray[0]).ToString(); // coloum[0] = id
            list1.Add(user_id); //primary key user_id
            list1.Add(ddl_building.SelectedValue); // building_id
            list1.Add(Session["codecompany"].ToString()); //companycode
            list1.Add("5"); //{energy type } 1:electrical 2:desiel 3: gasoline 4:lpg 5:water
            list1.Add("3"); //ENUM {1 2 3 ,supply ground, ground/supply}
            string[] new_date = new string[date.Count()];
            foreach (var item in date.Select((value, i) => new { i, value }))
            {
                //new_date[item.i] = DateTime.Parse(item.value).ToString("yyyy-MM-dd");
                new_date[item.i] = DateTime.ParseExact(item.value, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
                list1.Add(new_date[item.i]);
                list1.Add(current[item.i]);
            }
            string[] data_pro = list1.ToArray();
            string result = apiconnecter.PostData("AddWater", data_pro);
            string s = JsonConvert.DeserializeObject<string>(result);
            if (s != "no")
            {
                string s_ = "add  ok ";
                ScriptManager.RegisterStartupScript(this.Page, GetType(), "YourUniqueScriptKey38644", "alert('" + s_ + "');window.location.href='admin_addWater.aspx';", true);
                //ScriptManager.RegisterStartupScript(this, GetType(), "YourUniqueScriptKey", "alert('" + s_ + "');", true);
            }
            else
            {
                string s_ = "can't add ";
                ScriptManager.RegisterStartupScript(this.Page, GetType(), "YourUniqueScriptKey73645", "alert('" + s_ + "');window.location.href='admin_dashboard.aspx';", true);
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('"+s_+"')", true);
            }
        }
    }
}