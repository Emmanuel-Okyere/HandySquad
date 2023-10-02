using HandySquad.dto;
using HandySquad.Repositories.Interfaces;
using HandySquad.Services.Interfaces;

namespace HandySquad.Services.Implementations;

public class AuthenticationService: IAuthenticationService, IJwtService
{
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<UserResponseDto> Register(RegisterRequestDto registerRequestDto)
    {
        throw new NotImplementedException();
    }

    public async Task<UserResponseDto> Login(LoginRequestDto loginRequestDto)
    {
        throw new NotImplementedException();
    }

    public bool VerifyPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        throw new NotImplementedException();
    }

    public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        throw new NotImplementedException();
    }

    public string CreateToken(string emailAddress)
    {
        throw new NotImplementedException();
    }
}