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
    
    public partial class UserType_tbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserType_tbl()
        {
            this.User_tbl = new HashSet<User_tbl>();
        }
    
        public int UserTypeId { get; set; }
        public string UserType { get; set; }
        public string Details { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User_tbl> User_tbl { get; set; }
    }
}