using _66BitTestovoe.Server.Enums;

namespace _66BitTestovoe.Server.Dal.Models;

public class PlayerOutput
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Gender Gender { get; set; }
    public string Country { get; set; }
    public DateTime BirthDate { get; set; }
    public string TeamName { get; set; }
    public Guid PlayerId { get; set; }
}