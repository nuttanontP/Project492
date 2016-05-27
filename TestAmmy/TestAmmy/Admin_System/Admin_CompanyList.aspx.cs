using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestAmmy.webconn;

namespace TestAmmy.Admin_System
{
    public partial class Admin_CompanyList : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((string)Session["email"] == null)
                {
                    Response.Redirect("../View/login.aspx");
                }
                
                string result = apiconnecter.PostData("get_companylist", "");
                string s = JsonConvert.DeserializeObject<string>(result);

                if (!s.Equals("\"no\""))
                {
                    DataTable myData = JsonConvert.DeserializeObject<DataTable>(s);
                    this.companygrid.DataSource = myData;
                    this.companygrid.DataBind();
                }
            }
        }
    }
}