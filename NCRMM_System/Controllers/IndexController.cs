using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NCRMM_System.Models;

namespace NCRMM_System.Controllers
{
    public class IndexController : Controller
    {
        //
        private NCRMMLS_DBEntities2 db = new NCRMMLS_DBEntities2();
        // GET: /Index/
        public ActionResult IndexEmployee()
        {
            User_tbl objUser = (User_tbl) Session["User"];
            ViewBag.UserName = objUser.FullName;
            ViewBag.CompanyName =
                db.EmployeeRoleTables.FirstOrDefault(er => er.UserId == objUser.UserId).StorageCompany_tbl.CompanyName;

            return View();
        }

        public ActionResult IndexUser()
        {

            User_tbl objUser = (User_tbl)Session["User"];
            ViewBag.UserName = objUser.FullName;
            return View();
        }
	}
}