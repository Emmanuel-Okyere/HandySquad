using HandySquad.Models;

namespace HandySquad.dto;

public class UserResponseDto: MessageResponseDto
{
    public string? Token { get; set; }
    public User Data { get; set; }
}