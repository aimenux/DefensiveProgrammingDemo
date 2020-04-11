using System.Collections.Generic;
using System.Diagnostics.Contracts;
using CodeContractsFullApp.Contracts;
using CodeContractsFullApp.Models;

namespace CodeContractsFullApp.Repositories
{
    [ContractClass(typeof(AbstractRepositoryContracts))]
    public interface IRepository
    {
        ICollection<Product> GetProducts();
        Product GetProductByName(string name);
    }
}