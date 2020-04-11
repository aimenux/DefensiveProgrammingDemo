using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Linq;
using CodeContractsFullApp.Models;

namespace CodeContractsFullApp.Repositories
{
    public class Repository : IRepository
    {
        public readonly IReadOnlyCollection<Product> Products;

        public Repository() : this(new ReadOnlyCollection<Product>(GetDefaultProducts()))
        {
        }

        public Repository(IReadOnlyCollection<Product> products)
        {
            Products = products;
            Contract.Ensures(Products != null, $"{nameof(Products)} should not be null");
            Contract.Ensures(Products.Any(), $"{nameof(Products)} should not be empty");
        }

        public ICollection<Product> GetProducts()
        {
            return Products.ToList();
        }

        public Product GetProductByName(string name)
        {
            return Products.FirstOrDefault(x => string.Equals(x.Name, name));
        }

        private static List<Product> GetDefaultProducts()
        {
            return new List<Product>
            {
                new Product(nameof(ProductType.Butter), 1.5m),
                new Product(nameof(ProductType.Cheese), 2.5m),
                new Product(nameof(ProductType.Sugar), 1.1m),
                new Product(nameof(ProductType.Milk), 1.3m)
            };
        }
    }
}
