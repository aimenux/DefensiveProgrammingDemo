using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Ardalis.GuardClauses;
using GuardClausesCoreApp.Models;

namespace GuardClausesCoreApp.Repositories
{
    public class Repository : IRepository
    {
        public readonly IReadOnlyCollection<Product> Products;

        public Repository() : this(new ReadOnlyCollection<Product>(GetDefaultProducts()))
        {
        }

        public Repository(IReadOnlyCollection<Product> products)
        {
            Guard.Against.NullOrEmpty(products, nameof(products));
            Products = products;
        }

        public ICollection<Product> GetProducts()
        {
            Guard.Against.NullOrEmpty(Products, nameof(Products));
            return Products.ToList();
        }

        public Product GetProductByName(string name)
        {
            Guard.Against.NullOrWhiteSpace(name, nameof(name));
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
