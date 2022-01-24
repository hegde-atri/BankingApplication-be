using System.Threading.Tasks;
using Bank.Data.Entities;

namespace Bank.API.Controllers.Manager
{
  public interface IManagerRepository
  {
    // This interface will help me plan the ManagerRepository before implementing it.
    // The manager is going to be a 'sudo' user so He will be having everything Officer has and some more.
    
    void Add<T>(T entity) where T : class;

    Task<bool> SaveChangesAsync();

    Task<Bank.Data.Entities.Customer> GetCustomerAsync(int customerId);
    Task<Data.Entities.Customer[]> GetAllCustomersAsync();
    
    
  }
}