using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoTasks.Models
{
    public class User
    {

        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(5)]

        public string UserName { get; set; }
        [Required]
        [MinLength(5)]
        public string Password { get; set; }
    }
}