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
    public class StockReleaseDetailsController : Controller
    {
        private NCRMMLS_DBEntities2 db = new NCRMMLS_DBEntities2();

        // GET: /StockReleaseDetails/
        public ActionResult Index()
        {
            var stockreleasedetails_tbl = db.StockReleaseDetails_tbl.Include(s => s.StockDetailsRecord_tbl).Include(s => s.StockMasterRecordCrops_tbl);
            return View(stockreleasedetails_tbl.ToList());
        }

        // GET: /StockReleaseDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockReleaseDetails_tbl stockreleasedetails_tbl = db.StockReleaseDetails_tbl.Find(id);
            if (stockreleasedetails_tbl == null)
            {
                return HttpNotFound();
            }
            return View(stockreleasedetails_tbl);
        }

        // GET: /StockReleaseDetails/Create
        public ActionResult Create()
        {
            ViewBag.StockReleaseId = new SelectList(db.StockDetailsRecord_tbl, "StockDetailsRecordId", "Description");
            ViewBag.StockMasterRecordCropsId = new SelectList(db.StockMasterRecordCrops_tbl, "StockMasterRecordId", "InvoiceNo");
            return View();
        }

        // POST: /StockReleaseDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="StockReleaseId,StockDetailsRecordId,AmountRelease,StockMasterRecordCropsId")] StockReleaseDetails_tbl stockreleasedetails_tbl)
        {
            if (ModelState.IsValid)
            {
                db.StockReleaseDetails_tbl.Add(stockreleasedetails_tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StockReleaseId = new SelectList(db.StockDetailsRecord_tbl, "StockDetailsRecordId", "Description", stockreleasedetails_tbl.StockReleaseId);
            ViewBag.StockMasterRecordCropsId = new SelectList(db.StockMasterRecordCrops_tbl, "StockMasterRecordId", "InvoiceNo", stockreleasedetails_tbl.StockMasterRecordCropsId);
            return View(stockreleasedetails_tbl);
        }

        // GET: /StockReleaseDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockReleaseDetails_tbl stockreleasedetails_tbl = db.StockReleaseDetails_tbl.Find(id);
            if (stockreleasedetails_tbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.StockReleaseId = new SelectList(db.StockDetailsRecord_tbl, "StockDetailsRecordId", "Description", stockreleasedetails_tbl.StockReleaseId);
            ViewBag.StockMasterRecordCropsId = new SelectList(db.StockMasterRecordCrops_tbl, "StockMasterRecordId", "InvoiceNo", stockreleasedetails_tbl.StockMasterRecordCropsId);
            return View(stockreleasedetails_tbl);
        }

        // POST: /StockReleaseDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="StockReleaseId,StockDetailsRecordId,AmountRelease,StockMasterRecordCropsId")] StockReleaseDetails_tbl stockreleasedetails_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stockreleasedetails_tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StockReleaseId = new SelectList(db.StockDetailsRecord_tbl, "StockDetailsRecordId", "Description", stockreleasedetails_tbl.StockReleaseId);
            ViewBag.StockMasterRecordCropsId = new SelectList(db.StockMasterRecordCrops_tbl, "StockMasterRecordId", "InvoiceNo", stockreleasedetails_tbl.StockMasterRecordCropsId);
            return View(stockreleasedetails_tbl);
        }

        // GET: /StockReleaseDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockReleaseDetails_tbl stockreleasedetails_tbl = db.StockReleaseDetails_tbl.Find(id);
            if (stockreleasedetails_tbl == null)
            {
                return HttpNotFound();
            }
            return View(stockreleasedetails_tbl);
        }

        // POST: /StockReleaseDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StockReleaseDetails_tbl stockreleasedetails_tbl = db.StockReleaseDetails_tbl.Find(id);
            db.StockReleaseDetails_tbl.Remove(stockreleasedetails_tbl);
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
