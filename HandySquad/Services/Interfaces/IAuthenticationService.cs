using HandySquad.dto;

namespace HandySquad.Services.Interfaces;

public interface IAuthenticationService
{
    Task<UserResponseDto> Register(RegisterRequestDto registerRequestDto);
    Task<UserResponseDto> Login(LoginRequestDto loginRequestDto);
    bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
    void CreatePasswordHashAndSalt(string password, out byte[] passwordHash, out byte[] passwordSalt);
}
