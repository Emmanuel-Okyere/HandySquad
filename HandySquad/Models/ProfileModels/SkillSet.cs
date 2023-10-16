using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HandySquad.Models.ProfileModels;

namespace HandySquad.Models;

public class SkillSet
{
    [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Skills { get; set; }
    public int ProfileId { get; set; }// foreign key property
   //The ProfileId will become the foreign key between the SkillSet and Profile table in the database
    public Profile Profile { get; set; } //reference navifation to principal(parent)
    //The ProfileId property is used to access the member of the Profile class
    
    
}