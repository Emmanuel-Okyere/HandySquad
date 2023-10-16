using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandySquad.Models.ProfileModels;

public class ProfileImage
{
    [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string FileName { get; set; }
    public byte[] ImageData { get; set; } //contains the actual image ocntent in binary frmat
    // Foreign key for the one-to-one relationship
    public int ProfileId { get; set; }
    // Navigation property to the related Profile
    public Profile Profile { get; set; }
}