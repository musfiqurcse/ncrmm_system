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
    public class CropsController : Controller
    {
        private NCRMMLS_DBEntities2 db = new NCRMMLS_DBEntities2();

        // GET: /Crops/
        public ActionResult Index()
        {
            var crops_tbl = db.Crops_tbl.Include(c => c.CropsCatagory_tbl);
            return View(crops_tbl.ToList());
        }

        // GET: /Crops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crops_tbl crops_tbl = db.Crops_tbl.Find(id);
            if (crops_tbl == null)
            {
                return HttpNotFound();
            }
            return View(crops_tbl);
        }

        // GET: /Crops/Create
        public ActionResult Create()
        {
          //  ViewBag.CropsCatagoryId = new SelectList(db.CropsCatagory_tbl, "CropsCatagoryId", "CropsCatagoryName");
            return View();
        }

        // POST: /Crops/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="CropsName,Description")] Crops_tbl crops_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Crops_tbl.Add(crops_tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

           // ViewBag.CropsCatagoryId = new SelectList(db.CropsCatagory_tbl, "CropsCatagoryId", "CropsCatagoryName", crops_tbl.CropsCatagoryId);
            return View(crops_tbl);
        }

        // GET: /Crops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crops_tbl crops_tbl = db.Crops_tbl.Find(id);
            if (crops_tbl == null)
            {
                return HttpNotFound();
            }
           // ViewBag.CropsCatagoryId = new SelectList(db.CropsCatagory_tbl, "CropsCatagoryId", "CropsCatagoryName", crops_tbl.CropsCatagoryId);
            return View(crops_tbl);
        }

        // POST: /Crops/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="CropsName,Description")] Crops_tbl crops_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(crops_tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
          //  ViewBag.CropsCatagoryId = new SelectList(db.CropsCatagory_tbl, "CropsCatagoryId", "CropsCatagoryName", crops_tbl.CropsCatagoryId);
            return View(crops_tbl);
        }

        // GET: /Crops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crops_tbl crops_tbl = db.Crops_tbl.Find(id);
            if (crops_tbl == null)
            {
                return HttpNotFound();
            }
            return View(crops_tbl);
        }

        // POST: /Crops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Crops_tbl crops_tbl = db.Crops_tbl.Find(id);
            db.Crops_tbl.Remove(crops_tbl);
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
