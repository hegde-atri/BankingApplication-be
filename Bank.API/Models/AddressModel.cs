using System;
using System.ComponentModel.DataAnnotations;

namespace Bank.API.Models
{
  public class AddressModel
  {
    public int AddressId { get; set; }
    
    public int CustomerId { get; set; }
    
    [Required]
    public string Line1 { get; set; }

    public string Line2 { get; set; }
    
    [Required]
    public string City { get; set; }
    [Required]
    public string State { get; set; }
    // You cannot create an account without living in the UK.
    [Required]
    public string Country { get; set; } = "United Kingdom";
    
    // Regular expression to make sure post code is valid.
    [Required]
    [RegularExpression(@"^([Gg][Ii][Rr] 0[Aa]{2})|((([A-Za-z][0-9]{1,2})|(([A-Za-z][A-Ha-hJ-Yj-y][0-9]{1,2})|(([A-Za-z][0-9][A-Za-z])|([A-Za-z][A-Ha-hJ-Yj-y][0-9][A-Za-z]?))))\s?[0-9][A-Za-z]{2})$")]
    public string Postcode { get; set; }
    [Required]
    public string Type { get; set; }
    [Required]
    public string Status { get; set; }
    [Required]
    public string CreatedBy { get; set; }
    [Required]
    public DateTime CreatedDate { get; set; }
    [Required]
    public string ModifiedBy { get; set; }
    [Required]
    public DateTime ModifiedDate { get; set; }
  }
}