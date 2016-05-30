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
    public class StockDetailsRecordController : Controller
    {
        private NCRMMLS_DBEntities2 db = new NCRMMLS_DBEntities2();

        // GET: /StockDetailsRecord/
        public ActionResult Index()
        {
            var stockdetailsrecord_tbl = db.StockDetailsRecord_tbl.Include(s => s.Crops_tbl).Include(s => s.StockMasterRecordCrops_tbl).Include(s => s.StockReleaseDetails_tbl);
            return View(stockdetailsrecord_tbl.ToList());
        }

        // GET: /StockDetailsRecord/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockDetailsRecord_tbl stockdetailsrecord_tbl = db.StockDetailsRecord_tbl.Find(id);
            if (stockdetailsrecord_tbl == null)
            {
                return HttpNotFound();
            }
            return View(stockdetailsrecord_tbl);
        }

        // GET: /StockDetailsRecord/Create
        public ActionResult Create()
        {
            ViewBag.CropsId = new SelectList(db.Crops_tbl, "CropsId", "CropsName");
            ViewBag.StockMasterRecordId = new SelectList(db.StockMasterRecordCrops_tbl, "StockMasterRecordId", "InvoiceNo");
            ViewBag.StockDetailsRecordId = new SelectList(db.StockReleaseDetails_tbl, "StockReleaseId", "StockReleaseId");
            return View();
        }

        // POST: /StockDetailsRecord/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="StockDetailsRecordId,CropsId,AmountMainStocked,Description,StockMasterRecordId,AvailableAmount,UpdateDate,IsReferred,AmountSecondStocked,CropsOwnerId")] StockDetailsRecord_tbl stockdetailsrecord_tbl)
        {
            if (ModelState.IsValid)
            {
                db.StockDetailsRecord_tbl.Add(stockdetailsrecord_tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.CropsId = new SelectList(db.Crops_tbl, "CropsId", "CropsName", stockdetailsrecord_tbl);
            ViewBag.StockMasterRecordId = new SelectList(db.StockMasterRecordCrops_tbl, "StockMasterRecordId", "InvoiceNo", stockdetailsrecord_tbl.StockMasterRecordId);
            ViewBag.StockDetailsRecordId = new SelectList(db.StockReleaseDetails_tbl, "StockReleaseId", "StockReleaseId", stockdetailsrecord_tbl.StockDetailsRecordId);
            return View(stockdetailsrecord_tbl);
        }

        // GET: /StockDetailsRecord/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockDetailsRecord_tbl stockdetailsrecord_tbl = db.StockDetailsRecord_tbl.Find(id);
            if (stockdetailsrecord_tbl == null)
            {
                return HttpNotFound();
            }
           // ViewBag.CropsId = new SelectList(db.Crops_tbl, "CropsId", "CropsName", stockdetailsrecord_tbl.CropsId);
            ViewBag.StockMasterRecordId = new SelectList(db.StockMasterRecordCrops_tbl, "StockMasterRecordId", "InvoiceNo", stockdetailsrecord_tbl.StockMasterRecordId);
            ViewBag.StockDetailsRecordId = new SelectList(db.StockReleaseDetails_tbl, "StockReleaseId", "StockReleaseId", stockdetailsrecord_tbl.StockDetailsRecordId);
            return View(stockdetailsrecord_tbl);
        }

        // POST: /StockDetailsRecord/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="StockDetailsRecordId,CropsId,AmountMainStocked,Description,StockMasterRecordId,AvailableAmount,UpdateDate,IsReferred,AmountSecondStocked,CropsOwnerId")] StockDetailsRecord_tbl stockdetailsrecord_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stockdetailsrecord_tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           // ViewBag.CropsId = new SelectList(db.Crops_tbl, "CropsId", "CropsName", stockdetailsrecord_tbl.CropsId);
            ViewBag.StockMasterRecordId = new SelectList(db.StockMasterRecordCrops_tbl, "StockMasterRecordId", "InvoiceNo", stockdetailsrecord_tbl.StockMasterRecordId);
            ViewBag.StockDetailsRecordId = new SelectList(db.StockReleaseDetails_tbl, "StockReleaseId", "StockReleaseId", stockdetailsrecord_tbl.StockDetailsRecordId);
            return View(stockdetailsrecord_tbl);
        }

        // GET: /StockDetailsRecord/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockDetailsRecord_tbl stockdetailsrecord_tbl = db.StockDetailsRecord_tbl.Find(id);
            if (stockdetailsrecord_tbl == null)
            {
                return HttpNotFound();
            }
            return View(stockdetailsrecord_tbl);
        }

        // POST: /StockDetailsRecord/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StockDetailsRecord_tbl stockdetailsrecord_tbl = db.StockDetailsRecord_tbl.Find(id);
            db.StockDetailsRecord_tbl.Remove(stockdetailsrecord_tbl);
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
