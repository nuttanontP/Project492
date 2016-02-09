using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using API.Controllers;
using Newtonsoft.Json;
namespace TestAmmy
{
    public partial class userManage : System.Web.UI.Page
    {
        ScoreController api = new ScoreController();

        protected string name  { get; set; }
        protected string surname { get; set; }
        protected string email1 { get; set; }
        protected string company { get; set; }
        protected string position { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string email = (string)Session["email"];
                if (email == null) {
                    Response.Redirect("loginRegister.aspx");
                }

                //string userdata = api.getUserData(email);
                //dynamic dynObj =  JsonConvert.DeserializeObject(userdata);
                //email1 = (string)Session["email"];
                //surname = dynObj[0].surname;
                //name = dynObj[0].name;
               // company = dynObj[0].company;
               // position = dynObj[0].position;
            }
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