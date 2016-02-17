using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using API.Controllers;
using MODEL;
using TestAmmy.webconn;
using Newtonsoft.Json;


namespace TestAmmy
{
    public partial class addBuilding : System.Web.UI.Page
    {
        BuildingController api_build = new BuildingController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string email = (string)Session["email"];
                if (email == null)
                    Response.Redirect("loginRegister.aspx");
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            building model = new building();
            model.building_name = this.txtbuildingname.Text;
            model.building_detail = this.txtdetails.Value;
            string result = apiconnecter.PostData("GetCompandyCodeByEmail", Session["email"].ToString());
            string compandy_code = JsonConvert.DeserializeObject<string>(result);
            if(compandy_code!= "nofound" )
                model.company_companycode = compandy_code;
            else
            {
                string s = "not found company code!";
                ScriptManager.RegisterStartupScript(this.Page, GetType(), Guid.NewGuid().ToString(), "alert('" + s + "');window.location.href='adminDashBoard.aspx';", true);
            }
            //model.company_companycode = api_build.comp_code((string)Session["email"]);
            string[] pro_data = { model.building_name, model.building_detail, model.company_companycode};
            string result2 = apiconnecter.PostData("Addbuilding", pro_data);
            string s2 = JsonConvert.DeserializeObject<string>(result2);
            if(s2 == "1")
            {
                string s = "add building ok ";
                ScriptManager.RegisterStartupScript(this.Page, GetType(), Guid.NewGuid().ToString(), "alert('" + s + "');window.location.href='adminDashBoard.aspx';", true);
                
            }
            else
            {
                string s = "fail ";
                ScriptManager.RegisterStartupScript(this.Page, GetType(), Guid.NewGuid().ToString(), "alert('" + s + "');window.location.href='adminDashBoard.aspx';", true);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("gridviewBuilding.aspx");
        }
    }
}