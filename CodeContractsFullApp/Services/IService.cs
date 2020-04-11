using System.Diagnostics.Contracts;
using CodeContractsFullApp.Contracts;
using CodeContractsFullApp.Models;

namespace CodeContractsFullApp.Services
{
    [ContractClass(typeof(AbstractServiceContracts))]
    public interface IService
    {
        decimal GetPrice(string name, int quantity);
        decimal GetPrice(Product product, int quantity);
    }
}