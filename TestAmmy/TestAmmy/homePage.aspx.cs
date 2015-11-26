using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestAmmy
{
    public partial class homePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void userManage(object sender, EventArgs e)
        {
            Response.Redirect("userManage.aspx");
        }

        protected void addData(object sender, EventArgs e)
        {
            Response.Redirect("addData.aspx");

        }
    }
}