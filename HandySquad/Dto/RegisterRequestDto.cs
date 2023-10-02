using System.ComponentModel.DataAnnotations;
using HandySquad.Enum;

namespace HandySquad.dto;

public class RegisterRequestDto: LoginRequestDto
{
    [Required, MinLength(5)]
    public string Username { get; set; }
    [Required, Phone]
    public string TelephoneNumber { get; set; }
    [Required]
    public AccountType AccountType { get; set; }
}