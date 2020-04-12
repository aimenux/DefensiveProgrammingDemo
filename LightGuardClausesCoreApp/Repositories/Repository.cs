using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Light.GuardClauses;
using LightGuardClausesCoreApp.Models;

namespace LightGuardClausesCoreApp.Repositories
{
    public class Repository : IRepository
    {
        public readonly IReadOnlyCollection<Product> Products;

        public Repository() : this(new ReadOnlyCollection<Product>(GetDefaultProducts()))
        {
        }

        public Repository(IReadOnlyCollection<Product> products)
        {
            Products = products.MustNotBeNullOrEmpty(nameof(products));
        }

        public ICollection<Product> GetProducts()
        {
            Products.MustNotBeNullOrEmpty(nameof(Products));
            return Products.ToList();
        }

        public Product GetProductByName(string name)
        {
            name.MustNotBeNullOrWhiteSpace(nameof(name));
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
