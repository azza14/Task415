using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using DemoTasks.Models;
using DemoTasks.DAL;

namespace DemoTasks.Repository
{
    public class CategoryRepository : ICategoryRepository, IDisposable
    {
        //[Dependency]
        public AppDBContext db { get; set; }
        public CategoryRepository(AppDBContext catContext)
        {
         // _CategoryRepository = new CategoryRepository(new AppDBContext()); delete this
            db = catContext;
        }
        public IEnumerable<Category> GetAll()
        {
            return db.Categories.ToList();
        }

        public Category GetById(int Id)
        {
            return db.Categories.Find(Id);
        }

        public void InsertCategory(Category category)
        {
            db.Categories.Add(category);
        }

        public void DeleteCategory(int Id)
        {
            Category category = db.Categories.Find(Id);
            db.Categories.Remove(category);
        }

        public void UpdateCategory(Category category)
        {
            db.Entry(category).State = EntityState.Modified;
        }

        public void SaveCategory()
        {
            db.SaveChanges();
        }
       
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
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