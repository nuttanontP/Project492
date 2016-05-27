using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Data;
using System.Globalization;
using TestAmmy.webconn;
using System.IO;
using System.Net;
//

namespace TestAmmy.User2
{
    public partial class admin_detail : System.Web.UI.Page
    {
        string full_name = "";
        public string full_name2 = "";
        public DateTime temp;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((string)Session["email"] == null)
                {
                    Response.Redirect("../View/login.aspx");
                }
                string result = apiconnecter.PostData("getuser", Session["email"].ToString());
                string s = JsonConvert.DeserializeObject<string>(result);
                if(s!= "no")
                {
                    DataTable myData = JsonConvert.DeserializeObject<DataTable>(s);
                    email.Value = myData.Rows[0]["email"].ToString();
                    firstName.Value = myData.Rows[0]["first_name"].ToString();
                    lastName.Value = myData.Rows[0]["last_name"].ToString();
                    full_name2 = firstName.Value+" "+ lastName.Value;
                    jobTitle.Value = myData.Rows[0]["job"].ToString();
                    //time_join = myData.Rows[0]["timestamp"].ToString();
                    var temp2 = myData.Rows[0]["dob"].ToString();
                    
                    if(temp2.Length != 0)
                    {
                        temp = Convert.ToDateTime(myData.Rows[0]["dob"]).Date;
                    }
                    else
                    {
                        temp = DateTime.Now;
                    }
                    address.Value = myData.Rows[0]["address"].ToString();
                    phone.Value = myData.Rows[0]["phone"].ToString();

                }
                
                //email.Value = 
            }
            //uploadpdf
          
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //edit 
            if (FileUpload1.FileName != "")
            {
                    full_name = firstName.Value;
                    string OriginalFileName = FileUpload1.FileName;
                string ContentType = FileUpload1.PostedFile.ContentType;
                string[] tokens = ContentType.Split(new string[] { "/" }, StringSplitOptions.None);
                string OriginalFileType = "";// 95-005-A-45_file.pdf = "application/pdf"
                if (ContentType == "image/jpg" || ContentType == "image/png" || ContentType == "image/jpeg")
                {
                    OriginalFileType = "jpg";
                }
           
                string newfilename = full_name;
                string newPicNameFull = newfilename + "." + OriginalFileType;

                string filePath = Server.MapPath("/assets/img/nontpic/" + newPicNameFull);
                FileUpload1.SaveAs(filePath);
            }
            string[] pro_data = { firstName.Value, lastName.Value, jobTitle.Value, dob2.Value, address.Value, phone.Value ,(string)Session["email"] };
            string result = apiconnecter.PostData("edituser", pro_data);
            string s = JsonConvert.DeserializeObject<string>(result);
            string s2 = JsonConvert.DeserializeObject<string>(s);
            if (s2 == "yes")
            {
                string s_ = "Your details have been changed.";
                ScriptManager.RegisterStartupScript(this.Page, GetType(), "YourUniqueScriptKey38644", "alert('" + s_ + "');window.location.href='admin_detail.aspx';", true);
            }
            else{
                string s_ = "Sorry, Can't save your details.";
                ScriptManager.RegisterStartupScript(this.Page, GetType(), "YourUniqueScriptKey38644", "alert('" + s_ + "');window.location.href='admin_detail.aspx';", true);
            }
        }
    }
}