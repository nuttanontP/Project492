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
    public partial class adminDashBoard : System.Web.UI.Page
    {
        protected string companyname, code, address, joined, buildings;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((string)Session["email"] == null)
                {
                    Response.Redirect("loginRegister.aspx");
                }
                string[] pro_data = { (string)Session["codecompany"] };
                string result = apiconnecter.PostData("getcompanydetial", pro_data);
                string s = JsonConvert.DeserializeObject<string>(result);
                if(s!= "no")
                {
                    DataTable dt = JsonConvert.DeserializeObject<DataTable>(s);
                    companyname = dt.Rows[0]["company_name"].ToString();
                    code = dt.Rows[0]["companycode"].ToString();
                    address = dt.Rows[0]["company_address"].ToString();
                    joined = dt.Rows[0]["company_join"].ToString();
                }
                else
                {

                }
            }
        }
    }
}