using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Bank.Data.Entities;

namespace Bank.API.Models
{
  public class AccountModel
  {
    //These are the attributes of the Account entity.
    [Required]
    public int AccountId { get; set; }
    
    [Required]
    public int CustomerId { get; set; }
    
    // This will be my surrogate key
    [Required]
    public string AccountNumber { get; set; }

    // [StringLength(MaximumLength = 6, MinimumLength = 6)]
    // Sort code regular expression in XX-XX-XX where X is an integer
    // [RegularExpression(@"^(\d){2}-(\d){2}-(\d){2}$")]
    public string Sortcode { get; set; }
    
    [Required]
    public string Type { get; set; }
    
    [Required]
    public decimal Balance { get; set; }
    
    [Required]
    public string Status { get; set; }
    
    [Required]
    public DateTime OpenDate { get; set; }

    public DateTime CloseDate { get; set; }
    
    [Required]
    public string CreatedBy { get; set; }
    
    [Required]
    public DateTime CreatedDate { get; set; }
    
    [Required]
    public string ModifiedBy { get; set; }
    
    [Required]
    public DateTime ModifiedDate { get; set; }
    
    
    /*  These are the relationships that the Account table has other than the customer
        Each Account can have many transactions  */
    public ICollection<Transaction> Transactions { get; set; }
  }
}