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
    
    public partial class electrical
    {
        public System.Guid randomID { get; set; }
        public System.DateTime date { get; set; }
        public string type { get; set; }
        public Nullable<float> current_meter { get; set; }
        public Nullable<float> peak { get; set; }
        public Nullable<float> off_peak { get; set; }
        public Nullable<float> holiday { get; set; }
        public Nullable<System.DateTime> timestamp { get; set; }
        public int permission_user_id { get; set; }
        public int permission_building_buidlingid { get; set; }
        public string permission_building_company_companycode { get; set; }
        public int permission_energy_energy_id { get; set; }
    
        public virtual permission permission { get; set; }
    }
}