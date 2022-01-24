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
    public string AccountNumber1{ get; set; }
    public string Description1 { get; set; }
    public DateTime TransDateTime1 { get; set; }
    public string Type1 { get; set; }
    public string CreatedBy1 { get; set; }
    // The 2 commented parameters will be set by the API.
    
    // public DateTime CreatedDate1 { get; set; }
    
    public string AccountNumber2 { get; set; }
    public string Description2 { get; set; }
    public DateTime TransDateTime2 { get; set; }
    public string Type2 { get; set; }
    public string CreatedBy2 { get; set; }
    // public DateTime CreatedDate2 { get; set; }
    
    

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Amount { get; set; }
  }
}