using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bank.Data.Entities
{
  public class Customer
  {
    // These are the attributes each customer should have
    public int CustomerId { get; set; }
    [MaxLength(25)]
    public string Firstname { get; set; }
    [MaxLength(25)]
    public string Lastname { get; set; }
    [MaxLength(50)]
    public string Email { get; set; }
    [MaxLength(25)]
    public string Gender { get; set; }
    public DateTime DoB { get; set; }
    [MaxLength(15)]
    public string Status { get; set; }
    public DateTime CreatedDate { get; set; }
    [MaxLength(25)]
    public string CreatedBy { get; set; }
    public DateTime ModifiedDate { get; set; }
    [MaxLength(25)]
    public string ModifiedBy { get; set; }
    public int Budget { get; set; }
    
    //These define the Customer's relation with other Tables.
    public ICollection<Account> Accounts { get; set; }
    public ICollection<Payee> Payees { get; set; }
    public ICollection<Address> Addresses { get; set; }
    public ICollection<Notification> Notifications { get; set; }
    
  }
}