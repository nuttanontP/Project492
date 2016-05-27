using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OfficeOpenXml;
using Newtonsoft.Json;
using System.IO;
using System.Data;
//using Newtonsoft.Json;
using System.Globalization;
using TestAmmy.webconn;

namespace TestAmmy.Admin

{
    public partial class admin_implement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //ddl_building
            }
        }

        protected void submit_Click(object sender, EventArgs e)
        {

            {
                if (FileUpload1.HasFile && Path.GetExtension(FileUpload1.FileName) == ".xlsx")
                {
                    List<string> data_pro = new List<string>();
                    List<string> data_pro2 = new List<string>();
                    var tbl = new DataTable();
                    var sheet_at = sheet.Value;
                    string json = import_excel(sheet_at);
                    //string result = apiconnecter.PostData("ddlpermission", data_pro);
                    data_pro2 = JsonConvert.DeserializeObject<List<string>>(json);
                    List<string> list1 = new List<string>();
                    string result2 = apiconnecter.PostData("getuser", Session["email"].ToString());
                    string s2 = JsonConvert.DeserializeObject<string>(result2);
                    DataTable dt = JsonConvert.DeserializeObject<DataTable>(s2);
                    var row = (from r in dt.AsEnumerable()
                               where r.Field<string>("email") == (string)Session["email"]
                               select r).First();

                    string user_id = (row.ItemArray[0]).ToString();
                    list1.Add(user_id); //primary key user_id
                    string[] building2 = Request.Form.GetValues("ctl00$main_content$building");
                    list1.Add(building2[0]); // building_id
                    list1.Add(Session["codecompany"].ToString()); //companycode
                    list1.Add("3"); //{energy type } 1:electrical 2:desiel 3:diesel
                    list1.AddRange(data_pro2);
                    string result = apiconnecter.PostData("Addgasoline", list1.ToArray());
                    string s = JsonConvert.DeserializeObject<string>(result);
                    string s_2 = JsonConvert.DeserializeObject<string>(s);
                    if (s_2 == "yes")
                    {
                        string s_ = "import complete.";
                        ScriptManager.RegisterStartupScript(this.Page, GetType(), "YourUniqueScriptKey33674", "alert('" + s_ + "');window.location.href='#';", true);
                        //ScriptManager.RegisterStartupScript(this, GetType(), "YourUniqueScriptKey", "alert('" + s_ + "');", true);
                    }
                    else
                    {
                        string s_ = "fail to import";
                        ScriptManager.RegisterStartupScript(this, GetType(), "YourUniqueScriptKey", "alert('" + s_ + "');window.location.href='#';", true);
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('"+s_+"')", true);
                    }
                }
                else
                {
                    //UploadStatusLabel.Text = "You did not specify a file to upload.";
                }
            }
        }
        protected string import_excel(string sheet)
        {
            using (var excel = new ExcelPackage(FileUpload1.PostedFile.InputStream))
            {
                
                int[] dimantion = new int[4];
                var tbl = new DataTable();
                var ws = excel.Workbook.Worksheets[""];
                var date = excel.Workbook.Worksheets["General Info"];
                string month = date.Cells[14, 3].Text;
                string year = date.Cells[14, 4].Text;
                string factor = "";
                if (sheet == "1")
                {
                    dimantion = new int[4] { 8, 1, 38, 10 };
                    ws = excel.Workbook.Worksheets["Electricity Details"];
                     factor = ws.Cells[3, 5].Text;
                    //factor = (3,E)

                }
                else if (sheet == "2")
                {
                   
                    ws = excel.Workbook.Worksheets["Diesel details"];
                    //factor = (3,H) not sure
                }
                else if (sheet == "3")
                {
                    dimantion = new int[4] { 7, 1, 37, 3 };
                    ws = excel.Workbook.Worksheets["Gasoline details"];
                     factor = ws.Cells[40,3].Text;
                    //factor = (40,C)
                }
                else if (sheet == "4")
                {
                    ws = excel.Workbook.Worksheets["LPG Details"];
                    //factor = (5,B)
                }
                else if (sheet == "5")
                {
                    ws = excel.Workbook.Worksheets["Water Cons Details"];
                    //factor_supply = 3,E
                    //factor_ground = 4,G
                    //factor_both =   4,L
                }
                else if (sheet == "6")
                {
                    ws = excel.Workbook.Worksheets["Occupancy Details"];
                    //total floor area = 5,E
                    //total number of floor = 6,E
                }
                if (sheet == "1")
                {
                    Dictionary<string, object> electrical = new Dictionary<string, object>();
                    electrical["design"] = new Dictionary<string, object>();
                    electrical["nondesign"] = new Dictionary<string, object>();
                    electrical["factor"] = ws.Cells[3, 5].Text;
                    Dictionary<string, object> design = new Dictionary<string, object>();
                    design["date"] = new List<object>();
                    design["peak"] = new List<object>();
                    design["off"] = new List<object>();
                    design["holiday"] = new List<object>();
                  
                    Dictionary<string, object> nondesign = new Dictionary<string, object>();
                    nondesign["date"] = new List<object>();
                    nondesign["current"] = new List<object>();


                    foreach (var firstRowCell in ws.Cells[dimantion[0], dimantion[1], dimantion[0], dimantion[3]])
                        tbl.Columns.Add(String.Format("Col{0}", firstRowCell.Start.Column));
                    for (int rowNum = dimantion[0]; rowNum <= dimantion[2]; rowNum++)
                    {
                        var wsRow = ws.Cells[rowNum, dimantion[1], rowNum, dimantion[3]];
                        string day = wsRow[rowNum, 1].Text;
                        day = day.Length == 1 ? ("0" + wsRow[rowNum, 1].Text) : wsRow[rowNum, 1].Text;
                        DateTime dt = DateTime.ParseExact(year + "-" + month + "-" + day, "yyyy-MMMM-dd", CultureInfo.InvariantCulture);
                        if (wsRow[rowNum, 3].Text != "")
                        {
                            ((List<object>)nondesign["date"]).Add(dt);
                            ((List<object>)nondesign["current"]).Add(wsRow[rowNum, 3].Text);
                        }
                        if (wsRow[rowNum, 7].Text != "" || wsRow[rowNum, 8].Text != "" || wsRow[rowNum, 9].Text != "")
                        {
                            ((List<object>)design["date"]).Add(dt);
                            ((List<object>)design["peak"]).Add(wsRow[rowNum, 7].Text);
                            ((List<object>)design["off"]).Add(wsRow[rowNum, 8].Text);
                            ((List<object>)design["holiday"]).Add(wsRow[rowNum, 9].Text);
                        }
                    }
                    electrical["design"] = design;
                    electrical["nondesign"] = nondesign;

                    string json = JsonConvert.SerializeObject(electrical);
                    return json;
                }
                if(sheet == "3")
                {
                    List<string> data_pro = new List<string>();
                    data_pro.Add(factor);
                    foreach (var firstRowCell in ws.Cells[dimantion[0], dimantion[1], dimantion[0], dimantion[3]])
                        tbl.Columns.Add(String.Format("Col{0}", firstRowCell.Start.Column));
                    for (int rowNum = dimantion[0]; rowNum <= dimantion[2]; rowNum++)
                    {
                        var wsRow = ws.Cells[rowNum, dimantion[1], rowNum, dimantion[3]];
                        string day = wsRow[rowNum, 1].Text;
                        day = day.Length == 1 ? ("0" + wsRow[rowNum, 1].Text) : wsRow[rowNum, 1].Text;
                        DateTime dt = DateTime.ParseExact(year + "-" + month + "-" + day, "yyyy-MMMM-dd", CultureInfo.InvariantCulture);
                        if(wsRow[rowNum, 2].Text != "" || wsRow[rowNum, 3].Text != "")
                        {
                            data_pro.Add(dt.ToString("yyyy-MM-dd"));
                            data_pro.Add(wsRow[rowNum,2].Text);
                            data_pro.Add(wsRow[rowNum,3].Text);
                        }
                    }
                    string json = JsonConvert.SerializeObject(data_pro);
                    return (json);
                }
               

            }
            return("");
        }

        protected void submit_Command(object sender, CommandEventArgs e)
        {
            //string[] data_pro = { , building.Value,, };
        }
    }
}