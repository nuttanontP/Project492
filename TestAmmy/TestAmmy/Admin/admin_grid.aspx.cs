using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestAmmy.webconn;

namespace TestAmmy.Admin
{
    public partial class admin_grid : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {



            if (!IsPostBack)
            {
                if ((string)Session["email"] == null)
                {
                    Response.Redirect("../View/login.aspx");
                }
                //electrical
                string[] data_pro = new string[] { Session["codecompany"].ToString(), "admin", "1" };
                string result = apiconnecter.PostData("getprevious", data_pro);
                string s = JsonConvert.DeserializeObject<string>(result);
                if (!s.Equals("\"no\""))
                {
                    DataTable myData = JsonConvert.DeserializeObject<DataTable>(s);
                    this.electric.DataSource = myData;
                    this.electric.DataBind();
                    if (electric.Rows.Count > 0)
                    {
                        electric.UseAccessibleHeader = true;
                        electric.HeaderRow.TableSection = TableRowSection.TableHeader;
                        electric.FooterRow.TableSection = TableRowSection.TableFooter;
                    }

                }
                //diesel
                data_pro = new string[] { Session["codecompany"].ToString(), "admin", "2" };
                result = apiconnecter.PostData("getprevious", data_pro);
                s = JsonConvert.DeserializeObject<string>(result);
                if (!s.Equals("\"no\""))
                {
                    DataTable myData = JsonConvert.DeserializeObject<DataTable>(s);
                    this.diesel.DataSource = myData;
                    this.diesel.DataBind();
                    if (diesel.Rows.Count > 0)
                    {
                        diesel.UseAccessibleHeader = true;
                        diesel.HeaderRow.TableSection = TableRowSection.TableHeader;
                        diesel.FooterRow.TableSection = TableRowSection.TableFooter;
                    }

                }
                //gasoline
                data_pro = new string[] { Session["codecompany"].ToString(), "admin", "3" };
                result = apiconnecter.PostData("getprevious", data_pro);
                s = JsonConvert.DeserializeObject<string>(result);
                if (!s.Equals("\"no\""))
                {
                    DataTable myData = JsonConvert.DeserializeObject<DataTable>(s);
                    this.gasoline.DataSource = myData;
                    this.gasoline.DataBind();
                    if (gasoline.Rows.Count > 0)
                    {
                        gasoline.UseAccessibleHeader = true;
                        gasoline.HeaderRow.TableSection = TableRowSection.TableHeader;
                        gasoline.FooterRow.TableSection = TableRowSection.TableFooter;
                    }

                }
                //lpg
                data_pro = new string[] { Session["codecompany"].ToString(), "admin", "4" };
                result = apiconnecter.PostData("getprevious", data_pro);
                s = JsonConvert.DeserializeObject<string>(result);
                if (!s.Equals("\"no\""))
                {
                    DataTable myData = JsonConvert.DeserializeObject<DataTable>(s);
                    this.lpg.DataSource = myData;
                    this.lpg.DataBind();
                    if (lpg.Rows.Count > 0)
                    {
                        lpg.UseAccessibleHeader = true;
                        lpg.HeaderRow.TableSection = TableRowSection.TableHeader;
                        lpg.FooterRow.TableSection = TableRowSection.TableFooter;
                    }

                }
                //water
                data_pro = new string[] { Session["codecompany"].ToString(), "admin", "5" };
                result = apiconnecter.PostData("getprevious", data_pro);
                s = JsonConvert.DeserializeObject<string>(result);
                if (!s.Equals("\"no\""))
                {
                    DataTable myData = JsonConvert.DeserializeObject<DataTable>(s);
                    this.water.DataSource = myData;
                    this.water.DataBind();
                    if (water.Rows.Count > 0)
                    {
                        water.UseAccessibleHeader = true;
                        water.HeaderRow.TableSection = TableRowSection.TableHeader;
                        water.FooterRow.TableSection = TableRowSection.TableFooter;
                    }

                }
                //occupancy
                data_pro = new string[] { Session["codecompany"].ToString(), "admin", "6" };
                result = apiconnecter.PostData("getprevious", data_pro);
                s = JsonConvert.DeserializeObject<string>(result);
                if (!s.Equals("\"no\""))
                {
                    DataTable myData = JsonConvert.DeserializeObject<DataTable>(s);
                    this.occupancy.DataSource = myData;
                    this.occupancy.DataBind();
                    if (occupancy.Rows.Count > 0)
                    {
                        occupancy.UseAccessibleHeader = true;
                        occupancy.HeaderRow.TableSection = TableRowSection.TableHeader;
                        occupancy.FooterRow.TableSection = TableRowSection.TableFooter;
                    }

                }
            }
        }

        protected void electric_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            List<string> data_del = new List<string>();
            int rowIndex = Convert.ToInt32(e.RowIndex);
            data_del.Add(electric.DataKeys[rowIndex].Values[0].ToString());
            string[] data_pro = new string[] { Session["codecompany"].ToString(), "1", data_del[0].ToString() };
            string result = apiconnecter.PostData("deleteprevious", data_pro);
            string s = JsonConvert.DeserializeObject<string>(result);
            string s2 = JsonConvert.DeserializeObject<string>(s);
            if (s2 == "yes")
            {
                string s_ = "del ok!";
                Random rnd = new Random();
                string myRandomNo = rnd.Next(10000000, 99999999).ToString();
                ScriptManager.RegisterStartupScript(this, GetType(), "YourUniqueScriptKey" + myRandomNo, "alert('" + s_ + "');window.location.href='admin_grid.aspx';", true);
            }

        }

        protected void diesel_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            List<string> data_del = new List<string>();
            int rowIndex = Convert.ToInt32(e.RowIndex);
            data_del.Add(diesel.DataKeys[rowIndex].Values[0].ToString());
            string[] data_pro = new string[] { Session["codecompany"].ToString(), "2", data_del[0].ToString() };
            string result = apiconnecter.PostData("deleteprevious", data_pro);
            string s = JsonConvert.DeserializeObject<string>(result);
            string s2 = JsonConvert.DeserializeObject<string>(s);
            if (s2 == "yes")
            {
                string s_ = "del ok!";
                Random rnd = new Random();
                string myRandomNo = rnd.Next(10000000, 99999999).ToString();
                ScriptManager.RegisterStartupScript(this, GetType(), "YourUniqueScriptKey" + myRandomNo, "alert('" + s_ + "');window.location.href='admin_grid.aspx';", true);
            }
        }

        protected void gasoline_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            List<string> data_del = new List<string>();
            int rowIndex = Convert.ToInt32(e.RowIndex);
            data_del.Add(gasoline.DataKeys[rowIndex].Values[0].ToString());
            string[] data_pro = new string[] { Session["codecompany"].ToString(), "3", data_del[0].ToString() };
            string result = apiconnecter.PostData("deleteprevious", data_pro);
            string s = JsonConvert.DeserializeObject<string>(result);
            string s2 = JsonConvert.DeserializeObject<string>(s);
            if (s2 == "yes")
            {
                string s_ = "del ok!";
                Random rnd = new Random();
                string myRandomNo = rnd.Next(10000000, 99999999).ToString();
                ScriptManager.RegisterStartupScript(this, GetType(), "YourUniqueScriptKey" + myRandomNo, "alert('" + s_ + "');window.location.href='admin_grid.aspx';", true);
            }
        }

        protected void lpg_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            List<string> data_del = new List<string>();
            int rowIndex = Convert.ToInt32(e.RowIndex);
            data_del.Add(lpg.DataKeys[rowIndex].Values[0].ToString());
            string[] data_pro = new string[] { Session["codecompany"].ToString(), "4", data_del[0].ToString() };
            string result = apiconnecter.PostData("deleteprevious", data_pro);
            string s = JsonConvert.DeserializeObject<string>(result);
            string s2 = JsonConvert.DeserializeObject<string>(s);
            if (s2 == "yes")
            {
                string s_ = "del ok!";
                Random rnd = new Random();
                string myRandomNo = rnd.Next(10000000, 99999999).ToString();
                ScriptManager.RegisterStartupScript(this, GetType(), "YourUniqueScriptKey" + myRandomNo, "alert('" + s_ + "');window.location.href='admin_grid.aspx';", true);
            }
        }

        protected void water_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            List<string> data_del = new List<string>();
            int rowIndex = Convert.ToInt32(e.RowIndex);
            data_del.Add(water.DataKeys[rowIndex].Values[0].ToString());
            string[] data_pro = new string[] { Session["codecompany"].ToString(), "5", data_del[0].ToString() };
            string result = apiconnecter.PostData("deleteprevious", data_pro);
            string s = JsonConvert.DeserializeObject<string>(result);
            string s2 = JsonConvert.DeserializeObject<string>(s);
            if (s2 == "yes")
            {
                string s_ = "del ok!";
                Random rnd = new Random();
                string myRandomNo = rnd.Next(10000000, 99999999).ToString();
                ScriptManager.RegisterStartupScript(this, GetType(), "YourUniqueScriptKey" + myRandomNo, "alert('" + s_ + "');window.location.href='admin_grid.aspx';", true);
            }
        }

        protected void occupancy_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            List<string> data_del = new List<string>();
            int rowIndex = Convert.ToInt32(e.RowIndex);
            data_del.Add(occupancy.DataKeys[rowIndex].Values[0].ToString());
            string[] data_pro = new string[] { Session["codecompany"].ToString(), "6", data_del[0].ToString() };
            string result = apiconnecter.PostData("deleteprevious", data_pro);
            string s = JsonConvert.DeserializeObject<string>(result);
            string s2 = JsonConvert.DeserializeObject<string>(s);
            if (s2 == "yes")
            {
                string s_ = "del ok!";
                Random rnd = new Random();
                string myRandomNo = rnd.Next(10000000, 99999999).ToString();
                ScriptManager.RegisterStartupScript(this, GetType(), "YourUniqueScriptKey" + myRandomNo, "alert('" + s_ + "');window.location.href='admin_grid.aspx';", true);
            }
        }
    }
}