namespace HandySquad.dto.Profile;

public class CreateProfileDto
{
    public string FullName { get; set; }
  
    public string  Occupation {get;set;}
        
    public List<Models.SkillSet> SkillSets {get;set;}
      
    public string Location { get; set; }
        
    public int Ratings { get; set; }
        
    public int NumberOfRatings { get; set; }
}