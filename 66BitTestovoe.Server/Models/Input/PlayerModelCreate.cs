using System.ComponentModel.DataAnnotations;
using _66BitTestovoe.Server.Attributes;
using _66BitTestovoe.Server.Enums;

namespace _66BitTestovoe.Server.Models;


public class PlayerModelCreate
{
    [Required]
    [MaxLength(30)]
    [MinLength(2)]
    public string FirstName { get; set; }
    
    [Required]
    [MaxLength(30)]
    [MinLength(2)]
    public string LastName { get; set; }
    
    [Required]
    public Gender Gender { get; set; }
    
    [Required]
    [PastDateTime]
    public DateTime BirthDate { get; set; }
    
    [Required]
    [MaxLength(40)]
    [MinLength(3)]
    public string TeamName { get; set; }
    
    [Required]
    [ValidCountryName]
    public string Country { get; set; }
}
