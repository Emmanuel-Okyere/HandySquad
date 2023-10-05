namespace HandySquad.dto.Profile;

public class UpdateProfileDto
{
    public int UserId { get; set; }
    public string Occupation { get; set; }
    public string SkillSet { get; set; }
    public string Location { get; set; }
    public string FullName { get; set; }
    public int Ratings { get; set; }
    public int NumberOfRatings { get; set; }
}