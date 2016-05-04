﻿using System;
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
    public class UserController : Controller
    {
        private NCRMMLS_DBEntities2 db = new NCRMMLS_DBEntities2();

       // GET: User
        public ActionResult Index()
        {
            var user_tbl = db.User_tbl.Include(u => u.UserType_tbl);
            return View(user_tbl.ToList());
        }

        // GET: User/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    User_tbl user_tbl = db.User_tbl.Find(id);
        //    if (user_tbl == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(user_tbl);
        //}

        // GET: User/Create
        public ActionResult Create()
        {
            ViewBag.UserTypeId = new SelectList(db.UserType_tbl, "UserTypeId", "UserType");
            ViewBag.DistrictId = new SelectList(db.District_tbl, "DistrictId", "DistrictName");
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,UserName,Pass,FullName,DateOfBirth,NIDNumber")] User_tbl user_tbl)
        {
            user_tbl.UserTypeId = 3;
            user_tbl.IsActive = true;

            if (ModelState.IsValid)
            {
                db.User_tbl.Add(user_tbl);
                db.SaveChanges();
                return RedirectToAction("Login","Login");
            }

            ViewBag.UserTypeId = new SelectList(db.UserType_tbl, "UserTypeId", "UserType", user_tbl.UserTypeId);
            return View(user_tbl);
        }

        // GET: User/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    User_tbl user_tbl = db.User_tbl.Find(id);
        //    if (user_tbl == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.UserTypeId = new SelectList(db.UserType_tbl, "UserTypeId", "UserType", user_tbl.UserTypeId);
        //    return View(user_tbl);
        //}

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "UserId,UserName,Pass,FullName,DateOfBirth,AddressId,UserTypeId,IsActive,NIDNumber")] User_tbl user_tbl)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(user_tbl).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.UserTypeId = new SelectList(db.UserType_tbl, "UserTypeId", "UserType", user_tbl.UserTypeId);
        //    return View(user_tbl);
        //}

        // GET: User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_tbl user_tbl = db.User_tbl.Find(id);
            if (user_tbl == null)
            {
                return HttpNotFound();
            }
            return View(user_tbl);
        }

        // POST: User/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    User_tbl user_tbl = db.User_tbl.Find(id);
        //    db.User_tbl.Remove(user_tbl);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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