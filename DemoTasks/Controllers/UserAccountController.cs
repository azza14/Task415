using DemoTasks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoTasks.DAL;

namespace DemoTasks.Controllers
{
    public class UserAccountController : Controller
    {
        // GET: UserAccount
        public ActionResult Index()
        {
            using (AppDBContext db = new AppDBContext())
            {
                return View(db.UserAccounts.ToList());
            }
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserAccount account)
        {
           if(ModelState.IsValid)
            {
                using (AppDBContext db = new AppDBContext())
                {
                    db.UserAccounts.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = account.FirstName + " " + account.LastName + " Reqister successful";
            }
            return View();
        }
        //Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserAccount user)
        {
            using (AppDBContext db = new AppDBContext())
            {
                var usr = db.UserAccounts.Single(m => m.UserName == user.UserName && m.Password == user.Password);
                if(usr!=null)
                {
                    Session["UserId"] = usr.UserID.ToString();
                    Session["Username"] = usr.UserName.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "username or password is wrong");
                }
            }
                return View();
        }
        public ActionResult LoggedIn()
        {
            if (Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}