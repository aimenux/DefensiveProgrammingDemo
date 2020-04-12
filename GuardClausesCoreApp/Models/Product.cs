using Ardalis.GuardClauses;

namespace GuardClausesCoreApp.Models
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product(string name, decimal price)
        {
            Guard.Against.NullOrWhiteSpace(name, nameof(name));
            Guard.Against.NegativeOrZero(price, nameof(price));
            Name = name;
            Price = price;
        }
    }
}
