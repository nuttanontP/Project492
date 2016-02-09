using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using API.Controllers;
namespace TestAmmy
{
    public partial class testPage : System.Web.UI.Page
    {
        checkadd api = new checkadd();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["email"] == null)
                {
                    Response.Redirect("loginRegister.aspx");
                }
            
            ddltest ddls = new ddltest();
            DataTable dt = ddls.ddl("12345678");
            ddlbuilding.DataSource = dt;
            ddlbuilding.DataTextField = "building_name";
            ddlbuilding.DataValueField = "idBuilding";
            ddlbuilding.DataBind();
                //ddlbuilding.Items.Insert(0, new ListItem("<Select Building>", "0"));
            }
        }

        protected void button_sumbit_Click(object sender, EventArgs e)
        {
            string ddl_building = ddlbuilding.SelectedItem.Text;
            string ddl_building_id = ddlbuilding.SelectedValue;
            string ddl_energytype_id = ddlEnergytype.SelectedValue;
            string email = Session["email"].ToString();
           bool check_add =  api.addpermision(Session["email"].ToString(), "12345678",ddl_building_id,ddl_energytype_id);
            if (check_add)

            {
                string s = "add permission ok ";
                ScriptManager.RegisterStartupScript(this.Page, GetType(), Guid.NewGuid().ToString(), "alert('" + s + "');window.location.href='UserManage.aspx';", true);
              
            }
            else
            {
                string s = "fail ";
                ScriptManager.RegisterStartupScript(this.Page, GetType(), Guid.NewGuid().ToString(), "alert('" + s + "');window.location.href='UserManage.aspx';", true);
            }
        }

        protected void button_sumbit_DataBinding(object sender, EventArgs e)
        {

        }
    }
}