using LightGuardClausesCoreApp.Models;

namespace LightGuardClausesCoreApp.Services
{
    public interface IService
    {
        decimal GetPrice(string name, int quantity);
        decimal GetPrice(Product product, int quantity);
    }
}