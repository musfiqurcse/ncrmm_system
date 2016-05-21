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
    public class SecurityCheckController : Controller
    {
        private NCRMMLS_DBEntities2 db = new NCRMMLS_DBEntities2();

        // GET: /SecurityCheck/
        public ActionResult Index()
        {
            var securitycheck_tbl = db.SecurityCheck_tbl.Include(s => s.User_tbl);
            return View(securitycheck_tbl.ToList());
        }

        // GET: /SecurityCheck/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecurityCheck_tbl securitycheck_tbl = db.SecurityCheck_tbl.Find(id);
            if (securitycheck_tbl == null)
            {
                return HttpNotFound();
            }
            return View(securitycheck_tbl);
        }

        // GET: /SecurityCheck/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.User_tbl, "UserId", "UserName");
            return View();
        }

        // POST: /SecurityCheck/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,UserId,SecurityQuestion,Answer,UpdateDate")] SecurityCheck_tbl securitycheck_tbl)
        {
            if (ModelState.IsValid)
            {
                db.SecurityCheck_tbl.Add(securitycheck_tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.User_tbl, "UserId", "UserName", securitycheck_tbl.UserId);
            return View(securitycheck_tbl);
        }

        // GET: /SecurityCheck/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecurityCheck_tbl securitycheck_tbl = db.SecurityCheck_tbl.Find(id);
            if (securitycheck_tbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.User_tbl, "UserId", "UserName", securitycheck_tbl.UserId);
            return View(securitycheck_tbl);
        }

        // POST: /SecurityCheck/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,UserId,SecurityQuestion,Answer,UpdateDate")] SecurityCheck_tbl securitycheck_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(securitycheck_tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.User_tbl, "UserId", "UserName", securitycheck_tbl.UserId);
            return View(securitycheck_tbl);
        }

        // GET: /SecurityCheck/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecurityCheck_tbl securitycheck_tbl = db.SecurityCheck_tbl.Find(id);
            if (securitycheck_tbl == null)
            {
                return HttpNotFound();
            }
            return View(securitycheck_tbl);
        }

        // POST: /SecurityCheck/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SecurityCheck_tbl securitycheck_tbl = db.SecurityCheck_tbl.Find(id);
            db.SecurityCheck_tbl.Remove(securitycheck_tbl);
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
