using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using NCRMM_System.Models;

namespace NCRMM_System.Controllers
{
    public class LoginController : Controller
    {
        private NCRMMLS_DBEntities2 db = new NCRMMLS_DBEntities2();
        // GET: Login
        public ActionResult Login()
        {
            ViewBag.CustomMessage = null;
            string item = (string) Session["Registration"];
            if (item == "true")
            {
                ViewBag.CustomMessage = "Success";
                Session["Registration"] = null;
            }


            return View();
        }
        [HttpPost]
        public ActionResult Login(string username="", string password="", bool remember=false)
        {

            List<User_tbl> user = db.User_tbl.Where(ds => ds.UserName == username && ds.Pass == password).ToList();
            if (user.Count > 0)
            {
                User_tbl objUser = user.FirstOrDefault();
                Session["user"] = objUser;
                if (objUser.UserType_tbl.UserTypeId == 2)
                {
                    
                    return RedirectToAction("IndexUser","Index");
                }
                else if (objUser.UserType_tbl.UserTypeId == 3)
                {

                    Session["EmployeeInfo"] =
                        db.EmployeeRoleTables.Where(d => d.UserId == objUser.UserId).ToList().First();
                    return RedirectToAction("IndexEmployee", "Index");

                }
                else
                {
                    return RedirectToAction("Login","Login");
                }
            //    return RedirectToAction("Index", "User");
                //return RedirectToAction()
            }

            
            ViewBag.CustomMessage = "Error";

            return View();
        }
        
    }
}