using System.Collections.Generic;
using LightGuardClausesCoreApp.Models;

namespace LightGuardClausesCoreApp.Repositories
{
    public interface IRepository
    {
        ICollection<Product> GetProducts();
        Product GetProductByName(string name);
    }
}