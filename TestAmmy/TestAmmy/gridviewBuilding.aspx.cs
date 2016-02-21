using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestAmmy.webconn;
using MODEL;

namespace TestAmmy
{
    public partial class gridviewBuilding : System.Web.UI.Page
    {
        public DataTable myData = new DataTable();
        public string s = "";
        public string [] s2;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string email = (string)Session["email"];
                string status = (string)Session["status"];
                if (email == null && status == null)
                {
                    Response.Redirect("loginRegister.aspx");
                }
                //string result = apiconnecter.PostData("GetCompandyCodeByEmail", Session["email"].ToString());
                string result = (string)Session["codecompany"];
                //string compandy_code = JsonConvert.DeserializeObject<string>(result);
                //string result2 = apiconnecter.PostData("getbuilding", compandy_code);
                string result2 = apiconnecter.PostData("getbuilding", result);
                s = JsonConvert.DeserializeObject<string>(result2);
                if (!s.Equals("no"))
                {
                    myData = JsonConvert.DeserializeObject<DataTable>(s);
                    this.buildgrid.DataSource = myData;
                    this.buildgrid.DataBind();
                }

            }
        }

        protected void buildgrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void addbuild_Click(object sender, EventArgs e)
        {
            Response.Redirect("addBuilding.aspx");
        }

        protected void buildgrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            List<string> data_del = new List<string>();
            int rowIndex = Convert.ToInt32(e.RowIndex);
            data_del.Add(buildgrid.DataKeys[rowIndex].Values[0].ToString());
            string result = apiconnecter.PostData("delbuilding", data_del.ToArray());
            string s = JsonConvert.DeserializeObject<string>(result);
            if (s != "no")
            {

                string s_ = "del ok!";
                Random rnd = new Random();
                string myRandomNo = rnd.Next(10000000, 99999999).ToString();
                ScriptManager.RegisterStartupScript(this, GetType(), "YourUniqueScriptKey"+myRandomNo, "alert('" + s_ + "');window.location.href='gridviewBuilding.aspx';", true);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            building model = new building();
            model.building_name = this.txtbuildingname.Text;
            model.building_detail = this.txtdetails.Value;
            model.company_companycode = (string)Session["codecompany"];
            string[] prodata = { model.building_name, model.building_detail, model.company_companycode };
            string result = apiconnecter.PostData("Addbuilding", prodata);
            string s = JsonConvert.DeserializeObject<string>(result);
            if(s == "1")
            {
                string s_ = "add building ok ";
                ScriptManager.RegisterStartupScript(this.Page, GetType(), Guid.NewGuid().ToString(), "alert('" + s_ + "');window.location.href='gridviewBuilding.aspx';", true);
            }
            else
            {
                string s_ = "can't add building";
                ScriptManager.RegisterStartupScript(this, GetType(), "YourUniqueScriptKey198", "alert('" + s_ + "');", true);
            }
        }
    }
}