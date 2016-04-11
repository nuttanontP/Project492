using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Data;
using System.Globalization;
using TestAmmy.webconn;
using System.IO;
using System.Net;
//

namespace TestAmmy.Admin
{
    public partial class admin_detail : System.Web.UI.Page
    {
        public DateTime temp;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((string)Session["email"] == null)
                {
                    Response.Redirect("../View/login.aspx");
                }
                string result = apiconnecter.PostData("getuser", Session["email"].ToString());
                string s = JsonConvert.DeserializeObject<string>(result);
                if(s!= "no")
                {
                    DataTable myData = JsonConvert.DeserializeObject<DataTable>(s);
                    email.Value = myData.Rows[0]["email"].ToString();
                    firstName.Value = myData.Rows[0]["first_name"].ToString();
                    lastName.Value = myData.Rows[0]["last_name"].ToString();
                    jobTitle.Value = myData.Rows[0]["job"].ToString();
                    temp =  Convert.ToDateTime(myData.Rows[0]["dob"]).Date;
                    address.Value = myData.Rows[0]["address"].ToString();
                    phone.Value = myData.Rows[0]["phone"].ToString();

                }
                //email.Value = 
            }
            //uploadpdf
          
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //edit 
            string[] pro_data = { firstName.Value, lastName.Value, jobTitle.Value, dob2.Value, address.Value, phone.Value ,(string)Session["email"] };
            string result = apiconnecter.PostData("edituser", pro_data);
            string s = JsonConvert.DeserializeObject<string>(result);
            string s2 = JsonConvert.DeserializeObject<string>(s);
            if (s2 == "yes")
            {
                string s_ = "edit ok";
                ScriptManager.RegisterStartupScript(this.Page, GetType(), "YourUniqueScriptKey38644", "alert('" + s_ + "');window.location.href='admin_detail.aspx';", true);
            }
            else{
                string s_ = "can't edit";
                ScriptManager.RegisterStartupScript(this.Page, GetType(), "YourUniqueScriptKey38644", "alert('" + s_ + "');window.location.href='admin_detail.aspx';", true);
            }
        }
    }
}