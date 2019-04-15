using DemoTasks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTasks.Repository
{
    public interface IProductRepository :IDisposable
    {
        IEnumerable<Product> GetAll();
        Product GetById(int Id);
        void CreateProduct(Product product);
        void Update(Product obj);
        void Delete(int product);
        void Save();

    }
}
