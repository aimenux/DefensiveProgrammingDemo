using System.Collections.Generic;
using EnsureThatCoreApp.Models;

namespace EnsureThatCoreApp.Repositories
{
    public interface IRepository
    {
        ICollection<Product> GetProducts();
        Product GetProductByName(string name);
    }
}