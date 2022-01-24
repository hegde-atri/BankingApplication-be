using System.Dynamic;

namespace Bank.API.Controllers.Customer
{
  public class CustomerRequest
  {
    public int CustomerId { get; set; }
    public int[] AccountId { get; set; }
    public int[] AddressId { get; set; }
    public int[] NotificationId { get; set; }
    public int[] PayeeId { get; set; }
    public int[] TransactionId { get; set;}
    
    
  }
}