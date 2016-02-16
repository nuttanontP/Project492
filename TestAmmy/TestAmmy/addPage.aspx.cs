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
                
               
                string result  = apiconnecter.PostData("ddlpermission", Session["email"].ToString());
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
                    ddl_building.DataValueField = "no!";
                    ddl_building.DataTextField = "No Permission";
                    ddl_building.DataBind();
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //string[] date = Request.Form.GetValues("date");
            //date = date.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            //string[] meter = Request.Form.GetValues("meter");
            //meter = meter.Where(x => !string.IsNullOrEmpty(x)).ToArray();

        }
    }
}