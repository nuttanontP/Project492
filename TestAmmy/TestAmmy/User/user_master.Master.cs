using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestAmmy.webconn;
using Newtonsoft.Json;
using System.Data;

namespace TestAmmy.User
{
    public partial class user_master : System.Web.UI.MasterPage
    {
        protected string name, surname,full_name,status;
        protected void Page_Load(object sender, EventArgs e)
        {
            string email = (string)Session["email"];
            
            if(email == null)
            {
                Response.Redirect("../View/login.aspx");
            }
            string result = apiconnecter.PostData("getuser", email);
            string s = JsonConvert.DeserializeObject<string>(result);
            if (s != "no")
            {
                DataTable dt = JsonConvert.DeserializeObject<DataTable>(s);
                name = dt.Rows[0]["first_name"].ToString();
                surname = dt.Rows[0]["last_name"].ToString();
                status = dt.Rows[0]["status"].ToString();
                full_name = name + " " + surname;
            }

        }
        protected void singout_Click(object sender, EventArgs e)
        {
            Session.Remove("email");
            Session.Remove("status");
            Session.Remove("codecompany");
            Response.Redirect("../View/login.aspx");
        }
    }
}