using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestAmmy
{
    public partial class adminMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
       
        protected void SignOut_Click(object sender, EventArgs e)
        {
            Session.Remove("email");
            Session.Remove("status");
            Session.Remove("codecompany");
                 
            Response.Redirect("loginRegister.aspx");

        }
        
        
    }
}