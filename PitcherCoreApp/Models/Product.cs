using Pitcher;

namespace PitcherCoreApp.Models
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product(string name, decimal price)
        {
            Throw.ArgumentNull.WhenNullOrWhiteSpace(name, nameof(name));
            Throw.ArgumentOutOfRange.When(price <= 0, nameof(price));
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return $"[{Name},{Price}$]";
        }
    }
}
