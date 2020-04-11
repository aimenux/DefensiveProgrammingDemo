using System;
using System.Collections.Generic;
using CodeContractsFullApp.Models;
using CodeContractsFullApp.Repositories;
using CodeContractsFullApp.Services;

namespace CodeContractsFullApp
{
    public static class Examples
    {
        public static void EnsuresViolationExample1()
        {
            var repository = new Repository(null);
            var products = repository.GetProducts();
            Console.WriteLine($"Found products : {products.Count}");
        }

        public static void EnsuresViolationExample2()
        {
            var service = new Service(null);
            const string name = nameof(ProductType.Sugar);
            var price = service.GetPrice(name, 1);
            Console.WriteLine($"Price of '{name}': {price}");
        }

        public static void RequiresViolationExample1()
        {
            var name = string.Empty;
            var repository = new Repository();
            var product = repository.GetProductByName(name);
            Console.WriteLine($"Product '{product}'");
        }

        public static void RequiresViolationExample2()
        {
            var repository = new Repository();
            var service = new Service(repository);
            const string name = nameof(ProductType.Sugar);
            var price = service.GetPrice(name, -1);
            Console.WriteLine($"Price of '{name}': {price}");
        }

        public static void InvariantViolationExample1()
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

        public static void InvariantViolationExample2()
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
