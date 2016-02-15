using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestAmmy
{
    public partial class addPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string[] date = Request.Form.GetValues("date");
            date = date.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            string[] meter = Request.Form.GetValues("meter");
            meter = meter.Where(x => !string.IsNullOrEmpty(x)).ToArray();

        }
    }
}