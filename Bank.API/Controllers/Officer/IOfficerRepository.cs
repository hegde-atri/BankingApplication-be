using System.Threading.Tasks;
using Bank.Data.Entities;

namespace Bank.API.Controllers.Officer
{
  public interface IOfficerRepository
  {
        // This interface will help me plan the OfficerRepository before implementing it.
        //Should get the to approve changes and customer transactions
        
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();


        Task<Data.Entities.Customer> GetCustomerAsync(int CustomerId);
        // Task<Data.Entities.Customer> GetCustomerByDetailsAsync(CustomerVerificationModel model);

        Task<Data.Entities.Customer> GetCustomerByEmailAsync(string email);
        Task<Notification[]> GetAllNotificationsAsync(int customerId);
        Task<Notification> GetNotificationAsync(int notificationId);

        Task<Address[]> GetAllAddressesAsync(int customerId);

        
        
        Task<Account[]> GetAllAccountsAsync();
        Task<Transaction[]> GetAllTransactionsAsync();
  }
}