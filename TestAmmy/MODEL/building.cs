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
    
    public partial class building
    {
        public building()
        {
            this.permissions = new HashSet<permission>();
        }
    
        public int buidlingid { get; set; }
        public string building_name { get; set; }
        public string building_detail { get; set; }
        public string company_companycode { get; set; }
    
        public virtual company company { get; set; }
        public virtual ICollection<permission> permissions { get; set; }
    }
}