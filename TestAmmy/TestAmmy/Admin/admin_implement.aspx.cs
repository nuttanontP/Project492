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

namespace TestAmmy.Admin

{
    public partial class admin_implement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {

            {
                if (FileUpload1.HasFile && Path.GetExtension(FileUpload1.FileName) == ".xlsx")
                {
                    using (var excel = new ExcelPackage(FileUpload1.PostedFile.InputStream))
                    {
                        var tbl = new DataTable();
                        var nont = excel.Workbook.Worksheets.Count;
                        var sheet_at = sheet.Value;
                        var ws = excel.Workbook.Worksheets["Electricity Details"];

                        var hasHeader = false;  // adjust accordingly
                                                // add DataColumns to DataTable
                        var start_row = 8;
                        var start_col = 1;
                        foreach (var firstRowCell in ws.Cells[start_row, start_col, start_row, ws.Dimension.End.Column])
                            tbl.Columns.Add(hasHeader ? firstRowCell.Text : String.Format("Col{0}", firstRowCell.Start.Column));

                        // add DataRows to DataTable
                        int startRow = hasHeader ? 1 : start_row;
                        for (int rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
                        {
                            var wsRow = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
                            DataRow row = tbl.NewRow();
                            foreach (var cell in wsRow)
                                row[cell.Start.Column - 1] = cell.Text;
                            tbl.Rows.Add(row);
                        }
                        string dyn = JsonConvert.SerializeObject(tbl);
                        var msg = String.Format("DataTable successfully created from excel-file. Colum-count:{0} Row-count:{1} , worksheet {2}",
                                                tbl.Columns.Count, tbl.Rows.Count, nont);
                        //UploadStatusLabel.Text = dyn;
                        //GridView1.DataSource = tbl;
                        //GridView1.DataBind();
                        List<object> colValues = new List<object>();
                        //foreach (DataRow row in tbl.Rows)
                        //{
                        //    colValues.Add(row["ColumnName"]);
                        //}
                        //colValues = (from DataRow row in tbl.Rows select row["ColumnName"]).ToList();
                        colValues = tbl.AsEnumerable().Select(r => r["Col2"]).ToList();
                        //TextBox1.Text = colValues;
                    }
                }
                else
                {
                    //UploadStatusLabel.Text = "You did not specify a file to upload.";
                }
            }
        }
    }
}