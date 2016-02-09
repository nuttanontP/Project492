using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using API.Controllers;

namespace TestAmmy
{
    public partial class addData : System.Web.UI.Page
    {
        ScoreController api = new ScoreController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!IsPostBack)
                {
                    if(Session["email"] == null)
                    {
                        Response.Redirect("loginRegister.aspx");
                    }
                }
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            List<int> energy = new List<int>();
            try
            {
                energy = new List<int> {Convert.ToInt32(this.txtmeter1.Text),
                Convert.ToInt32(this.txtmeter2.Text),
                Convert.ToInt32(this.txtmeter3.Text),
                Convert.ToInt32(this.txtmeter4.Text)};
                if (api.InsertPowerElectric(energy) || energy.Count != 0)
                {
                    Response.Redirect("viewGraphs.aspx");
                }
            }
            catch
            {
                this.txtmeter1.Attributes["style"] = "color:red; font-weight:bold;";
                this.txtmeter1.Text = "FAIL TO INSERT DATA";
                this.txtmeter2.Attributes["style"] = "color:red; font-weight:bold;";
                this.txtmeter2.Text = "FAIL TO INSERT DATA";
                this.txtmeter3.Attributes["style"] = "color:red; font-weight:bold;";
                this.txtmeter3.Text = "FAIL TO INSERT DATA";
                this.txtmeter4.Attributes["style"] = "color:red; font-weight:bold;";
                this.txtmeter4.Text = "FAIL TO INSERT DATA";
                this.txtmeter5.Attributes["style"] = "color:red; font-weight:bold;";
                this.txtmeter5.Text = "FAIL TO INSERT DATA";
                this.txtmeter6.Attributes["style"] = "color:red; font-weight:bold;";
                this.txtmeter6.Text = "FAIL TO INSERT DATA";
            }
            
            



        }
    }
}
