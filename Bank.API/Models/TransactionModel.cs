using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank.API.Models
{
  public class TransactionModel
  {
    public int TransactionId { get; set; }
    [Required]
    public int AccountId { get; set; }
    [Required]
    public string AccountNumber { get; set; }
    [Required]
    public string Type { get; set; }
    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Amount{ get; set; }
    public string Description { get; set; }
    public DateTime TransDateTime { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
  }
}