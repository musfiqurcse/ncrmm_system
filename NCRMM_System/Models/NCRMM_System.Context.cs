﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class NCRMMLS_DBEntities2 : DbContext
    {
        public NCRMMLS_DBEntities2()
            : base("name=NCRMMLS_DBEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Address_tbl> Address_tbl { get; set; }
        public virtual DbSet<Crops_tbl> Crops_tbl { get; set; }
        public virtual DbSet<CropsCatagory_tbl> CropsCatagory_tbl { get; set; }
        public virtual DbSet<District_tbl> District_tbl { get; set; }
        public virtual DbSet<Division_tbl> Division_tbl { get; set; }
        public virtual DbSet<OrderDetailsTemp_tbl> OrderDetailsTemp_tbl { get; set; }
        public virtual DbSet<OrderDetalis_tbl> OrderDetalis_tbl { get; set; }
        public virtual DbSet<OrderMaster_tbl> OrderMaster_tbl { get; set; }
        public virtual DbSet<ProductsList_tbl> ProductsList_tbl { get; set; }
        public virtual DbSet<SecurityCheck_tbl> SecurityCheck_tbl { get; set; }
        public virtual DbSet<StockDetailsRecord_tbl> StockDetailsRecord_tbl { get; set; }
        public virtual DbSet<StockMasterRecordCrops_tbl> StockMasterRecordCrops_tbl { get; set; }
        public virtual DbSet<StockReleaseDetails_tbl> StockReleaseDetails_tbl { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<UserType_tbl> UserType_tbl { get; set; }
        public virtual DbSet<StorageCompany_tbl> StorageCompany_tbl { get; set; }
        public virtual DbSet<User_tbl> User_tbl { get; set; }
        public virtual DbSet<EmployeeRoleTable> EmployeeRoleTables { get; set; }
    }
}
