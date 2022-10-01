using System.Collections.ObjectModel;
using Throw;
using ThrowCoreApp.Models;

namespace ThrowCoreApp.Repositories
{
    public class Repository : IRepository
    {
        public readonly IReadOnlyCollection<Product> Products;

        public Repository() : this(new ReadOnlyCollection<Product>(GetDefaultProducts()))
        {
        }

        public Repository(IReadOnlyCollection<Product> products)
        {
            products.ThrowIfNull().IfEmpty();
            Products = products;
        }

        public ICollection<Product> GetProducts()
        {
            Products.ThrowIfNull().IfEmpty();
            return Products.ToList();
        }

        public Product GetProductByName(string name)
        {
            name.ThrowIfNull().IfEmpty().IfWhiteSpace();
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
