using System;
using System.ComponentModel.DataAnnotations;

namespace Bank.API.Models
{
  public class NotificationModel
  {
    [Required]
    public int NotificationId { get; set; }
    
    [Required]
    public int CustomerId { get; set; }
    
    
    public string Email { get; set; }
    
    [Required]
    public string Phone { get; set; }
    
    [Required]
    public string Preference { get; set; }
    
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