using System.ComponentModel.DataAnnotations;
using HandySquad.Enum;

namespace HandySquad.dto;

public class RegisterRequestDto: LoginRequestDto
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string TelephoneNumber { get; set; }
    [Required]
    public AccountType AccountType { get; set; }
}