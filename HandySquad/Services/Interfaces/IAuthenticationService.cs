using HandySquad.dto;

namespace HandySquad.Services.Interfaces;

public interface IAuthenticationService
{
    Task<UserResponseDto> Register(RegisterRequestDto registerRequestDto);
    Task<UserResponseDto> Login(LoginRequestDto loginRequestDto);
    bool VerifyPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
    void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
}
