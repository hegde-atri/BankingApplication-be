using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace Bank.API.Models
{
  public class PayeeModel
  {
    public int PayeeId { get; set; }
    public int CustomerId { get; set; }
    
    [Required]
    public string Name { get; set; }
    [Required]
    public string AccountNumber { get; set; }

    public string Description { get; set; }
  }
}