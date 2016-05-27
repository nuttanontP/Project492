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

namespace TestAmmy.User2
{
    public partial class admin_addOccupancy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((string)Session["email"] == null)
                {
                    Response.Redirect("../View/login.aspx");
                }
                string[] data_pro = { Session["email"].ToString(), "6" };
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
            string[] date = Request.Form.GetValues("date");
            date = date.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            string[] av_room = Request.Form.GetValues("av_room");
            string[] oc_room = Request.Form.GetValues("oc_room");
            string[] number = Request.Form.GetValues("number");
            av_room = av_room.Select(k => string.IsNullOrEmpty(k) ? "0.00" : k).ToArray();
            oc_room = oc_room.Select(k => string.IsNullOrEmpty(k) ? "0.00" : k).ToArray();
            number = number.Select(k => string.IsNullOrEmpty(k) ? "0.00" : k).ToArray();
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
            list1.Add("6"); //{energy type } 1:electrical 2:desiel 6:occupancy
            string[] new_date = new string[date.Count()];
            foreach (var item in date.Select((value, i) => new { i, value }))
            {
                //new_date[item.i] = DateTime.Parse(item.value).ToString("yyyy-MM-dd");
                new_date[item.i] = DateTime.ParseExact(item.value, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
                list1.Add(new_date[item.i]);
                list1.Add(av_room[item.i]);
                list1.Add(oc_room[item.i]);
                list1.Add(number[item.i]);
            }
            string[] data_pro = list1.ToArray();
            string result = apiconnecter.PostData("AddOccupancy", data_pro);
            string s = JsonConvert.DeserializeObject<string>(result);
            if (s != "no")
            {
                string s_ = "record(s) successfully saved.";
                ScriptManager.RegisterStartupScript(this.Page, GetType(), "YourUniqueScriptKey38644", "alert('" + s_ + "');window.location.href='admin_addOccupancy.aspx';", true);
                //ScriptManager.RegisterStartupScript(this, GetType(), "YourUniqueScriptKey", "alert('" + s_ + "');", true);
            }
            else
            {
                string s_ = "can't add ";
                ScriptManager.RegisterStartupScript(this.Page, GetType(), "YourUniqueScriptKey73645", "alert('" + s_ + "');window.location.href='admin_adminDashBoard.aspx';", true);
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('"+s_+"')", true);
            }
        }
    }
}