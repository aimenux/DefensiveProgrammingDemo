using Dawn;
using DawnGuardCoreApp.Models;
using DawnGuardCoreApp.Repositories;

namespace DawnGuardCoreApp.Services
{
    public class Service : IService
    {
        private readonly Repository _repository;

        public Service(Repository repository)
        {
            Guard.Argument(repository, nameof(repository)).NotNull();
            _repository = repository;
        }

        public decimal GetPrice(string name, int quantity)
        {
            Guard.Argument(name, nameof(name)).NotNull().NotEmpty().NotWhiteSpace();
            Guard.Argument(quantity, nameof(quantity)).GreaterThan(0);
            var product = _repository.GetProductByName(name);
            return GetPrice(product, quantity);
        }

        public decimal GetPrice(Product product, int quantity)
        {
            Guard.Argument(product, nameof(product)).NotNull();
            Guard.Argument(quantity, nameof(quantity)).GreaterThan(0);
            return product.Price * quantity;
        }
    }
}
