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
    
    public partial class StockDetailsRecord_tbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StockDetailsRecord_tbl()
        {
            this.ProductsList_tbl = new HashSet<ProductsList_tbl>();
        }
    
        public int StockDetailsRecordId { get; set; }
        public int CropsId { get; set; }
        public Nullable<decimal> AmountMainStocked { get; set; }
        public string Description { get; set; }
        public int StockMasterRecordId { get; set; }
        public Nullable<decimal> AvailableAmount { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public Nullable<bool> IsReferred { get; set; }
        public Nullable<decimal> AmountSecondStocked { get; set; }
        public int CropsOwnerId { get; set; }
    
        public virtual Crops_tbl Crops_tbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductsList_tbl> ProductsList_tbl { get; set; }
        public virtual StockMasterRecordCrops_tbl StockMasterRecordCrops_tbl { get; set; }
        public virtual StockReleaseDetails_tbl StockReleaseDetails_tbl { get; set; }
    }
}