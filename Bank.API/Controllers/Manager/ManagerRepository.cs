using System.Linq;
using Bank.Data;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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

    public async Task<Data.Entities.Customer[]> GetAllCustomersAsync()
    {
      _logger.LogInformation($"Getting all customers");
      IQueryable<Data.Entities.Customer> query = _context.Customers
        .OrderBy(c => c.ModifiedDate);
      
      return await query.ToArrayAsync();
    }
  }
}