using Light.GuardClauses;
using LightGuardClausesCoreApp.Models;
using LightGuardClausesCoreApp.Repositories;

namespace LightGuardClausesCoreApp.Services
{
    public class Service : IService
    {
        private readonly Repository _repository;

        public Service(Repository repository)
        {
            _repository = repository.MustNotBeNull(nameof(repository));
        }

        public decimal GetPrice(string name, int quantity)
        {
            name.MustNotBeNullOrWhiteSpace(nameof(name));
            quantity.MustBeGreaterThan(0, nameof(quantity));
            var product = _repository.GetProductByName(name);
            return GetPrice(product, quantity);
        }

        public decimal GetPrice(Product product, int quantity)
        {
            product.MustNotBeNull(nameof(product));
            product.Price.MustBeGreaterThan(0, nameof(Product.Price));
            quantity.MustBeGreaterThan(0, nameof(quantity));
            return product.Price * quantity;
        }
    }
}
