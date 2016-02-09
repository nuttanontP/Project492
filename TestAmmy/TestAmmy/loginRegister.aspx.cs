using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using API;
using API.Controllers;
using API.Encode;
using MODEL;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Configuration;
using TestAmmy.webconn;
using System.Data;

namespace TestAmmy
{
    public partial class loginRegister : System.Web.UI.Page
    {
        public string mis_service_ip = ConfigurationManager.AppSettings["service_ip"];
        public string mis_service_port = ConfigurationManager.AppSettings["service_port"];
        public string mis_service_name = ConfigurationManager.AppSettings["service_name"];
        userController api_user = new userController();
        companyController api_comp = new companyController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //string x = MD5.MD5Hash("1234");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = this.txtemail.Text;
            string password = this.txtpassword.Text;
            string[] pro_data = { username, password };
            string result = apiconnecter.PostData("Registerstatus", pro_data);
            string s = JsonConvert.DeserializeObject<string>(result);
            if (s != "wrongemail")
            {
                DataTable myData = JsonConvert.DeserializeObject<DataTable>(s);
                Session["email"] = myData.Rows[0]["email"].ToString();
                Session["status"] = myData.Rows[0]["status"].ToString();
                if (Session["status"].ToString().Equals("admin"))
                    Response.Redirect("adminDashBoard.aspx");
                else
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
            user model = new user();
            model.email = this.txtemail2.Text;
            model.password = this.txtpassword.Text;
            model.first_name = this.txtfirstname.Text;
            model.last_name = this.txtlastname.Text;
            string code_comp = this.txtcompanycode.Text;
            model.status = "user";  //normarl user people
            if (code_comp == "")
            {
                //add new company !
                Random rnd = new Random();
                string myRandomNo = rnd.Next(10000000, 99999999).ToString();
                model.company_companycode = myRandomNo;
                company model_com = new company();
                model_com.companycode = myRandomNo;
                model_com.company_name = this.txtcompany.Text;
                string[] model_company = { model_com.companycode, model_com.company_name };
                apiconnecter.PostDatanoReturn("Addnewcompany", model_company);
                model.status = "admin"; //Admin user people
            }
            else
            {
                //already have company !
                model.company_companycode = code_comp;
            }


            if (this.txtconfrimpassword.Text.Equals(this.txtpassword2.Text))
            {

                string[] pro_data = { model.email, model.password, model.first_name, model.last_name, model.status, model.company_companycode };
                apiconnecter.PostDatanoReturn("Adduser", pro_data);
                string[] data_check = { model.email, model.password };
                string result = apiconnecter.PostData("Registerstatus", data_check);
                string s = JsonConvert.DeserializeObject<string>(result);
                if (s != "wrongemail")
                {
                    DataTable myData = JsonConvert.DeserializeObject<DataTable>(s);
                    Session["email"] = myData.Rows[0]["email"].ToString();
                    Session["status"] = myData.Rows[0]["status"].ToString();
                    if (Session["status"].ToString().Equals("admin"))
                        Response.Redirect("adminDashBoard.aspx");
                    else
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