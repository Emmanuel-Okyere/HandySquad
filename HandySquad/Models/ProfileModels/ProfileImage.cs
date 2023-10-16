using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandySquad.Models.ProfileModels;

public class ProfileImage
{
    [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string FileName { get; set; }
    public byte[] ImageData { get; set; }
    public Profile Profile { get; set; }
}