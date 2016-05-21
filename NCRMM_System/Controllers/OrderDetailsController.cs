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
    public class OrderDetailsController : Controller
    {
        private NCRMMLS_DBEntities2 db = new NCRMMLS_DBEntities2();

        // GET: /OrderDetails/
        public ActionResult Index()
        {
            var orderdetalis_tbl = db.OrderDetalis_tbl.Include(o => o.Crops_tbl).Include(o => o.OrderMaster_tbl).Include(o => o.ProductsList_tbl);
            return View(orderdetalis_tbl.ToList());
        }

        // GET: /OrderDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetalis_tbl orderdetalis_tbl = db.OrderDetalis_tbl.Find(id);
            if (orderdetalis_tbl == null)
            {
                return HttpNotFound();
            }
            return View(orderdetalis_tbl);
        }

        // GET: /OrderDetails/Create
        public ActionResult Create()
        {
            ViewBag.CropsId = new SelectList(db.Crops_tbl, "CropsId", "CropsName");
            ViewBag.OrderMasterId = new SelectList(db.OrderMaster_tbl, "OrderId", "OrderNo");
            ViewBag.ProductsId = new SelectList(db.ProductsList_tbl, "ProductId", "Description");
            return View();
        }

        // POST: /OrderDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="OrderDetailsId,ProductsId,OwnersId,Unit,TotalPrice,IsApproved,OrderMasterId,CropsId,IsStatus")] OrderDetalis_tbl orderdetalis_tbl)
        {
            if (ModelState.IsValid)
            {
                db.OrderDetalis_tbl.Add(orderdetalis_tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CropsId = new SelectList(db.Crops_tbl, "CropsId", "CropsName", orderdetalis_tbl.CropsId);
            ViewBag.OrderMasterId = new SelectList(db.OrderMaster_tbl, "OrderId", "OrderNo", orderdetalis_tbl.OrderMasterId);
            ViewBag.ProductsId = new SelectList(db.ProductsList_tbl, "ProductId", "Description", orderdetalis_tbl.ProductsId);
            return View(orderdetalis_tbl);
        }

        // GET: /OrderDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetalis_tbl orderdetalis_tbl = db.OrderDetalis_tbl.Find(id);
            if (orderdetalis_tbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.CropsId = new SelectList(db.Crops_tbl, "CropsId", "CropsName", orderdetalis_tbl.CropsId);
            ViewBag.OrderMasterId = new SelectList(db.OrderMaster_tbl, "OrderId", "OrderNo", orderdetalis_tbl.OrderMasterId);
            ViewBag.ProductsId = new SelectList(db.ProductsList_tbl, "ProductId", "Description", orderdetalis_tbl.ProductsId);
            return View(orderdetalis_tbl);
        }

        // POST: /OrderDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="OrderDetailsId,ProductsId,OwnersId,Unit,TotalPrice,IsApproved,OrderMasterId,CropsId,IsStatus")] OrderDetalis_tbl orderdetalis_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderdetalis_tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CropsId = new SelectList(db.Crops_tbl, "CropsId", "CropsName", orderdetalis_tbl.CropsId);
            ViewBag.OrderMasterId = new SelectList(db.OrderMaster_tbl, "OrderId", "OrderNo", orderdetalis_tbl.OrderMasterId);
            ViewBag.ProductsId = new SelectList(db.ProductsList_tbl, "ProductId", "Description", orderdetalis_tbl.ProductsId);
            return View(orderdetalis_tbl);
        }

        // GET: /OrderDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetalis_tbl orderdetalis_tbl = db.OrderDetalis_tbl.Find(id);
            if (orderdetalis_tbl == null)
            {
                return HttpNotFound();
            }
            return View(orderdetalis_tbl);
        }

        // POST: /OrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderDetalis_tbl orderdetalis_tbl = db.OrderDetalis_tbl.Find(id);
            db.OrderDetalis_tbl.Remove(orderdetalis_tbl);
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
