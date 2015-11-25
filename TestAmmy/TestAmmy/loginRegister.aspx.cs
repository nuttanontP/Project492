using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using API;
using API.Controllers;
using MODEL;
namespace TestAmmy
{
    public partial class loginRegister : System.Web.UI.Page
    {
        ScoreController api = new ScoreController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String username = this.txtemail.Text;
            String password = this.txtpassword.Text;
            if (api.checklogins(username, password))
            {
                Session["email"] = username;
                Response.Redirect("userManage.aspx");
            }
            else
            {

                this.LabelValidation.Attributes["style"] = "color:red; font-weight:bold;";
                this.LabelValidation.Text = "wronge e-mail";
            }

        }

        protected void submit_Click(object sender, EventArgs e)
        {

            user_db model = new user_db();
            model.name = this.txtfirstname.Text;
            model.Email = this.txtemail2.Text;
            model.company = this.txtcompany.Text;
            model.surname = this.txtlastname.Text;
            model.position = this.txtPosition.Text;
            if (this.txtconfrimpassword.Text.Equals(this.txtpassword2.Text))
            {
                model.password = this.txtpassword2.Text;
                if (api.InsertUser(model))
                {
                    Session["email"] = model.Email;
                    Response.Redirect("userManage.aspx");
                }
                else
                {
                    this.Labelregister.Attributes["style"] = "color:red; font-weight:bold;";
                    this.Labelregister.Text = "wronge insert data";
                }

            }
            else
            {
                this.Labelregister.Attributes["style"] = "color:red; font-weight:bold;";
                this.Labelregister.Text = "wronge confirm password";
            }





        }
    }
}