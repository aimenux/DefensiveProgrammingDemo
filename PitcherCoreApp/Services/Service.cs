using Pitcher;
using PitcherCoreApp.Models;
using PitcherCoreApp.Repositories;

namespace PitcherCoreApp.Services
{
    public class Service : IService
    {
        private readonly Repository _repository;

        public Service(Repository repository)
        {
            Throw.ArgumentNull.WhenNull(repository, nameof(repository));
            _repository = repository;
        }

        public decimal GetPrice(string name, int quantity)
        {
            Throw.ArgumentNull.WhenNullOrWhiteSpace(name, nameof(name));
            Throw.ArgumentOutOfRange.When(quantity <= 0, nameof(quantity));
            var product = _repository.GetProductByName(name);
            return GetPrice(product, quantity);
        }

        public decimal GetPrice(Product product, int quantity)
        {
            Throw.ArgumentNull.WhenNull(product, nameof(product));
            Throw.ArgumentOutOfRange.When(quantity <= 0, nameof(quantity));
            return product.Price * quantity;
        }
    }
}
