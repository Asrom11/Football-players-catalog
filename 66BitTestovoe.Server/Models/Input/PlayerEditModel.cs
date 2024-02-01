using System.ComponentModel.DataAnnotations;

namespace _66BitTestovoe.Server.Models;

public class PlayerEditModel: PlayerModelCreate
{
    [Required]
    public Guid PlayerId { get; set; }
}