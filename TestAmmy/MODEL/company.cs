//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MODEL
{
    using System;
    using System.Collections.Generic;
    
    public partial class company
    {
        public company()
        {
            this.buildings = new HashSet<building>();
            this.users = new HashSet<user>();
        }
    
        public string companycode { get; set; }
        public string company_name { get; set; }
    
        public virtual ICollection<building> buildings { get; set; }
        public virtual ICollection<user> users { get; set; }
    }
}
