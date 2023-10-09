namespace HandySquad.Models;

public class SkillSet
{
    public int Id { get; set; }
    public string Skills { get; set; }
    public int ProfileId { get; set; }
    public Profile Profile { get; set; }
}