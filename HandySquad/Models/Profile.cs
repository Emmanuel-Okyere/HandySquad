using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace HandySquad.Models;

public class Profile
{
    public int Id { get; set; }
    [Key]
    public int UserId { get; set; }
    [Required]
    public string FullName { get; set; }
    [Required]
    public string Occupation { get; set; }
    [Required]
    public string  SkillSet {get;set;}
    [Required]
    public string Location { get; set; }
    [Required]
    public int Ratings { get; set; }
    [Required]
    public int NumberOfRatings { get; set; }
    [JsonIgnore]
    public DateTime CreatedAt { get; set; }= DateTime.UtcNow;
    [JsonIgnore]
    public DateTime UpdatedAt { get; set; }
    [JsonIgnore]
    public User user { get; set; }
}