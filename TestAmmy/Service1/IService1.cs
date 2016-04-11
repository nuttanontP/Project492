using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Services;

namespace Service1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        // TODO: Add your service operations here
        /// <summary>
        /// check login
        /// </summary>
        /// <param name="userlogin">2 variables {usename,hashed password }</param>
        /// <returns>1 variables true,false</returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string login(string[] userlogin);

        /// <summary>
        /// get all user 
        /// </summary>
        /// <returns>json list user</returns>
        [OperationContract]
        //[WebGet(RequestFormat = WebMessageFormat.Json, UriTemplate = "/user/{id}/{temp}", ResponseFormat = WebMessageFormat.Json)]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string getuser(string email);

        [OperationContract]
        //[WebGet(RequestFormat = WebMessageFormat.Json, UriTemplate = "/user/{id}/{temp}", ResponseFormat = WebMessageFormat.Json)]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string edituser(string[] data_pro);

        /// <summary>
        /// get all company by admin of company
        /// </summary>
        /// <param name="companycode">code of company</param>
        /// <returns>datable grid json, no</returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string getbuilding(string companycode);

        /// <summary>
        /// Have a people in this system?
        /// </summary>
        /// <param name="user">{username,password}</param>
        /// <returns>yes = data raw of user ,no = wrongemail </returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string Registerstatus(string[] user);
        /// <summary>
        /// add new company when Register in first time
        /// </summary>
        /// <param name="compandy">{companycode,compandyname}</param>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void Addnewcompany(string[] compandy);

        /// <summary>
        /// add user 
        /// </summary>
        /// <param name="user">{email,password,first_name,last_name,status,company_companycode}</param>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string Adduser(string[] user);

        /// <summary>
        /// get company code by Email
        /// </summary>
        /// <param name="email">string email</param>
        /// <returns>yes = code,no = </returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string GetCompandyCodeByEmail(string email);
        /// <summary>
        /// add building
        /// </summary>
        /// <param name="building">building_name,building_detail,company_companycode</param>
        /// <returns>0 fail, 1 ok</returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string Addbuilding(string[] building);
        /// <summary>
        /// check this email can fill in data form
        /// </summary>
        /// <param name="permission">{email,building_id,codecompandy,energy type}</param>
        /// <returns>{yes,no}</returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string CheckPermission(string[] permission);

        /// <summary>
        /// Drop down list for select building in permission
        /// </summary>
        /// <param name="permission">{email,energy_id}</param>
        /// <returns>data table of this user</returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string ddlpermission(string[] data_pro);

        /// <summary>
        /// grid permission
        /// </summary>
        /// <param name="codecompany">code company</param>
        /// <returns>{datatable json,no}</returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string permissiongrid(string codecompany);


        /// <summary>
        /// ddl to show
        /// </summary>
        /// <param name="codecompany"></param>
        /// <returns>dt 3 dt user buiding energy</returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string permissionadd(string codecompany);


        /// <summary>
        /// add permission for add data
        /// </summary>
        /// <param name="permission">{id,building id,company code,energy id}</param>
        /// <returns>{yes,no}</returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string Addpermission(string[] permission);

        /// <summary>
        /// insert data electical 
        /// </summary>
        /// <param name="data_pro"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string AddElectric(string[] data_pro);

        /// <summary>
        /// insert diesel
        /// </summary>
        /// <param name="data_pro"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string AddDiesel(string[] data_pro);


        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string Addgasoline(string[] data_pro);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string Grid_electric(string[] data_pro);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string AddLPG(string[] data_pro);



        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string AddWater(string[] data_pro);


        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
            string AddOccupancy(string[] data_pro);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data_pro">user_id,buiding,code,energy_id</param>
        /// <returns>{yes,no}</returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string delpermission(string[] data_pro);

        /// <summary>
        /// delete building 
        /// </summary>
        /// <param name="data_pro"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string delbuilding(string[] data_pro);


        /// <summary>
        /// select data for show in graph
        /// </summary>
        /// <param name="data_pro">month</param>
        /// <returns>dt </returns>
        
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string selectdiesel(string[] data_pro);


        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string selectdiesel2(string[] data_pro);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string checkcomcode(string company);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string getuserbycompany(string company);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string getcompanydetial(string[] data_pro);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string getenergy(string building_id);

        /// <summary>
        /// show ghrap
        /// </summary>
        /// <param name="data_pro">building_id,energy_id,date_start,date_end</param>
        /// <returns>data table list for show gharp in ajax page admin_graph</returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string getdatagraph(string[] data_pro);

        


        

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string VerifyCaptcha(string response);


    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    
}
