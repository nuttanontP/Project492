using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestAmmy.webconn;

namespace TestAmmy
{
    public partial class addPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((string)Session["email"] == null)
                {
                    Response.Redirect("loginRegister.aspx");
                }
                string[] data_pro = { Session["email"].ToString() ,"1"};
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
                else
                {

                    //ddl_building.SelectedIndex = 0;  // selecting default Text by index Number
                    ddl_building.SelectedItem.Text = "No building"; // selecting Default Text by Text
                    //ddl_building.SelectedValue = "Your Object Value"; // Selecting Default Text by value

                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string[] date = Request.Form.GetValues("date");
            date = date.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            string[] meter = Request.Form.GetValues("meter");
            meter = meter.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            List<string> list1 = new List<string>();
            //find usrer_id 
            string result2 = apiconnecter.GetData("getuser");
            string s2 = JsonConvert.DeserializeObject<string>(result2);
            DataTable dt = JsonConvert.DeserializeObject<DataTable>(s2);
            var row = (from r in dt.AsEnumerable()
                       where r.Field<string>("email") == (string)Session["email"]
                       select r).First();

            string user_id = (row.ItemArray[0]).ToString(); // coloum[0] = id
            list1.Add(user_id); //primary key user_id
            list1.Add(ddl_building.SelectedValue); // building_id
            list1.Add(Session["codecompany"].ToString()); //companycode
            list1.Add("1"); //{energy type } 1:electrical 2:desiel
            list1.Add("1"); //ENUM {0 1 2 ,null non design , design}
            string[] new_date = new string[date.Count()];
            foreach (var item in date.Select((value, i) => new { i, value }))
            {
                new_date[item.i] = DateTime.Parse(item.value).ToString("yyyy-MM-dd");
                list1.Add(new_date[item.i]);
                list1.Add(meter[item.i]);
            }
            string[] data_pro = list1.ToArray();
            string result = apiconnecter.PostData("Adddata", data_pro);
            string s = JsonConvert.DeserializeObject<string>(result);
            if (s != "no")
            {
                string s_ = "add  ok ";
                ScriptManager.RegisterStartupScript(this.Page, GetType(), Guid.NewGuid().ToString(), "alert('" + s_ + "');window.location.href='addPage.aspx';", true);
            }
            else
            {
                string s_ = "can't add ";
                ScriptManager.RegisterStartupScript(this.Page, GetType(), Guid.NewGuid().ToString(), "alert('" + s_ + "');window.location.href='adminDashBoard.aspx';", true);
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('"+s_+"')", true);
            }
        }
    }
}