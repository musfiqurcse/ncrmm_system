﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NCRMM_System.Models;

namespace NCRMM_System.Controllers
{
    public class StockMasterRecordCropsController : Controller
    {
        private NCRMMLS_DBEntities2 db = new NCRMMLS_DBEntities2();

        // GET: /StockMasterRecordCrops/
        public ActionResult Index()
        {
            var stockmasterrecordcrops_tbl = db.StockMasterRecordCrops_tbl.Include(s => s.StorageCompany_tbl).Include(s => s.EmployeeRoleTable);
            return View(stockmasterrecordcrops_tbl.ToList());
        }

        // GET: /StockMasterRecordCrops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockMasterRecordCrops_tbl stockmasterrecordcrops_tbl = db.StockMasterRecordCrops_tbl.Find(id);
            if (stockmasterrecordcrops_tbl == null)
            {
                return HttpNotFound();
            }
            return View(stockmasterrecordcrops_tbl);
        }

        // GET: /StockMasterRecordCrops/Create
        public ActionResult Create()
        {
            ViewBag.StorageCompanyId = new SelectList(db.StorageCompany_tbl, "StorageCompanyId", "CompanyName");
            ViewBag.StockMasterRecordId = new SelectList(db.EmployeeRoleTables, "EmployeeId", "EmployeeRole");
            return View();
        }

        // POST: /StockMasterRecordCrops/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="StockMasterRecordId,InvoiceNo,AmountOfCropsStored,StorageCompanyId,SourceUserId,EntryEmployeeId,RecordDate,StockRecordType")] StockMasterRecordCrops_tbl stockmasterrecordcrops_tbl)
        {
            if (ModelState.IsValid)
            {
                db.StockMasterRecordCrops_tbl.Add(stockmasterrecordcrops_tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StorageCompanyId = new SelectList(db.StorageCompany_tbl, "StorageCompanyId", "CompanyName", stockmasterrecordcrops_tbl.StorageCompanyId);
            ViewBag.StockMasterRecordId = new SelectList(db.EmployeeRoleTables, "EmployeeId", "EmployeeRole", stockmasterrecordcrops_tbl.StockMasterRecordId);
            return View(stockmasterrecordcrops_tbl);
        }

        // GET: /StockMasterRecordCrops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockMasterRecordCrops_tbl stockmasterrecordcrops_tbl = db.StockMasterRecordCrops_tbl.Find(id);
            if (stockmasterrecordcrops_tbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.StorageCompanyId = new SelectList(db.StorageCompany_tbl, "StorageCompanyId", "CompanyName", stockmasterrecordcrops_tbl.StorageCompanyId);
            ViewBag.StockMasterRecordId = new SelectList(db.EmployeeRoleTables, "EmployeeId", "EmployeeRole", stockmasterrecordcrops_tbl.StockMasterRecordId);
            return View(stockmasterrecordcrops_tbl);
        }

        // POST: /StockMasterRecordCrops/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="StockMasterRecordId,InvoiceNo,AmountOfCropsStored,StorageCompanyId,SourceUserId,EntryEmployeeId,RecordDate,StockRecordType")] StockMasterRecordCrops_tbl stockmasterrecordcrops_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stockmasterrecordcrops_tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StorageCompanyId = new SelectList(db.StorageCompany_tbl, "StorageCompanyId", "CompanyName", stockmasterrecordcrops_tbl.StorageCompanyId);
            ViewBag.StockMasterRecordId = new SelectList(db.EmployeeRoleTables, "EmployeeId", "EmployeeRole", stockmasterrecordcrops_tbl.StockMasterRecordId);
            return View(stockmasterrecordcrops_tbl);
        }

        // GET: /StockMasterRecordCrops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockMasterRecordCrops_tbl stockmasterrecordcrops_tbl = db.StockMasterRecordCrops_tbl.Find(id);
            if (stockmasterrecordcrops_tbl == null)
            {
                return HttpNotFound();
            }
            return View(stockmasterrecordcrops_tbl);
        }

        // POST: /StockMasterRecordCrops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StockMasterRecordCrops_tbl stockmasterrecordcrops_tbl = db.StockMasterRecordCrops_tbl.Find(id);
            db.StockMasterRecordCrops_tbl.Remove(stockmasterrecordcrops_tbl);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
