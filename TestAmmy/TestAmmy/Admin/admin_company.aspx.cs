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
    public partial class admin_company : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((string)Session["email"] == null)
                {
                    Response.Redirect("../View/login.aspx");
                }
                string[] pro_data = { Session["codecompany"].ToString() };
                string result = apiconnecter.PostData("getcompanydetial",pro_data[0]);
                string s = JsonConvert.DeserializeObject<string>(result);
                if (s != "no")
                {
                    DataTable myData = JsonConvert.DeserializeObject<DataTable>(s);
                    address2.Value = myData.Rows[0]["company_address"].ToString();
                    area2.Value = myData.Rows[0]["company_area"].ToString();
                    string data_type = myData.Rows[0]["company_type"].ToString();
                    if(data_type == "")
                    {
                        ddl_type.SelectedValue = "0";
                    }
                    else if(data_type == "Hotel")
                    {
                        ddl_type.SelectedValue = "1";
                    }
                    else if (data_type == "Home")
                    {
                        ddl_type.SelectedValue = "2";
                    }
                    else if (data_type == "Company")
                    {
                        ddl_type.SelectedValue = "3";
                    }
                    else if (data_type == "Education")
                    {
                        ddl_type.SelectedValue = "4";
                    }

                }

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string[] pro_data = { address2.Value, area2.Value , Session["codecompany"].ToString() ,ddl_type.SelectedIndex.ToString()};
            string result = apiconnecter.PostData("editcompanydetial", pro_data);
            string s = JsonConvert.DeserializeObject<string>(result);
            string s2 = JsonConvert.DeserializeObject<string>(s);
            if (s2 == "yes")
            {
                string s_ = "Your details company have been changed.";
                ScriptManager.RegisterStartupScript(this.Page, GetType(), "YourUniqueScriptKey38644", "alert('" + s_ + "');window.location.href='admin_company.aspx';", true);
            }
            else {
                string s_ = "Sorry, Can't save your details company.";
                ScriptManager.RegisterStartupScript(this.Page, GetType(), "YourUniqueScriptKey38644", "alert('" + s_ + "');window.location.href='admin_company.aspx';", true);
            }
        }
    }
}