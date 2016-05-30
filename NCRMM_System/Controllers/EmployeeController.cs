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

            if (Session["User"] != null)
            {
                User_tbl objUser = (User_tbl)Session["User"];
                EmployeeRoleTable empInfo = (EmployeeRoleTable)Session["EmployeeInfo"];
                ViewBag.UserName = objUser.UserName;
                var employeeList = db.EmployeeRoleTables.Where(e => e.StorageCompanyId == empInfo.StorageCompanyId).ToList();
               
                return View(employeeList);

            }
            else
            {
                return RedirectToAction("Login", "Login");

            }
           
        }

        public ActionResult ApproveEmployee()
        {
            if (Session["User"] != null)
            {
                User_tbl objUser = (User_tbl) Session["User"];
                EmployeeRoleTable empInfo = (EmployeeRoleTable) Session["EmployeeInfo"];
                ViewBag.UserName = objUser.UserName;
                var employeeList = db.EmployeeRoleTables.Where(e => e.StorageCompanyId == empInfo.StorageCompanyId && e.EmployeeId != empInfo.EmployeeId).ToList();
                return View(employeeList);

            }
            else
            {
                return RedirectToAction("Login", "Login");

            }
        }
        [HttpPost]
        public ActionResult ApproveEmployee(List<int> approveList)
        {
           
            
            if (Session["User"] != null)
            {
                
                User_tbl objUser = (User_tbl)Session["User"];
                EmployeeRoleTable empInfo = (EmployeeRoleTable)Session["EmployeeInfo"];
                ViewBag.UserName = objUser.UserName;
                var employeeList = db.EmployeeRoleTables.Where(e => e.StorageCompanyId == empInfo.StorageCompanyId && e.EmployeeId != empInfo.EmployeeId).ToList();
                foreach (EmployeeRoleTable emp in employeeList)
                {
                    if (approveList != null)
                    {


                        if (approveList.Contains(emp.EmployeeId))
                        {
                            if (emp.IsApprove == false)
                            {
                                var item = db.EmployeeRoleTables.FirstOrDefault(d => d.EmployeeId == emp.EmployeeId);
                                item.IsApprove = true;
                                //db.Entry(item).State = EntityState.Modified;
                                db.SaveChanges();
                            }



                        }
                        else
                        {
                            var item = db.EmployeeRoleTables.FirstOrDefault(d => d.EmployeeId == emp.EmployeeId);
                            item.IsApprove = false;
                            db.Entry(item).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        var item = db.EmployeeRoleTables.FirstOrDefault(d => d.EmployeeId == emp.EmployeeId);
                        item.IsApprove = false;
                        db.Entry(item).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                return View(employeeList);

            }
            else
            {
                return RedirectToAction("Login", "Login");

            }
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
            ViewBag.DivisionId = new SelectList(db.Division_tbl, "DivisionId", "DivisionName");
            ViewBag.DistrictId = new SelectList(new List<District_tbl>(), "DistrictId", "DistrictName");
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
        public ActionResult Create([Bind(Include = "UserName,Pass,FullName,DateOfBirth,NIDNumber")] User_tbl user_tbl, Address_tbl address, EmployeeRoleTable employeeroletable, int divisionId = 0)
        {


            user_tbl.UserTypeId = 3;
            user_tbl.IsActive = true;
            var tempUser =
                db.User_tbl.Where(d => d.UserName == user_tbl.UserName || d.NIDNumber == user_tbl.NIDNumber).ToList();

            if (ModelState.IsValid)
            {
                if (tempUser.Count <= 0)
                {
                    db.User_tbl.Add(user_tbl);
                    db.SaveChanges();
                }
                else
                {
                    ViewBag.CustomMessage = "Error";
                }
            }
            address.SourceType = "User";
            address.SourceId = user_tbl.UserId;
            db.Address_tbl.Add(address);
            db.SaveChanges();
            employeeroletable.UpdateBy = 0;
            employeeroletable.UpdateDate=DateTime.Now;
            employeeroletable.UserId = user_tbl.UserId;
            employeeroletable.IsApprove = false;
                db.EmployeeRoleTables.Add(employeeroletable);
                db.SaveChanges();
                
            

            ViewBag.EmployeeId = new SelectList(db.StockMasterRecordCrops_tbl, "StockMasterRecordId", "InvoiceNo", employeeroletable.EmployeeId);
            ViewBag.StorageCompanyId = new SelectList(db.StorageCompany_tbl, "StorageCompanyId", "CompanyName", employeeroletable.StorageCompanyId);
            ViewBag.UserId = new SelectList(db.User_tbl, "UserId", "UserName", employeeroletable.UserId);

            Session["Registration"] = "true";
            return RedirectToAction("Login", "Login");
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
