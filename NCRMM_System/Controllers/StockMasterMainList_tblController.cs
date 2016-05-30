using System;
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
    public class StockMasterMainList_tblController : Controller
    {
        private NCRMMLS_DBEntities2 db = new NCRMMLS_DBEntities2();

        // GET: StockMasterMainList_tbl
        public ActionResult Index()
        {
            var stockMasterMainList_tbl = db.StockMasterMainList_tbl.Include(s => s.StorageCompany_tbl).Include(s => s.StockMasterRecordCrops_tbl);
            return View(stockMasterMainList_tbl.ToList());
        }

     

        // GET: StockMasterMainList_tbl/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockMasterMainList_tbl stockMasterMainList_tbl = db.StockMasterMainList_tbl.Find(id);
            if (stockMasterMainList_tbl == null)
            {
                return HttpNotFound();
            }
            return View(stockMasterMainList_tbl);
        }

        // GET: StockMasterMainList_tbl/Create
        public ActionResult Create()
        {
            ViewBag.CompanyId = new SelectList(db.StorageCompany_tbl, "StorageCompanyId", "CompanyName");
            ViewBag.StockMasterId = new SelectList(db.StockMasterRecordCrops_tbl, "StockMasterRecordId", "InvoiceNo");
            return View();
        }

        // POST: StockMasterMainList_tbl/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MasterInfoId,StockMasterId,CompanyId,StorageAmount,ReleaseAmount,AvailableStorageAmount,IsApprove")] StockMasterMainList_tbl stockMasterMainList_tbl)
        {
            if (ModelState.IsValid)
            {
                db.StockMasterMainList_tbl.Add(stockMasterMainList_tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyId = new SelectList(db.StorageCompany_tbl, "StorageCompanyId", "CompanyName", stockMasterMainList_tbl.CompanyId);
            ViewBag.StockMasterId = new SelectList(db.StockMasterRecordCrops_tbl, "StockMasterRecordId", "InvoiceNo", stockMasterMainList_tbl.StockMasterId);
            return View(stockMasterMainList_tbl);
        }

        // GET: StockMasterMainList_tbl/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockMasterMainList_tbl stockMasterMainList_tbl = db.StockMasterMainList_tbl.Find(id);
            if (stockMasterMainList_tbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyId = new SelectList(db.StorageCompany_tbl, "StorageCompanyId", "CompanyName", stockMasterMainList_tbl.CompanyId);
            ViewBag.StockMasterId = new SelectList(db.StockMasterRecordCrops_tbl, "StockMasterRecordId", "InvoiceNo", stockMasterMainList_tbl.StockMasterId);
            return View(stockMasterMainList_tbl);
        }

        // POST: StockMasterMainList_tbl/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MasterInfoId,StockMasterId,CompanyId,StorageAmount,ReleaseAmount,AvailableStorageAmount,IsApprove")] StockMasterMainList_tbl stockMasterMainList_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stockMasterMainList_tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyId = new SelectList(db.StorageCompany_tbl, "StorageCompanyId", "CompanyName", stockMasterMainList_tbl.CompanyId);
            ViewBag.StockMasterId = new SelectList(db.StockMasterRecordCrops_tbl, "StockMasterRecordId", "InvoiceNo", stockMasterMainList_tbl.StockMasterId);
            return View(stockMasterMainList_tbl);
        }

        // GET: StockMasterMainList_tbl/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockMasterMainList_tbl stockMasterMainList_tbl = db.StockMasterMainList_tbl.Find(id);
            if (stockMasterMainList_tbl == null)
            {
                return HttpNotFound();
            }
            return View(stockMasterMainList_tbl);
        }

        // POST: StockMasterMainList_tbl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StockMasterMainList_tbl stockMasterMainList_tbl = db.StockMasterMainList_tbl.Find(id);
            db.StockMasterMainList_tbl.Remove(stockMasterMainList_tbl);
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
