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
    
    public partial class StockReleaseDetails_tbl
    {
        public int StockReleaseId { get; set; }
        public decimal AmountRelease { get; set; }
        public int StockMasterRecordCropsId { get; set; }
        public int CropsCatagoryId { get; set; }
        public string Description { get; set; }
    
        public virtual StockDetailsRecord_tbl StockDetailsRecord_tbl { get; set; }
        public virtual StockMasterRecordCrops_tbl StockMasterRecordCrops_tbl { get; set; }
    }
}
