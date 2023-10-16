using System.ComponentModel.DataAnnotations;

using HandySquad.dto.Profile.SkillSet;
using HandySquad.Models;

namespace HandySquad.dto.Profile;

public class ProfileDto
{
    public int Id { get; set; }
    
        public int UserId { get; set; }
       
        public string FullName { get; set; }
  
        public string  Occupation {get;set;}
        
        public List<Models.Skill> SkillSets {get;set;}
      
        public string Location { get; set; }
        
        public int Ratings { get; set; }
        
        public int NumberOfRatings { get; set; }
       
        //public User user { get; set; }
        public ProfileImageDto ProfileImage { get; set; }
    
}