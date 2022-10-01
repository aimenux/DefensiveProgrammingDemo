using Throw;

namespace ThrowCoreApp.Models
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product(string name, decimal price)
        {
            name.ThrowIfNull().IfEmpty().IfWhiteSpace();
            price.Throw().IfNegativeOrZero();
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return $"[{Name},{Price}$]";
        }
    }
}
