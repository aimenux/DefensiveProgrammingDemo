using Throw;
using ThrowCoreApp.Models;
using ThrowCoreApp.Repositories;

namespace ThrowCoreApp.Services
{
    public class Service : IService
    {
        private readonly Repository _repository;

        public Service(Repository repository)
        {
            repository.ThrowIfNull();
            _repository = repository;
        }

        public decimal GetPrice(string name, int quantity)
        {
            name.ThrowIfNull().IfEmpty().IfWhiteSpace();
            quantity.Throw().IfNegativeOrZero();
            var product = _repository.GetProductByName(name);
            return GetPrice(product, quantity);
        }

        public decimal GetPrice(Product product, int quantity)
        {
            product.ThrowIfNull();
            quantity.Throw().IfNegativeOrZero();
            return product.Price * quantity;
        }
    }
}
