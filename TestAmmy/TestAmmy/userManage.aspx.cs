using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestAmmy
{
    public partial class userManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void addData(object sender, EventArgs e)
        {
            Response.Redirect("addData.aspx");
        }

        protected void showGraph(object sender, EventArgs e)
        {
            Response.Redirect("viewGraphs.aspx");
        }

        protected void showFiles(object sender, EventArgs e)
        {
            Response.Redirect("viewFiles.aspx");

        }
    }
}