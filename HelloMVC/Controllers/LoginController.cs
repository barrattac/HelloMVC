using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;

namespace HelloMVC.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        public ActionResult Index()
        {
            if (Session["UserId"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public ActionResult Login(LoginFM credentials)
        {
            UserVM user = new LoginService().Login(credentials);
            if (user != null)
            {
                Session["UserID"] = user.ID;
                return RedirectToAction("Index", "Home");
            }
            ViewBag.ErrorMessage = "Login Credentials Not Valid.";
            return View("Index");
        }
        public ActionResult Logout()
        {
            Session["UserId"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}