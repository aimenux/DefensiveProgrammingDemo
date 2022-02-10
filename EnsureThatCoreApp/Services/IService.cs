using EnsureThatCoreApp.Models;

namespace EnsureThatCoreApp.Services
{
    public interface IService
    {
        decimal GetPrice(string name, int quantity);
        decimal GetPrice(Product product, int quantity);
    }
}