using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank.Data.Entities
{
  public class Account
  {
    //These are the attributes of the Account Table.
    public int AccountId { get; set; }
    //Each account belongs to a single customer. [CustomerId is a foreign key]
    public int CustomerId { get; set; }
    [MaxLength(16)]
    public string AccountNumber { get; set; }
    [MaxLength(6)]
    public string Sortcode { get; set; }
    [MaxLength(25)]
    public string Type { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal Balance { get; set; }
    [MaxLength(25)]
    public string Status { get; set; }
    public DateTime OpenDate { get; set; }
    public DateTime CloseDate { get; set; }
    [MaxLength(25)]
    public string CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    [MaxLength(25)]
    public string ModifiedBy { get; set; }
    public DateTime ModifiedDate { get; set; }
    
    /*  These are the relationships that the Account table has other than the customer
        Each Account can have many transactions  */
    public ICollection<Transaction> Transactions { get; set; }
  }
}
