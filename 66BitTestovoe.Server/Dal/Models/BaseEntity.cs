using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace _66BitTestovoe.Server.Dal.Models;

public class BaseEntity
{
    [Key]
    public Guid Id { get; set; }
}