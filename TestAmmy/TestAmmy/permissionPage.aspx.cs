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
                if(s != "no")
                {
                  DataTable  myData = JsonConvert.DeserializeObject<DataTable>(s);
                    this.permissionview.DataSource = myData;
                    this.permissionview.DataBind();

                    DataTable dt = new DataTable();
                    dt = JsonConvert.DeserializeObject<DataTable>(s);
                    ddl_name.DataSource = dt;
                    ddl_name.DataValueField = "id";
                    ddl_name.DataTextField = "name";
                    ddl_name.DataBind();

                    ddl_building.DataSource = dt;
                    ddl_building.DataValueField = "building_buidlingid"; 
                    ddl_building.DataTextField = "building_name";
                    ddl_building.DataBind();

                    ddl_energy.DataSource = dt;
                    ddl_energy.DataValueField = "energy_id";
                    ddl_energy.DataTextField = "energy_name";
                    ddl_energy.DataBind();

                }
            }
        }
    }
}