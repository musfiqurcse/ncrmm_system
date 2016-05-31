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
    public class StockTempRecordsController : Controller
    {
        private NCRMMLS_DBEntities2 db = new NCRMMLS_DBEntities2();

        // GET: StockTempRecords
        public ActionResult Index()
        {
            var stockTempRecords = db.StockTempRecords.Include(s => s.CropsCatagory_tbl);
            return View(stockTempRecords.ToList());
        }

        // GET: StockTempRecords/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockTempRecord stockTempRecord = db.StockTempRecords.Find(id);
            if (stockTempRecord == null)
            {
                return HttpNotFound();
            }
            return View(stockTempRecord);
        }

    
        public ActionResult EditCropsInfo(int CropsCatagoryId, string cropsDescription, string CropsAmount)
        {

            if (Session["EmployeeInfo"] != null)
            {
                EmployeeRoleTable tmpEmp = (EmployeeRoleTable)Session["EmployeeInfo"];

                StockTempRecord tmpObj = new StockTempRecord();
                tmpObj.CropsCatagoryId = CropsCatagoryId;
                tmpObj.Description = cropsDescription;
                tmpObj.StockAmount = Convert.ToDecimal(CropsAmount);
                tmpObj.EmployeerId = tmpEmp.EmployeeId;
                db.StockTempRecords.Add(tmpObj);
                db.SaveChanges();
                return RedirectToAction("StockCropsDetails", "StockMasterRecordCrops");
            }
            return RedirectToAction("Login", "Login");
        }



        public ActionResult GetTempCatagories()
        {
            if (Session["EmployeeInfo"] != null)
            {
                EmployeeRoleTable objEmployee = (EmployeeRoleTable) Session["EmployeeInfo"];
                var stockTempRecordTableInfo =
                    new SelectList(db.StockTempRecords.Where(emp => emp.EmployeerId == objEmployee.EmployeeId));
                return PartialView(@"~/Views/Shared/_CropsRecordDetails.cshtml", stockTempRecordTableInfo);
            }
            return RedirectToAction("Login", "Login");
        }
       
        public ActionResult DeleteCropsInfo(int CropsCatagoryId, string cropsDescription, string CropsAmount)
        {

            if (Session["EmployeeInfo"] != null)
            {
                EmployeeRoleTable tmpEmp = (EmployeeRoleTable)Session["EmployeeInfo"];

                StockTempRecord tmpObj = new StockTempRecord();
                tmpObj.CropsCatagoryId = CropsCatagoryId;
                tmpObj.Description = cropsDescription;
                tmpObj.StockAmount = Convert.ToDecimal(CropsAmount);
                tmpObj.EmployeerId = tmpEmp.EmployeeId;
                db.StockTempRecords.Add(tmpObj);
                db.SaveChanges();
                return RedirectToAction("StockCropsDetails", "StockMasterRecordCrops");
            }
            return RedirectToAction("Login", "Login");
        }

        // GET: StockTempRecords/Create
        public ActionResult Create()
        {
            ViewBag.CropsCatagoryId = new SelectList(db.CropsCatagory_tbl, "CropsCatagoryId", "CropsCatagoryName");
            return View();
        }

        // POST: StockTempRecords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tmpStockDetailId,CropsCatagoryId,StockAmount")] StockTempRecord stockTempRecord)
        {
            if (ModelState.IsValid)
            {
                db.StockTempRecords.Add(stockTempRecord);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CropsCatagoryId = new SelectList(db.CropsCatagory_tbl, "CropsCatagoryId", "CropsCatagoryName", stockTempRecord.CropsCatagoryId);
            return View(stockTempRecord);
        }

        // GET: StockTempRecords/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockTempRecord stockTempRecord = db.StockTempRecords.Find(id);
            if (stockTempRecord == null)
            {
                return HttpNotFound();
            }
            ViewBag.CropsCatagoryId = new SelectList(db.CropsCatagory_tbl, "CropsCatagoryId", "CropsCatagoryName", stockTempRecord.CropsCatagoryId);
            return View(stockTempRecord);
        }

        // POST: StockTempRecords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tmpStockDetailId,CropsCatagoryId,StockAmount")] StockTempRecord stockTempRecord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stockTempRecord).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CropsCatagoryId = new SelectList(db.CropsCatagory_tbl, "CropsCatagoryId", "CropsCatagoryName", stockTempRecord.CropsCatagoryId);
            return View(stockTempRecord);
        }

        // GET: StockTempRecords/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockTempRecord stockTempRecord = db.StockTempRecords.Find(id);
            if (stockTempRecord == null)
            {
                return HttpNotFound();
            }
            return View(stockTempRecord);
        }

        // POST: StockTempRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StockTempRecord stockTempRecord = db.StockTempRecords.Find(id);
            db.StockTempRecords.Remove(stockTempRecord);
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
