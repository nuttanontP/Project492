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
    public partial class gridviewBuilding : System.Web.UI.Page
    {
        public DataTable myData = new DataTable();
        public string xxx = "sdfsdf";
        public string s = "45";
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
                string result = apiconnecter.PostData("GetCompandyCodeByEmail", Session["email"].ToString());
                string compandy_code = JsonConvert.DeserializeObject<string>(result);
                string result2 = apiconnecter.PostData("getbuilding", compandy_code);
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
    }
}