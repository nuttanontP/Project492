using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace TestAmmy
{
    public partial class dataTest : System.Web.UI.Page
    {
        List<Person> Persons;
        protected void Page_Load(object sender, EventArgs e)
        {
            Persons = new List<Person>
                        {
                          new Person{UserID= 1, UserName = "UserName1",FirstName ="FirstName1",LastName = "LastName1" },
                          new Person{UserID= 2, UserName = "UserName2",FirstName ="FirstName2",LastName = "LastName2" },
                          new Person{UserID= 3, UserName = "UserName3",FirstName ="FirstName3",LastName = "LastName3" },
                          new Person{UserID= 4, UserName = "UserName4",FirstName ="FirstName4",LastName = "LastName4" },
                          new Person{UserID= 5, UserName = "UserName5",FirstName ="FirstName5",LastName = "LastName5" },
                        };
            

        }

        public class Person
        {
            public int UserID { get; set; }
            public String UserName { get; set; }
            public String FirstName { get; set; }
            public String LastName { get; set; }


        }

       

    }
   
}