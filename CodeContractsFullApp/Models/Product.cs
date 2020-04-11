using System.Diagnostics.Contracts;

namespace CodeContractsFullApp.Models
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        [ContractInvariantMethod]
        private void ProductInvariant()
        {
            Contract.Invariant(Price > 0);
            Contract.Invariant(!string.IsNullOrWhiteSpace(Name));
        }
    }
}
