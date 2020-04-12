using System.Collections.Generic;
using PitcherCoreApp.Models;

namespace PitcherCoreApp.Repositories
{
    public interface IRepository
    {
        ICollection<Product> GetProducts();
        Product GetProductByName(string name);
    }
}