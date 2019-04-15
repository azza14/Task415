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
    public class CategoriesController : Controller{
        private ICategoryRepository categoryRepository;
        public CategoriesController()
        {
            this.categoryRepository = new CategoryRepository(new AppDBContext());
        }
        // GET: Categories
        public ActionResult Index()
        {
            return View(categoryRepository.GetAll());
        }
        // GET: Categories/Create
        public ActionResult Create()
        {
            return View(new Category());
        }
        // POST: Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CategorName,Description")] Category category)
        {
            if (ModelState.IsValid)
            {
                categoryRepository.InsertCategory(category);
                categoryRepository.SaveCategory();
                return RedirectToAction("Index");
            }
            return View(category);
        }
        // GET: Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = categoryRepository.GetById((int)id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = categoryRepository.GetById((int)id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CategorName,Description")] Category category)
        {
            if (ModelState.IsValid)
            {
                categoryRepository.UpdateCategory(category);
                categoryRepository.SaveCategory();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = categoryRepository.GetById((int)id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
           try
            {
             Category category = categoryRepository.GetById(id);
            categoryRepository.DeleteCategory(id);
            categoryRepository.SaveCategory();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new System.Web.Routing.RouteValueDictionary
                {
                    { "id", id },{ "saveChangesError", true }
                });
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                categoryRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
