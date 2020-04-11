using System;
using System.Diagnostics.Contracts;
using CodeContractsFullApp.Models;
using CodeContractsFullApp.Services;

namespace CodeContractsFullApp.Contracts
{
    [ContractClassFor(typeof(IService))]
    public abstract class AbstractServiceContracts : IService
    {
        public decimal GetPrice(string name, int quantity)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(name), $"{nameof(name)} should not be null or empty");
            Contract.Requires(quantity > 0, $"{nameof(quantity)} should be strictly positive");
            Contract.Ensures(Contract.Result<decimal>() > 0);
            throw new NotSupportedException("No needed implementation for contracts");
        }

        public decimal GetPrice(Product product, int quantity)
        {
            Contract.Requires(product != null, $"{nameof(product)} should not be null");
            Contract.Requires(product.Price > 0, $"{nameof(Product.Price)} should be strictly positive");
            Contract.Requires(quantity > 0, $"{nameof(quantity)} should be strictly positive");
            Contract.Ensures(Contract.Result<decimal>() > 0);
            throw new NotSupportedException("No needed implementation for contracts");
        }
    }
}