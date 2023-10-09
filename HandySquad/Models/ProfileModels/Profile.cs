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
    public List<SkillSet> SkillSets {get;set;}/// <summary>
                                              /// Naviagation containign dependeant(child)
                                              /// </summary>
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
    public User User { get; set; }
  
   // public List<Occupation> Occupations { get; set; }
   // Navigation property to the related ProfileImage
   public ProfileImage ProfileImage { get; set; }
}