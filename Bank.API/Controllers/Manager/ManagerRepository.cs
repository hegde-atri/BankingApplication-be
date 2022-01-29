using Bank.Data;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Bank.API.Controllers.Manager
{
  public class ManagerRepository:IManagerRepository
  {
    private readonly BankContext _context;
    private readonly ILogger<ManagerRepository> _logger;

    public ManagerRepository(BankContext context, ILogger<ManagerRepository> logger)
    {
        _context = context;
        _logger = logger;
    }
        public void Add<T>(T entity) where T : class
    {
      // in dev branch
      throw new System.NotImplementedException();
    }

    public async Task<bool> SaveChangesAsync()
    {
      throw new System.NotImplementedException();
    }

    public async Task<Data.Entities.Customer> GetCustomerAsync(int customerId)
    {
      throw new System.NotImplementedException();
    }

    public async Task<Data.Entities.Customer[]> GetAllCustomersAsync()
    {
      throw new System.NotImplementedException();
    }
  }
}