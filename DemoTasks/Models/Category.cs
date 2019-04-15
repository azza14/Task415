using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoTasks.Models
{
    public class Category 
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Name should be 1 to 50 char in lenght")]
   
        public string CategorName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Name should be 1 to 50 char in lenght")]
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}