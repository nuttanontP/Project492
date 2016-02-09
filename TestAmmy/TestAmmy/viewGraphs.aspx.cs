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
    public partial class viewGraphs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ScoreController api = new ScoreController();
             String temp = api.getEnergyData();
            dynamic dynObj = JsonConvert.DeserializeObject(temp);
            if (!IsPostBack)
            {
                this.txtenergy1.Text = dynObj[0].power;
                this.txtenergy2.Text = dynObj[1].power;
                this.txtenergy3.Text = dynObj[2].power;
                this.txtenergy4.Text = dynObj[3].power;
                this.txtenergy5.Text = dynObj[4].power;
                this.txtenergy6.Text = dynObj[5].power;
            }

        }
    }
}