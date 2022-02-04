using System;
using System.ComponentModel.DataAnnotations;

namespace Bank.Data.Entities
{
  public class Address
  {
    public int AddressId { get; set; }
    public int CustomerId { get; set; }
    [MaxLength(50)]
    public string Line1 { get; set; }
    [MaxLength(50)]
    public string Line2 { get; set; }
    [MaxLength(25)]
    public string City { get; set; }
    [MaxLength(25)]
    public string State { get; set; }
    [MaxLength(25)]
    public string Country { get; set; }
    [MaxLength(10)]
    public string Postcode { get; set; }
    /* The customer Id, and the type of address (either primary or secondary)
      will be used for api calls. */
    [MaxLength(15)]
    public string Type { get; set; }
    [MaxLength(15)]
    public string Status { get; set; }
    [MaxLength(50)]
    public string CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    [MaxLength(50)]
    public string ModifiedBy { get; set; }
    public DateTime ModifiedDate { get; set; }
  }
}
