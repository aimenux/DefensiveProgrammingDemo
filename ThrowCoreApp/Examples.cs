using ThrowCoreApp.Models;
using ThrowCoreApp.Repositories;
using ThrowCoreApp.Services;

namespace ThrowCoreApp
{
    public static class Examples
    {
        public static void ViolationExample1()
        {
            var repository = new Repository(null);
            var products = repository.GetProducts();
            Console.WriteLine($"Found products : {products.Count}");
        }

        public static void ViolationExample2()
        {
            var service = new Service(null);
            const string name = nameof(ProductType.Sugar);
            var price = service.GetPrice(name, 1);
            Console.WriteLine($"Price of '{name}': {price}");
        }

        public static void ViolationExample3()
        {
            var name = string.Empty;
            var repository = new Repository();
            var product = repository.GetProductByName(name);
            Console.WriteLine($"Product '{product}'");
        }

        public static void ViolationExample4()
        {
            var repository = new Repository();
            var service = new Service(repository);
            const string name = nameof(ProductType.Sugar);
            var price = service.GetPrice(name, 0);
            Console.WriteLine($"Price of '{name}': {price}");
        }

        public static void ViolationExample5()
        {
            var name = string.Empty;
            var invalidProducts = new List<Product>
            {
                new Product(name, 1)
            };
            var repository = new Repository(invalidProducts);
            var products = repository.GetProducts();
            foreach (var product in products)
            {
                Console.WriteLine($"Product '{product}'");
            }
        }

        public static void ViolationExample6()
        {
            const string name = nameof(ProductType.Sugar);
            var invalidProducts = new List<Product>
            {
                new Product(name, -1)
            };
            var repository = new Repository(invalidProducts);
            var products = repository.GetProducts();
            foreach (var product in products)
            {
                Console.WriteLine($"Product '{product}'");
            }
        }
    }
}
