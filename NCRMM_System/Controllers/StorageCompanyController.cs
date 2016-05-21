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
    public class StorageCompanyController : Controller
    {
        private NCRMMLS_DBEntities2 db = new NCRMMLS_DBEntities2();

        // GET: /StorageCompany/
        public ActionResult Index()
        {
            return View(db.StorageCompany_tbl.ToList());
        }

        // GET: /StorageCompany/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StorageCompany_tbl storagecompany_tbl = db.StorageCompany_tbl.Find(id);
            if (storagecompany_tbl == null)
            {
                return HttpNotFound();
            }
            return View(storagecompany_tbl);
        }

        // GET: /StorageCompany/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /StorageCompany/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="StorageCompanyId,CompanyName,Website,StorageCapacity,StorageAvailable")] StorageCompany_tbl storagecompany_tbl)
        {
            if (ModelState.IsValid)
            {
                db.StorageCompany_tbl.Add(storagecompany_tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(storagecompany_tbl);
        }

        // GET: /StorageCompany/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StorageCompany_tbl storagecompany_tbl = db.StorageCompany_tbl.Find(id);
            if (storagecompany_tbl == null)
            {
                return HttpNotFound();
            }
            return View(storagecompany_tbl);
        }

        // POST: /StorageCompany/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="StorageCompanyId,CompanyName,Website,StorageCapacity,StorageAvailable")] StorageCompany_tbl storagecompany_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(storagecompany_tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(storagecompany_tbl);
        }

        // GET: /StorageCompany/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StorageCompany_tbl storagecompany_tbl = db.StorageCompany_tbl.Find(id);
            if (storagecompany_tbl == null)
            {
                return HttpNotFound();
            }
            return View(storagecompany_tbl);
        }

        // POST: /StorageCompany/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StorageCompany_tbl storagecompany_tbl = db.StorageCompany_tbl.Find(id);
            db.StorageCompany_tbl.Remove(storagecompany_tbl);
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
