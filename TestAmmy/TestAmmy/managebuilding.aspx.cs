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
using System.Data;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Configuration;
using System.Web.Http;

namespace TestAmmy
{
    public partial class managebuilding : System.Web.UI.Page
    {
        public string mis_service_ip = ConfigurationManager.AppSettings["service_ip"];
        public string mis_service_port = ConfigurationManager.AppSettings["service_port"];
        public string mis_service_name = ConfigurationManager.AppSettings["service_name"];
        BuildingController api_build = new BuildingController();
        [HttpGet]
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string email = (string)Session["email"];
                if (email == null)
                {
                   // Response.Redirect("loginRegister.aspx");
                }
                else if (email != null && (string)Session["status"] == "admin")
                {
                    //string json = api_build.gridbuilding();
                    // DataTable dt = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));
                    //BindData();
                }
                WebClient Proxy1 = new WebClient();
                Proxy1.Headers["Content-type"] = "application/json";
                MemoryStream ms = new MemoryStream();
                DataContractJsonSerializer serializerToUplaod = new DataContractJsonSerializer(typeof(string));
                serializerToUplaod.WriteObject(ms, "12345678");
                byte[] data = Proxy1.UploadData("http://" + mis_service_ip + ":" + mis_service_port + "/"+mis_service_name+"/"+"getbuilding",ms.ToArray());
                Stream stream = new MemoryStream(data);
                StreamReader read = new StreamReader(stream);
                string result = read.ReadToEnd();
                string s = JsonConvert.DeserializeObject<string>(result);
                if (!s.Equals("no"))
                {
                    DataTable myData = JsonConvert.DeserializeObject<DataTable>(s);
                    this.GridView1.DataSource = myData;
                    this.GridView1.DataBind();
                }

            }

        }
        public void BindData()
        {

           
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}