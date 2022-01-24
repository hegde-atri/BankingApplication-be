using System.ComponentModel.DataAnnotations;

namespace Bank.Data.Entities
{
  public class Payee
  {
    //Attributes of the Payee Table
    //defaults to required since it is a primary key
    public int PayeeId { get; set; }
    //Each account belongs to a single customer. [CustomerId is a foreign key]
    //defaults to required since it is a foreign key.
    public int CustomerId { get; set; }
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    [Required]
    [MaxLength(16)]
    public string AccountNumber { get; set; }
    [Required]
    [MaxLength(250)]
    public string Description { get; set; }
    //Not required right now since this is a future-proofing field.
    [MaxLength(6)]
    public string Sortcode { get; set; }
    
  }
}