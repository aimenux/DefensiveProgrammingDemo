using System.Collections.Generic;
using GuardClausesCoreApp.Models;

namespace GuardClausesCoreApp.Repositories
{
    public interface IRepository
    {
        ICollection<Product> GetProducts();
        Product GetProductByName(string name);
    }
}