using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HandySquad.Models.ProfileModels;
using Newtonsoft.Json;

namespace HandySquad.Models;

public class Skill
{
    [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    [JsonIgnore]
    public List<Profile> Profiles { get; set; } 
}