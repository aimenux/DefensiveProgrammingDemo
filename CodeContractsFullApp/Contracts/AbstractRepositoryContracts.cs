using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using CodeContractsFullApp.Models;
using CodeContractsFullApp.Repositories;

namespace CodeContractsFullApp.Contracts
{
    [ContractClassFor(typeof(IRepository))]
    public abstract class AbstractRepositoryContracts : IRepository
    {
        public ICollection<Product> GetProducts()
        {
            Contract.Ensures(Contract.Result<ICollection<Product>>()?.Any() == true);
            throw new NotSupportedException("No needed implementation for contracts");
        }

        public Product GetProductByName(string name)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(name), $"{nameof(name)} should not be null or empty");
            throw new NotSupportedException("No needed implementation for contracts");
        }
    }
}