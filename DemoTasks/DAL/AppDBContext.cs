using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using DemoTasks.Models;

namespace DemoTasks.DAL
{
    public class AppDBContext:DbContext
    {
        public AppDBContext() : base("name=MyConnection")
        {

        }
        //public AppDBContext(DbContextOptions<AppDBContext> options)
        //: base(options)
        //{
        //}
        //public AppDBContext(String connectionString):base
        //    ((new DbContextOptionsBuilder<AppDbContext>()).UseSqlServer(connectionString).Options)
        //    { }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }

    internal class AppDbContext
    {
    }
}