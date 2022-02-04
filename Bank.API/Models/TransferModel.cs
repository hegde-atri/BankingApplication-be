using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank.API.Models
{
  public class TransferModel
  /*
   * This is a data model that will serve as an intermediate class to store information
   * retrieved from the front end
   */
  {
    [Required]
    public string AccountNumber1{ get; set; }
    [Required]
    public string Type1 { get; set; }
    [Required]
    public string AccountNumber2 { get; set; }
    [Required]
    public string Type2 { get; set; }
    [Required]
    public string CreatedBy { get; set; }
    [Required]
    public DateTime CreatedDate { get; set; }
    [Required]
    public string Description { get; set; }
    
    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Amount { get; set; }
  }
}