using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DemoTasks.DAL;
using DemoTasks.Models;

using DemoTasks.Repository;
namespace DemoTasks.Controllers
{
    public class UsersController : Controller
    {
        private IUserRepository userRepository;
        public UsersController()
        {
            this.userRepository = new UserRepository(new AppDBContext());
        }
        // GET: Users
        public ActionResult Index()
        {
            return View(userRepository.GetAll().ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = userRepository.GetById(id.Value);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,UserName,Password")]User user)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    userRepository.InsertUser(user);
                    return RedirectToAction("Index");
                }


                return View(user);
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = userRepository.GetById(id.Value);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);

        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,UserName,Password")]User user)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    userRepository.UpdateUser(user);
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(user);
            }
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = userRepository.GetById(id.Value);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                // TODO: Add delete logic here
                userRepository.DeleteUser(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                userRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

