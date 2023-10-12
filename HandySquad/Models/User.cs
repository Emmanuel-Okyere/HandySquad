using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HandySquad.Enum;
using HandySquad.Models.ProfileModels;
using Newtonsoft.Json;

namespace HandySquad.Models;
[Table(name:"users")]
public class User
{
    [Required] [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public string Username { get; set; }
    [Required]
    public string EmailAddress { get; set; }
    [Required]
    public string TelephoneNumber { get; set; }
    [Required]
    public AccountType AccountType { get; set; }
    [JsonIgnore]
    public byte[] PasswordSalt { get; set; }
    [JsonIgnore]
    public byte[] PasswordHash { get; set; }
    [JsonIgnore]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    [JsonIgnore]
    public DateTime? UpdatedAt { get; set; } = null;
    
    public int ProfileId { get; set; }
    public Profile Profile { get; set; }
}