using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DemoTasks.Models;
using DemoTasks.DAL;
using System.Data.Entity;

namespace DemoTasks.Repository
{
    public class UserRepository : IUserRepository, IDisposable
    {
        public AppDBContext Context { get; set; }
        public UserRepository(AppDBContext UserContext)
        {
            Context = UserContext;
        }

        public IEnumerable<User> GetAll()
        {

            return Context.Users.ToList();
        }

        public User GetById(int id)
        {
            var user = Context.Users.FirstOrDefault(x => x.Id == id);
            return user;
        }

        public void InsertUser(User user)
        {
            Context.Users.Add(user);
        }
       
        public void UpdateUser(User user)
        {
            Context.Entry(user).State = EntityState.Modified;
        }
        public void DeleteUser(int id)
        {
            var user = Context.Users.FirstOrDefault(x => x.Id == id);
            Context.Users.Remove(user);
        }
        public void SaveUser()
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