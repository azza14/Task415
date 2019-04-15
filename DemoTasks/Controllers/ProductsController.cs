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
    public class ProductsController : Controller
    {
        AppDBContext context = new AppDBContext();
        private IProductRepository ProRepository;
        private ICategoryRepository categoryRepository;
        public ProductsController()
        {

           ProRepository = new ProductRepository(new AppDBContext());
            categoryRepository = new CategoryRepository(new AppDBContext());
        }
        // GET: Products
        public ActionResult Index()
        {             
                return View(ProRepository.GetAll());
        }
        // GET: Products/Create
        public ActionResult Create()
        {
            //ViewBag.CategoryId = new SelectList(context.Categories.Select(m=>m.Id), "Id", "CategorName");
            //ViewBag.CategoryID = new SelectList(context.Categories, "Id", "CategorName");
            //ViewBag.CategoryId = new SelectList(context.Categories, "Id", "CategorName");
            ///ViewBag.CategoryId = categoryRepository.GetAll().Select(x => new SelectListItem { Text = x.CategorName.ToString(), Value = x.CategorName.ToString() }).ToList();

            IEnumerable<SelectListItem> items = context.Categories
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Description
                });
            ViewBag.Categories = items;

            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProductName,Price,CategoryID")] Product productModel)
        {
            //var Catelist = new CategoryViewModel();
            //ViewBag.CategoryId = Catelist.ItemsCategory;
            if (ModelState.IsValid)
            {
                //var pro = new Product()
                //{
                //    Id = productModel.Id,
                //    ProductName = productModel.ProductName,
                //    Price=productModel.Price,
                //    CategoryID=productModel.CategoryID

                //};
                ProRepository.CreateProduct(productModel);
                ProRepository.Save();
                return RedirectToAction("Index");
            }
            IEnumerable<SelectListItem> items = context.Categories
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Description
                });
            ViewBag.Categories = items;
            return View(productModel);
        }

        // GET: Products/Details/5
        public ActionResult Details(int?id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = ProRepository.GetById((int)id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = ProRepository.GetById((int)id);
            if (product == null)
            {
                return HttpNotFound();
            }
            IEnumerable<SelectListItem> items = context.Categories.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Description });
            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProductName,Price,CategoryID")] Product product)
        {
         
            if (ModelState.IsValid)
            {
                ProRepository.Update(product);
                ProRepository.Save();
                return RedirectToAction("Index");
            }
            IEnumerable<SelectListItem> items = context.Categories.Select(c => new SelectListItem { Value = c.Id.ToString(),Text = c.Description});
            ViewBag.Categories = items; return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = ProRepository.GetById((int)id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Product product = ProRepository.GetById(id);
                ProRepository.Delete(id);
                ProRepository.Save();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new System.Web.Routing.RouteValueDictionary {
                { "id", id },{ "saveChangesError", true } });
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ProRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

//        // GET: Products/Create
//        public ActionResult Create()
//        {
//            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "CategorName");
//            return View();
//        }

//        // POST: Products/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "Id,ProductName,Price,CategoryID")] Product product)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Products.Add(product);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "CategorName", product.CategoryID);
//            return View(product);
//        }

//        // GET: Products/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Product product = db.Products.Find(id);
//            if (product == null)
//            {
//                return HttpNotFound();
//            }
//            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "CategorName", product.CategoryID);
//            return View(product);
//        }

//        // POST: Products/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "Id,ProductName,Price,CategoryID")] Product product)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(product).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "CategorName", product.CategoryID);
//            return View(product);
//        }

//        // GET: Products/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Product product = db.Products.Find(id);
//            if (product == null)
//            {
//                return HttpNotFound();
//            }
//            return View(product);
//        }

