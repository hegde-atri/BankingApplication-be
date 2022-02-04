using System.Linq;
using System.Threading.Tasks;
using Bank.Data;
using Bank.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Bank.API.Controllers.Officer
{
  public class OfficerRepository:IOfficerRepository
  {
    private readonly BankContext _context;
    private readonly ILogger<OfficerRepository> _logger;

    public OfficerRepository(BankContext context, ILogger<OfficerRepository> logger)
    {
        _context = context;
        _logger = logger;
    }
    
    public void Add<T>(T entity) where T : class
    {
      _logger.LogInformation($"Adding an object of type {entity.GetType()} to the context.");
      _context.Add(entity);
    }

    public void Delete<T>(T entity) where T : class
    {
      _logger.LogInformation($"Removing an object of type {entity.GetType()} from the context");
      _context.Remove(entity);
    }

    public void Update<T>(T entity) where T : class
    {
      _logger.LogInformation($"Updating an object of type {entity.GetType()} to the context");
      _context.Update(entity);
    }

    public async Task<bool> SaveChangesAsync()
    {
      _logger.LogInformation("Attempting to save changes in the context");
      // The following return statement will return true only if at least a row of data was changed.
      return await _context.SaveChangesAsync() > 0;
    }

    public async Task<Data.Entities.Customer> GetCustomerAsync(int customerId)
    {
      _logger.LogInformation($"Getting customer with customer id {customerId}");
      IQueryable<Data.Entities.Customer> query = _context.Customers
        .Where(a => a.CustomerId == customerId);
      return await query.FirstOrDefaultAsync();
    }

    // When building a more complex application we might need this verification but since the
    // user email stored in azure b2c is unique, we can just find customer using their email.
    
    // public async Task<Data.Entities.Customer> GetCustomerByDetailsAsync(CustomerVerificationModel model)
    // {
    //   _logger.LogInformation($"Getting customer with a model");
    //   IQueryable<Data.Entities.Customer> query = _context.Customers
    //     .Where(c => c.Firstname == model.firstname &&
    //                         c.Lastname == model.lastname &&
    //                         c.Email == model.email);
    //   return await query.FirstOrDefaultAsync();
    // }
    
    public async Task<Data.Entities.Customer> GetCustomerByEmailAsync(string email)
    {
      _logger.LogInformation($"Getting customer with email {email}");
      IQueryable<Data.Entities.Customer> query = _context.Customers
        .Where(c  => c.Email == email);
      return await query.FirstOrDefaultAsync();
    }
    

    public async Task<Notification[]> GetAllNotificationsAsync(int customerId)
    {
      _logger.LogInformation($"Getting notification details of customer {customerId}.");

      IQueryable<Notification> query = _context.Notifications
        .Where(n => n.CustomerId == customerId);

      return await query.ToArrayAsync();
    }
    
    public async Task<Notification> GetNotificationAsync(int notificationId)
    {
      _logger.LogInformation($"Getting notification with id {notificationId}.");

      IQueryable<Notification> query = _context.Notifications
        .Where(n => n.NotificationId == notificationId);

      return await query.FirstOrDefaultAsync();
    }

    public async Task<Address[]> GetAllAddressesAsync(int customerId)
    {
      _logger.LogInformation($"Getting all address details of customer {customerId}.");
      IQueryable<Address> query = _context.Addresses
        .Where(a => a.CustomerId == customerId);
      
      return await query.ToArrayAsync();
    }
    
    public async Task<Address> GetAddressAsync(int addressId)
    {
      _logger.LogInformation($"Getting address with id {addressId}.");

      IQueryable<Address> query = _context.Addresses
        .Where(a => a.AddressId == addressId);

      return await query.FirstOrDefaultAsync();
    }

    public async Task<Account[]> GetAllAccountsAsync()
    {
      _logger.LogInformation("Getting all Accounts for officer");
      IQueryable<Account> query = _context.Accounts;

      return await query.ToArrayAsync();
    }

    public async Task<Account> GetAccountAsync(string accountNo)
    {
      _logger.LogInformation($"Getting account with account no. {accountNo}");
      IQueryable<Account> query = _context.Accounts
        .Where(a => a.AccountNumber == accountNo);
      return await query.FirstOrDefaultAsync();
    }

    public async Task<Transaction[]> GetAllTransactionsAsync()
    {
      _logger.LogInformation("Getting all transactions");
      IQueryable<Transaction> query = _context.Transactions
        .OrderBy(t => t.TransDateTime);

      return await query.ToArrayAsync();
    }
  }
}