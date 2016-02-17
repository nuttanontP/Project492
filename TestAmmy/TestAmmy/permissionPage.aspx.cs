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
    public partial class PermissionPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if((string)Session["email"] == null)
                {
                    Response.Redirect("loginRegister.aspx");
                }
                string result = apiconnecter.PostData("permissiongrid", Session["codecompany"].ToString());
                string s = JsonConvert.DeserializeObject<string>(result);
                string object3 = apiconnecter.PostData("permissionadd", Session["codecompany"].ToString());
                string s2 = JsonConvert.DeserializeObject<string>(object3);
                string[] object4 = s2.Split(new string[] { "||" }, StringSplitOptions.None);
                if (s != "no")
                {
                  DataTable  myData = JsonConvert.DeserializeObject<DataTable>(s);
                    this.permissionview.DataSource = myData;
                    this.permissionview.DataBind();

                    DataTable dt = new DataTable();
                    dt = JsonConvert.DeserializeObject<DataTable>(object4[0]);
                    ddl_name.DataSource = dt;
                    ddl_name.DataValueField = "id";
                    ddl_name.DataTextField = "name";
                    ddl_name.DataBind();

                    dt = new DataTable();
                    dt = JsonConvert.DeserializeObject<DataTable>(object4[1]);
                    ddl_building.DataSource = dt;
                    ddl_building.DataValueField = "buidlingid"; 
                    ddl_building.DataTextField = "building_name";
                    ddl_building.DataBind();

                    dt = new DataTable();
                    dt = JsonConvert.DeserializeObject<DataTable>(object4[2]);
                    ddl_energy.DataSource = dt;
                    ddl_energy.DataValueField = "energy_id";
                    ddl_energy.DataTextField = "energy_name";
                    ddl_energy.DataBind();

                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string[] insert_data = { ddl_name.SelectedValue, ddl_building.SelectedValue, Session["codecompany"].ToString(), ddl_energy.SelectedValue };
            string result = apiconnecter.PostData("Addpermission", insert_data);
            string s = JsonConvert.DeserializeObject<string>(result);
            if (s != "no")
            {
                string s_ = "add permission ok ";
                ScriptManager.RegisterStartupScript(this.Page, GetType(), Guid.NewGuid().ToString(), "alert('" + s_ + "');window.location.href='PermissionPage.aspx';", true);
            }
            else
            {
                string s_ = "u can't add this permission ";
                ScriptManager.RegisterStartupScript(this.Page, GetType(), Guid.NewGuid().ToString(), "alert('" + s_ + "');window.location.href='PermissionPage.aspx';", true);
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('"+s_+"')", true);
            }

        }
    }
}