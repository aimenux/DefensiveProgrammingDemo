using Dawn;

namespace DawnGuardCoreApp.Models
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product(string name, decimal price)
        {
            Guard.Argument(name, nameof(name)).NotNull().NotEmpty().NotWhiteSpace();
            Guard.Argument(price, nameof(price)).GreaterThan(0);
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return $"[{Name},{Price}$]";
        }
    }
}
