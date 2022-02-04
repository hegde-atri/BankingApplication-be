using System;
using System.ComponentModel.DataAnnotations;

namespace Bank.Data.Entities
{
  public class Notification
  {
    public int NotificationId { get; set; }
    public int CustomerId { get; set; }
    [MaxLength(50)]
    public string Email { get; set; }
    [MaxLength(15)]
    public string Phone { get; set; }
    // Preference is whether they want the notification to email, phone or both.
    [MaxLength(15)]
    public string Preference { get; set; }
    
    // Type indicates whether the notificationId set for the customer
    // is primary,secondary or tertiary.
    [MaxLength(15)]
    public string Type { get; set; }
    // This is for whether they want updates sent to this notification.
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