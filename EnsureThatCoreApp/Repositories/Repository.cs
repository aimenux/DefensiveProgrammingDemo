using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using EnsureThat;
using EnsureThatCoreApp.Models;

namespace EnsureThatCoreApp.Repositories
{
    public class Repository : IRepository
    {
        public readonly IReadOnlyCollection<Product> Products;

        public Repository() : this(new ReadOnlyCollection<Product>(GetDefaultProducts()))
        {
        }

        public Repository(IReadOnlyCollection<Product> products)
        {
            Ensure.That(products, nameof(products)).HasItems();
            Products = products;
        }

        public ICollection<Product> GetProducts()
        {
            Ensure.That(Products, nameof(Products)).HasItems();
            return Products.ToList();
        }

        public Product GetProductByName(string name)
        {
            Ensure.That(name, nameof(name)).IsNotEmptyOrWhiteSpace();
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
