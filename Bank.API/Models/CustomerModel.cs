using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Bank.Data.Entities;

namespace Bank.API.Models
{
  public class CustomerModel
  {
    /* Adding attributes, helps any man in the middle alteration of data, so that
       input is not only validated at the front end, but the back end as well */
    [Required]
    public int CustomerId { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Firstname { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Lastname { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Gender { get; set; }
    
    [Required]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString="{0:dd-MM-yyyy")]
    public DateTime DoB { get; set; }
    
    [Required]
    [MaxLength(10)]
    public string Status { get; set; }
    
    [Required]
    public DateTime CreatedDate { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string CreatedBy { get; set; }
    
    [Required]
    public DateTime ModifiedDate { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string ModifiedBy { get; set; }

    [Required]
    public int Budget { get; set; }
  }
}