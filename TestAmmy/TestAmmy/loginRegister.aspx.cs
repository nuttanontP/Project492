using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using API.Controllers;

namespace TestAmmy
{
    public partial class loginRegister : System.Web.UI.Page
    {
        ScoreController api = new ScoreController();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String username = this.txtemail.Text;
            String password = this.txtpassword.Text;
            
            Response.Redirect("userManage.aspx");
        }
    }
}