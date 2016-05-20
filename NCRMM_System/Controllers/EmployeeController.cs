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
    public class EmployeeController : Controller
    {
        private NCRMMLS_DBEntities2 db = new NCRMMLS_DBEntities2();

        // GET: /Employee/
        public ActionResult Index()
        {
            var employeeroletables = db.EmployeeRoleTables.Include(e => e.StockMasterRecordCrops_tbl).Include(e => e.StorageCompany_tbl).Include(e => e.User_tbl);
            return View(employeeroletables.ToList());
        }

        // GET: /Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeRoleTable employeeroletable = db.EmployeeRoleTables.Find(id);
            if (employeeroletable == null)
            {
                return HttpNotFound();
            }
            return View(employeeroletable);
        }

        // GET: /Employee/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(db.StockMasterRecordCrops_tbl, "StockMasterRecordId", "InvoiceNo");
            ViewBag.StorageCompanyId = new SelectList(db.StorageCompany_tbl, "StorageCompanyId", "CompanyName");
            ViewBag.UserId = new SelectList(db.User_tbl, "UserId", "UserName");
            return View();
        }

        // POST: /Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="EmployeeId,EmployeeRole,UpdateBy,UpdateDate,StorageCompanyId,UserId")] EmployeeRoleTable employeeroletable)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeRoleTables.Add(employeeroletable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeId = new SelectList(db.StockMasterRecordCrops_tbl, "StockMasterRecordId", "InvoiceNo", employeeroletable.EmployeeId);
            ViewBag.StorageCompanyId = new SelectList(db.StorageCompany_tbl, "StorageCompanyId", "CompanyName", employeeroletable.StorageCompanyId);
            ViewBag.UserId = new SelectList(db.User_tbl, "UserId", "UserName", employeeroletable.UserId);
            return View(employeeroletable);
        }

        // GET: /Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeRoleTable employeeroletable = db.EmployeeRoleTables.Find(id);
            if (employeeroletable == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(db.StockMasterRecordCrops_tbl, "StockMasterRecordId", "InvoiceNo", employeeroletable.EmployeeId);
            ViewBag.StorageCompanyId = new SelectList(db.StorageCompany_tbl, "StorageCompanyId", "CompanyName", employeeroletable.StorageCompanyId);
            ViewBag.UserId = new SelectList(db.User_tbl, "UserId", "UserName", employeeroletable.UserId);
            return View(employeeroletable);
        }

        // POST: /Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="EmployeeId,EmployeeRole,UpdateBy,UpdateDate,StorageCompanyId,UserId")] EmployeeRoleTable employeeroletable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeroletable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(db.StockMasterRecordCrops_tbl, "StockMasterRecordId", "InvoiceNo", employeeroletable.EmployeeId);
            ViewBag.StorageCompanyId = new SelectList(db.StorageCompany_tbl, "StorageCompanyId", "CompanyName", employeeroletable.StorageCompanyId);
            ViewBag.UserId = new SelectList(db.User_tbl, "UserId", "UserName", employeeroletable.UserId);
            return View(employeeroletable);
        }

        // GET: /Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeRoleTable employeeroletable = db.EmployeeRoleTables.Find(id);
            if (employeeroletable == null)
            {
                return HttpNotFound();
            }
            return View(employeeroletable);
        }

        // POST: /Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeRoleTable employeeroletable = db.EmployeeRoleTables.Find(id);
            db.EmployeeRoleTables.Remove(employeeroletable);
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
