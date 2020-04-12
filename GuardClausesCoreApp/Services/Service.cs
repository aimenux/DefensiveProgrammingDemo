using Ardalis.GuardClauses;
using GuardClausesCoreApp.Models;
using GuardClausesCoreApp.Repositories;

namespace GuardClausesCoreApp.Services
{
    public class Service : IService
    {
        private readonly Repository _repository;

        public Service(Repository repository)
        {
            Guard.Against.Null(repository, nameof(repository));
            _repository = repository;
        }

        public decimal GetPrice(string name, int quantity)
        {
            Guard.Against.NullOrWhiteSpace(name, nameof(name));
            Guard.Against.NegativeOrZero(quantity, nameof(quantity));
            var product = _repository.GetProductByName(name);
            return GetPrice(product, quantity);
        }

        public decimal GetPrice(Product product, int quantity)
        {
            Guard.Against.Null(product, nameof(product));
            Guard.Against.NegativeOrZero(quantity, nameof(quantity));
            return product.Price * quantity;
        }
    }
}
