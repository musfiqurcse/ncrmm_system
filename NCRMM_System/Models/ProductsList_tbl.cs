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
    
    public partial class ProductsList_tbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductsList_tbl()
        {
            this.OrderDetalis_tbl = new HashSet<OrderDetalis_tbl>();
        }
    
        public int ProductId { get; set; }
        public int OwnersId { get; set; }
        public int CropsDetailsId { get; set; }
        public bool IsAvailable { get; set; }
        public System.DateTime LastUpdateDate { get; set; }
        public decimal UnitPrice { get; set; }
        public string Description { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetalis_tbl> OrderDetalis_tbl { get; set; }
        public virtual StockDetailsRecord_tbl StockDetailsRecord_tbl { get; set; }
    }
}
