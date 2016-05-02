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
    public class Address_tblController : Controller
    {
        private NCRMMLS_DBEntities2 db = new NCRMMLS_DBEntities2();

        // GET: Address_tbl
        public ActionResult Index()
        {
            var address_tbl = db.Address_tbl.Include(a => a.District_tbl);
            return View(address_tbl.ToList());
        }

        // GET: Address_tbl/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address_tbl address_tbl = db.Address_tbl.Find(id);
            if (address_tbl == null)
            {
                return HttpNotFound();
            }
            return View(address_tbl);
        }

        // GET: Address_tbl/Create
        public ActionResult Create()
        {
            ViewBag.DistrictId = new SelectList(db.District_tbl, "DistrictId", "DistrictName");
            return View();
        }

        // POST: Address_tbl/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AddressId,AddressLine1,AddressLine2,DistrictId,ZipCode,PostOffice,ContactNo,MobileNo,Email,SourceId,SourceType")] Address_tbl address_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Address_tbl.Add(address_tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DistrictId = new SelectList(db.District_tbl, "DistrictId", "DistrictName", address_tbl.DistrictId);
            return View(address_tbl);
        }

        // GET: Address_tbl/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address_tbl address_tbl = db.Address_tbl.Find(id);
            if (address_tbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.DistrictId = new SelectList(db.District_tbl, "DistrictId", "DistrictName", address_tbl.DistrictId);
            return View(address_tbl);
        }

        // POST: Address_tbl/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AddressId,AddressLine1,AddressLine2,DistrictId,ZipCode,PostOffice,ContactNo,MobileNo,Email,SourceId,SourceType")] Address_tbl address_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(address_tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DistrictId = new SelectList(db.District_tbl, "DistrictId", "DistrictName", address_tbl.DistrictId);
            return View(address_tbl);
        }

        // GET: Address_tbl/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address_tbl address_tbl = db.Address_tbl.Find(id);
            if (address_tbl == null)
            {
                return HttpNotFound();
            }
            return View(address_tbl);
        }

        // POST: Address_tbl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Address_tbl address_tbl = db.Address_tbl.Find(id);
            db.Address_tbl.Remove(address_tbl);
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
