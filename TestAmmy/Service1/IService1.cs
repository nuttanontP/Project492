using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

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
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string getuser();

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
        void Adduser(string[] user);

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
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    
}
