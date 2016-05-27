using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestAmmy.webconn;

namespace TestAmmy.Admin
{
    public partial class admin_dashboard : System.Web.UI.Page
    {
        protected string[] organization = new string[6];
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string email = (string)Session["email"];
                if (email == null)
                {
                    Response.Redirect("../View/login.aspx");
                }
                string code = Session["codecompany"].ToString();
                string result = apiconnecter.PostData("get_organization", code);
                string s1 = JsonConvert.DeserializeObject<string>(result);
                if (s1 != "no")
                {
                    DataTable myData = JsonConvert.DeserializeObject<DataTable>(s1);
                    organization[0] = myData.Rows[0]["Organization"].ToString();
                    organization[1] = myData.Rows[0]["Code"].ToString();
                    organization[2] = myData.Rows[0]["join"].ToString();
                    organization[3] = myData.Rows[0]["Buildings"].ToString();
                    organization[4] = myData.Rows[0]["company_address"].ToString();
                    organization[5] = myData.Rows[0]["company_area"].ToString();
                }
            }
        }
    }
}