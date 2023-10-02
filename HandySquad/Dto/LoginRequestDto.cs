using System.ComponentModel.DataAnnotations;

namespace HandySquad.dto;

public class LoginRequestDto
{
    [Required]
    [EmailAddress]
    public string EmailAddress { get; set; }
    [Required]
    public string Password { get; set; }
}