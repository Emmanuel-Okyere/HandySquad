namespace HandySquad.Models;

public class ProfileImage
{
    public int Id { get; set; }
    public string FileName { get; set; }
    public byte[] Data { get; set; } //contains the actual image ocntent in binary frmat
}