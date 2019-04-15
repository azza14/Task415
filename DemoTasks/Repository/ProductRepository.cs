using DemoTasks.DAL;
using DemoTasks.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoTasks.Repository
{
    public class ProductRepository :IProductRepository,IDisposable
    {
        // [Dependency]#
        public AppDBContext Context   { get; set; }
        public ProductRepository(AppDBContext proContext)
        {
            
            Context = proContext;
        }
        public void Delete(int id)
        {
            Product product = Context.Products.Find(id);
            Context.Products.Remove(product);
        }
        public IEnumerable<Product> GetAll()
        {
           return Context.Products.ToList();
        }

        public Product GetById(int Id)
        {
            return Context.Products.Find(Id);
        }

        public void CreateProduct(Product pro)
        {

            var product = new Product()
            {
                ProductName = pro.ProductName,
                Price = pro.Price,
                CategoryID = pro.CategoryID,
                Id = pro.Id,
                Categories = new List<Category>()
                            {
                                new Category
                                {
                                CategorName=pro.Categories.Select(b=>b.CategorName).ToString(),
                                Description=pro.Categories.Select(e=>e.Description).ToString(),
                                }

                            }
            };
            Context.Products.Add(new Product());
        }
        public void Update(Product model)
        {
            Product product = Context.Products.Where(m => m.Id == model.Id).SingleOrDefault();
            if(product!=null)
            {
                Context.Entry(model).State = EntityState.Modified;
                Context.SaveChanges();
            }
        }
        public void Save()
        {
            Context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}