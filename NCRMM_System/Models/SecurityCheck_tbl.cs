//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NCRMM_System.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SecurityCheck_tbl
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string SecurityQuestion { get; set; }
        public string Answer { get; set; }
        public System.DateTime UpdateDate { get; set; }
    
        public virtual User_tbl User_tbl { get; set; }
    }
}