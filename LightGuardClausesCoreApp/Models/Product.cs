using Light.GuardClauses;

namespace LightGuardClausesCoreApp.Models
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product(string name, decimal price)
        {
            Name = name.MustNotBeNullOrWhiteSpace(nameof(name));
            Price = price.MustBeGreaterThan(0, nameof(price));
        }
    }
}
