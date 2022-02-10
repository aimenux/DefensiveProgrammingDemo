using EnsureThat;

namespace EnsureThatCoreApp.Models
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product(string name, decimal price)
        {
            Ensure.That(name).IsNotEmptyOrWhiteSpace();
            Ensure.That(price).IsGt(0);
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return $"[{Name},{Price}$]";
        }
    }
}
