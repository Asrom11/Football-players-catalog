using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using _66BitTestovoe.Server.Enums;

namespace _66BitTestovoe.Server.Dal.Models;

[Table("team")]
public class TeamDal: BaseEntity
{
    public string TeamName { get; set; }
    
    [JsonIgnore]
    public List<PlayerDal> Players { get; set; }
}