using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Dawn;
using DawnGuardCoreApp.Models;

namespace DawnGuardCoreApp.Repositories
{
    public class Repository : IRepository
    {
        public readonly IReadOnlyCollection<Product> Products;

        public Repository() : this(new ReadOnlyCollection<Product>(GetDefaultProducts()))
        {
        }

        public Repository(IReadOnlyCollection<Product> products)
        {
            Guard.Argument(products, nameof(products)).NotNull().NotEmpty();
            Products = products;
        }

        public ICollection<Product> GetProducts()
        {
            Guard.Argument(Products, nameof(Products)).NotNull().NotEmpty();
            return Products.ToList();
        }

        public Product GetProductByName(string name)
        {
            Guard.Argument(name, nameof(name)).NotNull().NotEmpty().NotWhiteSpace();
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
