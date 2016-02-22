using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestAmmy.webconn;

namespace TestAmmy
{
    public partial class viewGraphs : System.Web.UI.Page
    {
        protected string[] date, dg, Vehicle, Other;
        protected string x;
        protected string[] y;
        protected void Page_Load(object sender, EventArgs e)
        {
            x = "goodmorning";
            string[] y = { "hi", "co" };
            DataTable dt = new DataTable();
            string[] pro_data = new string[2];
            string result = apiconnecter.PostData("selectdiesel", pro_data);
            string s = JsonConvert.DeserializeObject<string>(result);
            if (s != "no")
            {
                dt = JsonConvert.DeserializeObject<DataTable>(s);
                //string [] date = dt.AsEnumerable().Select(r => (DateTime)r.Field<string>("date")ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)).ToArray();
                date = dt.AsEnumerable().Select(r => r.Field<DateTime>("date").ToString("yyyy/MM/dd")).ToArray();
                //string[] date2 = date.Select(r => r.ToString("yyy/MM/dd")).ToArray();
                dg = dt.AsEnumerable().Select(r => r.Field<Double>("DGSet").ToString()).ToArray();
                Vehicle = dt.AsEnumerable().Select(r => r.Field<Double>("Vehicle").ToString()).ToArray();
                Other = dt.AsEnumerable().Select(r => r.Field<Double>("OtherPurpose").ToString()).ToArray();

                //new_date[item.i] = DateTime.ParseExact(item.value, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
               
            }
            //ClientScript.RegisterStartupScript(this.GetType(), "TestArrayScript", sb.ToString());


        }
        protected string[] senddate
        {
            set { date = value; }
            get { return date; }
        }
        protected string[] senddg
        {
            get { return dg; }
        }
        protected string[] sendVehicle
        {
            get { return Vehicle; }
        }
        protected string[] sendOther
        {
            get { return Other; }
        }
        protected string test
        {
            get { return "someword"; }
        }
    }
}