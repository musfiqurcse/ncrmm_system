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
    public class ProductsListController : Controller
    {
        private NCRMMLS_DBEntities2 db = new NCRMMLS_DBEntities2();

        // GET: /ProductsList/
        public ActionResult Index()
        {
            var productslist_tbl = db.ProductsList_tbl.Include(p => p.StockDetailsRecord_tbl);
            return View(productslist_tbl.ToList());
        }

        // GET: /ProductsList/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductsList_tbl productslist_tbl = db.ProductsList_tbl.Find(id);
            if (productslist_tbl == null)
            {
                return HttpNotFound();
            }
            return View(productslist_tbl);
        }

        // GET: /ProductsList/Create
        public ActionResult Create()
        {
            ViewBag.CropsDetailsId = new SelectList(db.StockDetailsRecord_tbl, "StockDetailsRecordId", "Description");
            return View();
        }

        // POST: /ProductsList/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ProductId,OwnersId,CropsDetailsId,IsAvailable,LastUpdateDate,UnitPrice,Description")] ProductsList_tbl productslist_tbl)
        {
            if (ModelState.IsValid)
            {
                db.ProductsList_tbl.Add(productslist_tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CropsDetailsId = new SelectList(db.StockDetailsRecord_tbl, "StockDetailsRecordId", "Description", productslist_tbl.CropsDetailsId);
            return View(productslist_tbl);
        }

        // GET: /ProductsList/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductsList_tbl productslist_tbl = db.ProductsList_tbl.Find(id);
            if (productslist_tbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.CropsDetailsId = new SelectList(db.StockDetailsRecord_tbl, "StockDetailsRecordId", "Description", productslist_tbl.CropsDetailsId);
            return View(productslist_tbl);
        }

        // POST: /ProductsList/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ProductId,OwnersId,CropsDetailsId,IsAvailable,LastUpdateDate,UnitPrice,Description")] ProductsList_tbl productslist_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productslist_tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CropsDetailsId = new SelectList(db.StockDetailsRecord_tbl, "StockDetailsRecordId", "Description", productslist_tbl.CropsDetailsId);
            return View(productslist_tbl);
        }

        // GET: /ProductsList/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductsList_tbl productslist_tbl = db.ProductsList_tbl.Find(id);
            if (productslist_tbl == null)
            {
                return HttpNotFound();
            }
            return View(productslist_tbl);
        }

        // POST: /ProductsList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductsList_tbl productslist_tbl = db.ProductsList_tbl.Find(id);
            db.ProductsList_tbl.Remove(productslist_tbl);
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
