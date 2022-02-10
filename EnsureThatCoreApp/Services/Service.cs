using EnsureThat;
using EnsureThatCoreApp.Models;
using EnsureThatCoreApp.Repositories;

namespace EnsureThatCoreApp.Services
{
    public class Service : IService
    {
        private readonly Repository _repository;

        public Service(Repository repository)
        {
            Ensure.That(repository, nameof(repository)).IsNotNull();
            _repository = repository;
        }

        public decimal GetPrice(string name, int quantity)
        {
            Ensure.That(name, nameof(name)).IsNotEmptyOrWhiteSpace();
            Ensure.That(quantity, nameof(quantity)).IsGt(0);
            var product = _repository.GetProductByName(name);
            return GetPrice(product, quantity);
        }

        public decimal GetPrice(Product product, int quantity)
        {
            Ensure.That(product, nameof(product)).IsNotNull();
            Ensure.That(quantity, nameof(quantity)).IsGt(0);
            return product.Price * quantity;
        }
    }
}
