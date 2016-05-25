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
    public class CropsCatagoryController : Controller
    {
        private NCRMMLS_DBEntities2 db = new NCRMMLS_DBEntities2();

        // GET: /CropsCatagory/
        public ActionResult Index()
        {
            return View(db.CropsCatagory_tbl.ToList());
        }

        // GET: /CropsCatagory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CropsCatagory_tbl cropscatagory_tbl = db.CropsCatagory_tbl.Find(id);
            if (cropscatagory_tbl == null)
            {
                return HttpNotFound();
            }
            return View(cropscatagory_tbl);
        }

        // GET: /CropsCatagory/Create
        public ActionResult Create()
        {
            if (Session["User"] != null)
            {
                User_tbl objUser = (User_tbl)Session["User"];
                ViewBag.UserName = objUser.FullName;

            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
            ViewBag.Crops_tbl = new SelectList(db.Crops_tbl, "CropsId", "CropsName");
            return View();
        }

        // POST: /CropsCatagory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="CropsCatagoryName,Details,CropsId")] CropsCatagory_tbl cropscatagory_tbl)
        {
            if (Session["User"] != null)
            {
                User_tbl objUser = (User_tbl)Session["User"];
                ViewBag.UserName = objUser.FullName;

            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
            if (ModelState.IsValid)
            {
                db.CropsCatagory_tbl.Add(cropscatagory_tbl);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(cropscatagory_tbl);
        }

        // GET: /CropsCatagory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["User"] != null)
            {
                User_tbl objUser = (User_tbl)Session["User"];
                ViewBag.UserName = objUser.FullName;

            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CropsCatagory_tbl cropscatagory_tbl = db.CropsCatagory_tbl.Find(id);
            if (cropscatagory_tbl == null)
            {
                return HttpNotFound();
            }
            return View(cropscatagory_tbl);
        }

        // POST: /CropsCatagory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="CropsCatagoryId,CropsCatagoryName,Details")] CropsCatagory_tbl cropscatagory_tbl)
        {
            if (Session["User"] != null)
            {
                User_tbl objUser = (User_tbl)Session["User"];
                ViewBag.UserName = objUser.FullName;

            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
            if (ModelState.IsValid)
            {
                db.Entry(cropscatagory_tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cropscatagory_tbl);
        }

        // GET: /CropsCatagory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CropsCatagory_tbl cropscatagory_tbl = db.CropsCatagory_tbl.Find(id);
            if (cropscatagory_tbl == null)
            {
                return HttpNotFound();
            }
            return View(cropscatagory_tbl);
        }

        // POST: /CropsCatagory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CropsCatagory_tbl cropscatagory_tbl = db.CropsCatagory_tbl.Find(id);
            db.CropsCatagory_tbl.Remove(cropscatagory_tbl);
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
