using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestAmmy.webconn;
using Newtonsoft.Json;
using System.Data;

namespace TestAmmy.View
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_signIn_Click(object sender, EventArgs e)
        {
            string[] data_pro = { email.Value, password.Value };
            string result = apiconnecter.PostData("Registerstatus", data_pro);
            string s1 = JsonConvert.DeserializeObject<string>(result);
            if (s1 != "wrongemail")
            {
                DataTable myData = JsonConvert.DeserializeObject<DataTable>(s1);
                Session["email"] = myData.Rows[0]["email"].ToString();
                Session["status"] = myData.Rows[0]["status"].ToString();
                Session["codecompany"] = myData.Rows[0]["company_companycode"].ToString();
                if (Session["status"].ToString().Equals("admin"))
                    Response.Redirect("../Admin/admin_dashboard.aspx");
                else
                    Response.Redirect("../User/user_dashboard.aspx");
            }
            else
            {
                this.Labelvalidation.Attributes["style"] = "color:red; font-weight:bold;";
                this.Labelvalidation.Text = "wrong username or password";
            }
        }
    }
}