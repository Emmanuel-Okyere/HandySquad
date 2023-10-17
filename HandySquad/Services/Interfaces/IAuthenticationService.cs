using System.Net.Http.Headers;
using HandySquad.dto;
using HandySquad.Models;

namespace HandySquad.Services.Interfaces;

public interface IAuthenticationService
{
    Task<UserResponseDto> Register(RegisterRequestDto registerRequestDto);
    Task<UserResponseDto> Login(LoginRequestDto loginRequestDto);
    bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
    void CreatePasswordHashAndSalt(string password, out byte[] passwordHash, out byte[] passwordSalt);
    Task<User?> GetUserFromHeader(string authorizationHeader);
}
