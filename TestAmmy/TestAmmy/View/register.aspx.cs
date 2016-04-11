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
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void register_Click(object sender, EventArgs e)
        {
            
            string type = category.Value;
            if (password.Value != password2.Value)
            {
                this.Labelvalidation.Attributes["style"] = "color:red; font-weight:bold;";
                this.Labelvalidation.Text = "password not match ";
            }
            if (type == "") //null
            {
                this.Labelvalidation.Attributes["style"] = "color:red; font-weight:bold;";
                this.Labelvalidation.Text = "please select ";
            }
            else if (type == "0") //add by code
            {
                string result = apiconnecter.PostData("checkcomcode", com_passs.Value);
                string s = JsonConvert.DeserializeObject<string>(result);
                if (s != "no")
                {
                    string[] pro_data = { email.Value, password.Value, firstname.Value, lastname.Value, "user", com_passs.Value };
                    string result2 = apiconnecter.PostData("Adduser", pro_data);
                    string s2 = JsonConvert.DeserializeObject<string>(result2);
                    if (s2 != "no")
                    {
                        Session["email"] = email.Value;
                        Session["status"] = "user";
                        Session["codecompany"] = com_passs.Value;
                        Response.Redirect("../User/user_dashboard.aspx");
                        
                    }
                    else
                    {
                        this.Labelvalidation.Attributes["style"] = "color:red; font-weight:bold;";
                        this.Labelvalidation.Text = "can't add this user because email used";
                    }
                }
                else 
                {
                    this.Labelvalidation.Attributes["style"] = "color:red; font-weight:bold;";
                    this.Labelvalidation.Text = "company code not exist in system ";
                }
            }
            else //add by number
            {
                Random rnd = new Random();
                string code = rnd.Next(10000000, 99999999).ToString();
                string[] company = { code, com_passs.Value };
                apiconnecter.PostDatanoReturn("Addnewcompany", company);
                string[] pro_data = { email.Value, password.Value, firstname.Value, lastname.Value, "admin", code };
                string result2 = apiconnecter.PostData("Adduser", pro_data);
                string s2 = JsonConvert.DeserializeObject<string>(result2);
                if (s2 != "no")
                {
                    Session["email"] = email.Value;
                    Session["status"] = "admin";
                    Session["codecompany"] = com_passs.Value;
                    Response.Redirect("../Admin/admin_dashboard.aspx");

                }
                else
                {
                    this.Labelvalidation.Attributes["style"] = "color:red; font-weight:bold;";
                    this.Labelvalidation.Text = "can't add this user because email used";
                }
                //add new company
            }
            //string x = category.Value;
        }
    }
}