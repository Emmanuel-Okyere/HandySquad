using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace HandySquad.Models.ProfileModels;
public class Profile
{
    [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string? FullName { get; set; }
    public string? Occupation { get; set; }
    public List<Skill> SkillSets {get;set;}
    public string? Location { get; set; }
    public int Ratings { get; set; }
    public int NumberOfRatings { get; set; }
    [JsonIgnore]
    public DateTime CreatedAt { get; set; }= DateTime.UtcNow;
    [JsonIgnore]
    public DateTime UpdatedAt { get; set; }
    [JsonIgnore]
    [Required]
    public User User { get; set; }
    public ProfileImage? ProfileImage { get; set; }
}