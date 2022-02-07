using System.Threading.Tasks;
using Bank.Data.Entities;

namespace Bank.API.Controllers.Manager
{
  public interface IManagerRepository
  {
    // This interface will help me plan the ManagerRepository before implementing it.
    
    Task<Data.Entities.Customer[]> GetAllCustomersAsync();
    
    
  }
}