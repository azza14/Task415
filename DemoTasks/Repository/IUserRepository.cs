using DemoTasks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTasks.Repository
{
    interface IUserRepository : IDisposable
    {
        IEnumerable<User> GetAll();
        User GetById(int Id);
        void InsertUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
        void SaveUser();
    }
}
