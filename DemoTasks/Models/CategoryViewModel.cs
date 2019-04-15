using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoTasks.Models
{
    public class CategoryViewModel
    {
        public virtual IEnumerable<Product> Products { get; set; }
       // public SelectList Categorylist { get; set; }
        public int CatId { get; set; }
        public IEnumerable<Category> ItemsCategory  {get; set;}
        //public virtual ICollection<Category> CategoriesProduct { get; set; }

    }
}