//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MechatronicsPortal.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class EmployeeInformation
    {
        public int Id { get; set; }
        public int alumni_id { get; set; }
        public string company_name { get; set; }
        public string address { get; set; }
        public string name { get; set; }
        public string designation { get; set; }
        public string industry { get; set; }
    
        public virtual AlumniUsersAuthenticate AlumniUsersAuthenticate { get; set; }
    }
}
