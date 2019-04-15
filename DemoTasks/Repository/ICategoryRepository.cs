
using DemoTasks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTasks.Repository
{
   public  interface ICategoryRepository :  IDisposable
    {
        IEnumerable<Category> GetAll();
        Category GetById(int Id);
        void InsertCategory(Category obj);
        void UpdateCategory(Category obj);
        void DeleteCategory(int Id);
        void SaveCategory();
    }
}
