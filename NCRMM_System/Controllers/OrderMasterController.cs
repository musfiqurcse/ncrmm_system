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
    public class OrderMasterController : Controller
    {
        private NCRMMLS_DBEntities2 db = new NCRMMLS_DBEntities2();

        // GET: /OrderMaster/
        public ActionResult Index()
        {
            return View(db.OrderMaster_tbl.ToList());
        }

        // GET: /OrderMaster/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderMaster_tbl ordermaster_tbl = db.OrderMaster_tbl.Find(id);
            if (ordermaster_tbl == null)
            {
                return HttpNotFound();
            }
            return View(ordermaster_tbl);
        }

        // GET: /OrderMaster/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /OrderMaster/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="OrderId,OrderNo,CropsBuyerId,TotalPrice,RecordDate")] OrderMaster_tbl ordermaster_tbl)
        {
            if (ModelState.IsValid)
            {
                db.OrderMaster_tbl.Add(ordermaster_tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ordermaster_tbl);
        }

        // GET: /OrderMaster/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderMaster_tbl ordermaster_tbl = db.OrderMaster_tbl.Find(id);
            if (ordermaster_tbl == null)
            {
                return HttpNotFound();
            }
            return View(ordermaster_tbl);
        }

        // POST: /OrderMaster/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="OrderId,OrderNo,CropsBuyerId,TotalPrice,RecordDate")] OrderMaster_tbl ordermaster_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordermaster_tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ordermaster_tbl);
        }

        // GET: /OrderMaster/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderMaster_tbl ordermaster_tbl = db.OrderMaster_tbl.Find(id);
            if (ordermaster_tbl == null)
            {
                return HttpNotFound();
            }
            return View(ordermaster_tbl);
        }

        // POST: /OrderMaster/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderMaster_tbl ordermaster_tbl = db.OrderMaster_tbl.Find(id);
            db.OrderMaster_tbl.Remove(ordermaster_tbl);
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
