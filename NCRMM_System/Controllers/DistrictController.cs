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
    public class DistrictController : Controller
    {
        private NCRMMLS_DBEntities2 db = new NCRMMLS_DBEntities2();

        // GET: District
        public ActionResult Index()
        {
            var district_tbl = db.District_tbl.Include(d => d.Division_tbl);
            return View(district_tbl.ToList());
        }

        public JsonResult GetDistrict(int divisionId=0)
        {
           // var district_tbl = db.District_tbl.Include(d => d.Division_tbl);
            var list =db.District_tbl.Where(dis => dis.DivisionId == divisionId).ToList();
            ViewBag.JList = list;
            return Json(new SelectList(db.District_tbl.Where(dis=>dis.DivisionId==divisionId),"DistrictId","DistrictName"));
        }

        // GET: District/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            District_tbl district_tbl = db.District_tbl.Find(id);
            if (district_tbl == null)
            {
                return HttpNotFound();
            }
            return View(district_tbl);
        }

        // GET: District/Create
        public ActionResult Create()
        {
            ViewBag.DivisionId = new SelectList(db.Division_tbl, "DivisionId", "DivisionName");
            return View();
        }

        // POST: District/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DistrictId,DistrictName,DivisionId")] District_tbl district_tbl)
        {
            if (ModelState.IsValid)
            {
                db.District_tbl.Add(district_tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DivisionId = new SelectList(db.Division_tbl, "DivisionId", "DivisionName", district_tbl.DivisionId);
            return View(district_tbl);
        }

        // GET: District/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            District_tbl district_tbl = db.District_tbl.Find(id);
            if (district_tbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.DivisionId = new SelectList(db.Division_tbl, "DivisionId", "DivisionName", district_tbl.DivisionId);
            return View(district_tbl);
        }

        // POST: District/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DistrictId,DistrictName,DivisionId")] District_tbl district_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(district_tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DivisionId = new SelectList(db.Division_tbl, "DivisionId", "DivisionName", district_tbl.DivisionId);
            return View(district_tbl);
        }

        // GET: District/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            District_tbl district_tbl = db.District_tbl.Find(id);
            if (district_tbl == null)
            {
                return HttpNotFound();
            }
            return View(district_tbl);
        }

        // POST: District/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            District_tbl district_tbl = db.District_tbl.Find(id);
            db.District_tbl.Remove(district_tbl);
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
