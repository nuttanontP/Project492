using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Web.Http;

namespace TestAmmy.webconn
{
    public static class apiconnecter
    {
        public static string mis_service_ip = ConfigurationManager.AppSettings["service_ip"];
        public static string mis_service_port = ConfigurationManager.AppSettings["service_port"];
        public static string mis_service_name = ConfigurationManager.AppSettings["service_name"];
        [HttpGet]
        public static string GetData(string function_name)
        {
            WebClient Proxy1 = new WebClient();
            Proxy1.Headers["Content-type"] = "application/json";
            //byte[] data = Proxy1.DownloadData("http://" + mis_service_ip + ":" + mis_service_port + "/" + mis_service_name + "/" + function_name);
            byte[] data = Proxy1.DownloadData("http://" + mis_service_ip + "/" + mis_service_name + "/" + function_name);
            Stream stream = new MemoryStream(data);
            StreamReader streamread = new StreamReader(stream);
            string result = streamread.ReadToEnd();
            return result;
        }
        [HttpPost]
        public static string PostData(string function_name,string pro_data2)
        {
            string pro_data = pro_data2;
            WebClient Proxy1 = new WebClient();
            Proxy1 = new WebClient();
            Proxy1.Headers["Content-type"] = "application/json";
            MemoryStream ms = new MemoryStream();
            DataContractJsonSerializer serializerToUplaod = new DataContractJsonSerializer(typeof(string));
            serializerToUplaod.WriteObject(ms, pro_data);
            //byte[] data = Proxy1.UploadData("http://" + mis_service_ip + ":" + mis_service_port + "/" + mis_service_name + "/" + function_name, "POST", ms.ToArray());
            byte[] data = Proxy1.UploadData("http://" + mis_service_ip + "/" + mis_service_name + "/" + function_name, "POST", ms.ToArray());
            Stream stream = new MemoryStream(data);
            StreamReader streamread = new StreamReader(stream);
            string result = streamread.ReadToEnd();
            return result;
        }
        public static string PostData(string function_name, string[] pro_data2)
        {
            string[] pro_data = pro_data2;
            WebClient Proxy1 = new WebClient();
            Proxy1 = new WebClient();
            Proxy1.Headers["Content-type"] = "application/json";
            MemoryStream ms = new MemoryStream();
            DataContractJsonSerializer serializerToUplaod = new DataContractJsonSerializer(typeof(string[]));
            serializerToUplaod.WriteObject(ms, pro_data);
            //byte[] data = Proxy1.UploadData("http://" + mis_service_ip + ":" + mis_service_port + "/" + mis_service_name + "/" + function_name, "POST", ms.ToArray());
            byte[] data = Proxy1.UploadData("http://" + mis_service_ip + "/" + mis_service_name + "/" + function_name, "POST", ms.ToArray());
            Stream stream = new MemoryStream(data);
            StreamReader streamread = new StreamReader(stream);
            string result = streamread.ReadToEnd();
            return result;
        }
        public static void PostDatanoReturn(string function_name, string[] pro_data2)
        {
            string[] pro_data = pro_data2;
            WebClient Proxy1 = new WebClient();
            Proxy1 = new WebClient();
            Proxy1.Headers["Content-type"] = "application/json";
            MemoryStream ms = new MemoryStream();
            DataContractJsonSerializer serializerToUplaod = new DataContractJsonSerializer(typeof(string[]));
            serializerToUplaod.WriteObject(ms, pro_data);
            //byte[] data = Proxy1.UploadData("http://" + mis_service_ip + ":" + mis_service_port + "/" + mis_service_name + "/" + function_name, "POST", ms.ToArray());
            byte[] data = Proxy1.UploadData("http://" + mis_service_ip + "/" + mis_service_name + "/" + function_name, "POST", ms.ToArray());
        }

    }
}