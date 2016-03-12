using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestAmmy.webconn;
namespace TestAmmy
{
    public partial class PermissionPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((string)Session["email"] == null)
                {
                    Response.Redirect("loginRegister.aspx");
                }
                string result = apiconnecter.PostData("permissiongrid", Session["codecompany"].ToString());
                string s = JsonConvert.DeserializeObject<string>(result);
                string object3 = apiconnecter.PostData("permissionadd", Session["codecompany"].ToString());
                string s2 = JsonConvert.DeserializeObject<string>(object3);
                string[] object4 = s2.Split(new string[] { "||" }, StringSplitOptions.None);
                if (s != "no")
                {
                    DataTable myData = JsonConvert.DeserializeObject<DataTable>(s);
                    this.permissionview.DataSource = myData;
                    this.permissionview.DataBind();
                }
                DataTable dt = new DataTable();
                if (object4[0] != "no")
                {
                    
                    dt = JsonConvert.DeserializeObject<DataTable>(object4[0]);
                    ddl_name.DataSource = dt;
                    ddl_name.DataValueField = "id";
                    ddl_name.DataTextField = "name";
                    ddl_name.DataBind();
                }

                if (object4[1] != "no")
                {
                    dt = new DataTable();
                    dt = JsonConvert.DeserializeObject<DataTable>(object4[1]);
                    ddl_building.DataSource = dt;
                    ddl_building.DataValueField = "buidlingid";
                    ddl_building.DataTextField = "building_name";
                    ddl_building.DataBind();
                }

                if (object4[2] != "no")
                {
                    dt = new DataTable();
                    dt = JsonConvert.DeserializeObject<DataTable>(object4[2]);
                    DataSet dSet = new DataSet();
                    dSet.Tables.Add(dt);
                    //YrChkBox.Items.Add(new ListItem(ddl_energy.DataTextField,ddl_energy.DataValueField));
                    YrChkBox.DataSource = dSet.Tables[0].DefaultView;
                    YrChkBox.DataBind();

                }



                }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            List<string> selected = YrChkBox.Items.Cast<ListItem>().Where(li => li.Selected).Select(li => li.Value).ToList();
            if(selected.Count == 0 || ddl_name.SelectedValue == "" || ddl_building.SelectedValue =="")
            {
                ScriptManager.RegisterStartupScript(this.Page, GetType(), "YourUniqueScriptKey123","alert('data is not correct');", true);
            }
            else
            {
                List<string> insert_data = new List<string>();
                insert_data.Add(ddl_name.SelectedValue);
                insert_data.Add(ddl_building.SelectedValue);
                insert_data.Add(Session["codecompany"].ToString());
                insert_data.AddRange(selected);

                //= { ddl_name.SelectedValue, ddl_building.SelectedValue, Session["codecompany"].ToString(), selected };
                string result = apiconnecter.PostData("Addpermission", insert_data.ToArray());
                string s = JsonConvert.DeserializeObject<string>(result);
                if (s != "no")
                {
                    string s_ = "add permission ok ";
                    ScriptManager.RegisterStartupScript(this.Page, GetType(), Guid.NewGuid().ToString(), "alert('" + s_ + "');window.location.href='PermissionPage.aspx';", true);
                }
                else
                {
                    string s_ = "something already added ";
                    ScriptManager.RegisterStartupScript(this, GetType(), "YourUniqueScriptKey", "alert('" + s_ + "');", true);
                    //ScriptManager.RegisterStartupScript(this.Page, GetType(), Guid.NewGuid().ToString(), "alert('" + s_ + "');window.location.href='PermissionPage.aspx';", true);
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('"+s_+"')", true);
                }
            }
            

        }

        protected void YrChkBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void permissionview_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            
        }

        protected void permissionview_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //del permission
            List<string> data_del = new List<string>();
            int rowIndex = Convert.ToInt32(e.RowIndex);
            data_del.Add(permissionview.DataKeys[rowIndex].Values[0].ToString());
            data_del.Add(permissionview.DataKeys[rowIndex].Values[1].ToString());
            data_del.Add(permissionview.DataKeys[rowIndex].Values[2].ToString());
            data_del.Add(permissionview.DataKeys[rowIndex].Values[3].ToString());
            string result = apiconnecter.PostData("delpermission", data_del.ToArray());
            string s = JsonConvert.DeserializeObject<string>(result);
            if (s != "no")
            {

                string s_ = "del ok!";
                Random rnd = new Random();
                string myRandomNo = rnd.Next(10000000, 99999999).ToString();
                ScriptManager.RegisterStartupScript(this, GetType(), "YourUniqueScriptKeyvcd", "alert('" + s_ + "');window.location.href='PermissionPage.aspx';", true);
            }
        }
    }
}