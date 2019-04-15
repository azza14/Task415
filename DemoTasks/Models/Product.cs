using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DemoTasks.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(25, ErrorMessage = "Name should be 1 to 25 char in lenght")]
        public string ProductName { get; set; }
        [Required]
        public decimal Price { get; set; }
        public int CategoryID { get; set; }
        [ForeignKey("CategoryID")]
         public virtual ICollection<Category> Categories { get; set; }


    }
}