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
    public class OrderDetailsTempController : Controller
    {
        private NCRMMLS_DBEntities2 db = new NCRMMLS_DBEntities2();

        // GET: /OrderDetailsTemp/
        public ActionResult Index()
        {
            return View(db.OrderDetailsTemp_tbl.ToList());
        }

        // GET: /OrderDetailsTemp/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetailsTemp_tbl orderdetailstemp_tbl = db.OrderDetailsTemp_tbl.Find(id);
            if (orderdetailstemp_tbl == null)
            {
                return HttpNotFound();
            }
            return View(orderdetailstemp_tbl);
        }

        // GET: /OrderDetailsTemp/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /OrderDetailsTemp/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="OrderDetailsTempId,ProductId,CropsId,BuyersId,OwnersId,Unit,TotalPrice")] OrderDetailsTemp_tbl orderdetailstemp_tbl)
        {
            if (ModelState.IsValid)
            {
                db.OrderDetailsTemp_tbl.Add(orderdetailstemp_tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(orderdetailstemp_tbl);
        }

        // GET: /OrderDetailsTemp/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetailsTemp_tbl orderdetailstemp_tbl = db.OrderDetailsTemp_tbl.Find(id);
            if (orderdetailstemp_tbl == null)
            {
                return HttpNotFound();
            }
            return View(orderdetailstemp_tbl);
        }

        // POST: /OrderDetailsTemp/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="OrderDetailsTempId,ProductId,CropsId,BuyersId,OwnersId,Unit,TotalPrice")] OrderDetailsTemp_tbl orderdetailstemp_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderdetailstemp_tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orderdetailstemp_tbl);
        }

        // GET: /OrderDetailsTemp/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetailsTemp_tbl orderdetailstemp_tbl = db.OrderDetailsTemp_tbl.Find(id);
            if (orderdetailstemp_tbl == null)
            {
                return HttpNotFound();
            }
            return View(orderdetailstemp_tbl);
        }

        // POST: /OrderDetailsTemp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderDetailsTemp_tbl orderdetailstemp_tbl = db.OrderDetailsTemp_tbl.Find(id);
            db.OrderDetailsTemp_tbl.Remove(orderdetailstemp_tbl);
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
