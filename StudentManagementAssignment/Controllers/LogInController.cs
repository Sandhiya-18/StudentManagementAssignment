using StudentManagementAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagementAssignment.Controllers
{
    public class LogInController : Controller


    {


        StudentMngEntities1 db = new StudentMngEntities1();
        // GET: LogIn
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(User objchk)
        {

            if (ModelState.IsValid)
            {
                using (StudentMngEntities1 db = new StudentMngEntities1())
                {
                    var obj = db.Users.Where(a => a.UserName.Equals(objchk.UserName) && a.Password.Equals(objchk.Password)).FirstOrDefault();

                    if (obj != null)
                    {
                        Session["userId"] = obj.ID.ToString();
                        Session["userName"] = obj.UserName.ToString();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "The username or password incorrect");
                    }
                }
            }
           


            return View(objchk);
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "LogIn");
        }
    }
}