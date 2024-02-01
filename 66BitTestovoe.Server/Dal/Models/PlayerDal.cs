using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using _66BitTestovoe.Server.Enums;
using _66BitTestovoe.Server.Models;

namespace _66BitTestovoe.Server.Dal.Models;

[Table("player")]
public class PlayerDal: BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Gender Gender { get; set; }
    public string Country { get; set; }
    public DateTime BirthDate { get; set; }
    public Guid TeamID { get; set; }
    public TeamDal Team { get; set; }
    
}