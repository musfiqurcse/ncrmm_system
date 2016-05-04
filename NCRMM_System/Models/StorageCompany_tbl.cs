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
    
    public partial class StorageCompany_tbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StorageCompany_tbl()
        {
            this.EmployeeRoleTables = new HashSet<EmployeeRoleTable>();
            this.StockMasterRecordCrops_tbl = new HashSet<StockMasterRecordCrops_tbl>();
        }
    
        public int StorageCompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Website { get; set; }
        public decimal StorageCapacity { get; set; }
        public decimal StorageAvailable { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeRoleTable> EmployeeRoleTables { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StockMasterRecordCrops_tbl> StockMasterRecordCrops_tbl { get; set; }
    }
}