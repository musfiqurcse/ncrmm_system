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
    
    public partial class OrderDetalis_tbl
    {
        public int OrderDetailsId { get; set; }
        public int ProductsId { get; set; }
        public int OwnersId { get; set; }
        public decimal Unit { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsApproved { get; set; }
        public int OrderMasterId { get; set; }
        public int CropsId { get; set; }
        public bool IsStatus { get; set; }
    
        public virtual OrderMaster_tbl OrderMaster_tbl { get; set; }
        public virtual ProductsList_tbl ProductsList_tbl { get; set; }
        public virtual Crops_tbl Crops_tbl { get; set; }
    }
}
