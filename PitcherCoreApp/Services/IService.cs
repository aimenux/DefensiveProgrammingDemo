using PitcherCoreApp.Models;

namespace PitcherCoreApp.Services
{
    public interface IService
    {
        decimal GetPrice(string name, int quantity);
        decimal GetPrice(Product product, int quantity);
    }
}