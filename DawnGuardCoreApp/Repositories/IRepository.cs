using System.Collections.Generic;
using DawnGuardCoreApp.Models;

namespace DawnGuardCoreApp.Repositories
{
    public interface IRepository
    {
        ICollection<Product> GetProducts();
        Product GetProductByName(string name);
    }
}