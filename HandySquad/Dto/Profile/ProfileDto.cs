using System.ComponentModel.DataAnnotations;
using HandySquad.Models;

namespace HandySquad.dto.Profile;

public class ProfileDto
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
       
        public User user { get; set; }
    
}