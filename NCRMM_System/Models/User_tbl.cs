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
    
    public partial class User_tbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User_tbl()
        {
            this.EmployeeRoleTables = new HashSet<EmployeeRoleTable>();
            this.SecurityCheck_tbl = new HashSet<SecurityCheck_tbl>();
        }
    
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Pass { get; set; }
        public string FullName { get; set; }
        public string DateOfBirth { get; set; }
        public int UserTypeId { get; set; }
        public bool IsActive { get; set; }
        public string NIDNumber { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeRoleTable> EmployeeRoleTables { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SecurityCheck_tbl> SecurityCheck_tbl { get; set; }
        public virtual UserType_tbl UserType_tbl { get; set; }
    }
}