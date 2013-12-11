using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloMVC.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        public ActionResult Index()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            UserService userS = new UserService();
            UsersVM usersVM = userS.GetUsers();
            return View(usersVM);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(UserFM user)
        {
            //if user valid create user
            UserService users = new UserService();
            users.CreateUser(user);
            return RedirectToAction("Index");
            //else return to create with errors
        }
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            UserService users = new UserService();
            return View(users.GetUserFM(ID));
        }
        [HttpPost]
        public ActionResult Edit(UserFM user)
        {
            //if user valid edit user
            UserService users = new UserService();
            users.UpdateUser(user);
            return RedirectToAction("Index");
            //else return to edit with errors
        }
        [HttpGet]
        public ActionResult ChangePassword()
        {
            UserService users = new UserService();
            return View(users.GetChangePassFM(Convert.ToInt32(Session["UserId"])));
        }
        [HttpPost]
        public ActionResult ChangePassword(ChangePassFM pass)
        {
            //if user valid user
            UserService users = new UserService();
            if (users.VerifyPass(pass) && pass.NewPass == pass.ConfirmPass && pass.NewPass.Length > 7)
            {
                users.UpdateUser(pass);
            }
            return RedirectToAction("Index");
            //else return with errors
        }
        public ActionResult Delete(int ID)
        {
            UserService users = new UserService();
            users.DeleteUser(ID);
            return RedirectToAction("Index");
        }
        public ActionResult ResetPassword(int ID)
        {
            UserService users = new UserService();
            users.ResetPass(users.GetChangePassFM(ID));
            return RedirectToAction("Index");
        }
    }
}