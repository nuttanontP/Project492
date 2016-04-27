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
                    var tbl = new DataTable();
                    var sheet_at = sheet.Value;
                    string json = import_excel(sheet_at);
                    //string result = apiconnecter.PostData("ddlpermission", data_pro);
                    //string s = JsonConvert.DeserializeObject<string>(json);
                    string code = Session["code_company"].ToString();
                    string result = apiconnecter.PostData("insert_importxcel", json);
                    string s = JsonConvert.DeserializeObject<string>(result);

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
                if (sheet == "1")
                {
                    dimantion = new int[4] { 8, 1, 38, 10 };
                    ws = excel.Workbook.Worksheets["Electricity Details"];
                    string factor = ws.Cells[3, 5].Text;
                    //factor = (3,E)

                }
                else if (sheet == "2")
                {
                    ws = excel.Workbook.Worksheets["Diesel details"];
                    //factor = (3,H) not sure
                }
                else if (sheet == "3")
                {
                    ws = excel.Workbook.Worksheets["Gasoline details"];
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
               

            }
            return "";
        }

        protected void submit_Command(object sender, CommandEventArgs e)
        {
            //string[] data_pro = { , building.Value,, };
        }
    }
}