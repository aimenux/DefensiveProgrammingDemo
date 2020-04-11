using System.Diagnostics.Contracts;
using CodeContractsFullApp.Models;
using CodeContractsFullApp.Repositories;

namespace CodeContractsFullApp.Services
{
    public class Service : IService
    {
        private readonly Repository _repository;

        public Service(Repository repository)
        {
            _repository = repository;
            Contract.Ensures(_repository != null);
        }

        public decimal GetPrice(string name, int quantity)
        {
            var product = _repository.GetProductByName(name);
            return GetPrice(product, quantity);
        }

        public decimal GetPrice(Product product, int quantity)
        {
            return product.Price * quantity;
        }
    }
}
