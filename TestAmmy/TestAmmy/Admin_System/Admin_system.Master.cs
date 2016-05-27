using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestAmmy.Admin_System
{
    public partial class Admin_system : System.Web.UI.MasterPage
    {
        protected void singout_Click(object sender, EventArgs e)
        {
            Session.Remove("email");
            Session.Remove("status");
            Session.Remove("codecompany");
            Response.Redirect("../View/login.aspx");
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}