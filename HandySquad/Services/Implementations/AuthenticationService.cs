using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HandySquad.dto;
using HandySquad.Exceptions;
using HandySquad.Models;
using HandySquad.Repositories.Interfaces;
using HandySquad.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace HandySquad.Services.Implementations;

public class AuthenticationService: IAuthenticationService, IJwtService
{
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _configuration;
    private readonly ILogger<AuthenticationService> _logger;

    public AuthenticationService(IUserRepository userRepository, IConfiguration configuration, ILogger<AuthenticationService> logger)
    {
        _userRepository = userRepository;
        _configuration = configuration;
        _logger = logger;
    }

    public async Task<UserResponseDto> Register(RegisterRequestDto registerRequestDto)
    {
        _logger.LogInformation("Registration for {} initiated",registerRequestDto.EmailAddress);
        if (await _userRepository.GetUserByEmailAddress(registerRequestDto.EmailAddress) != null)
        {
            _logger.LogInformation("Registration for {} failure, user already exist",registerRequestDto.EmailAddress);
            throw new Duplicate409Exception("user already exist");
        }

        CreatePasswordHashAndSalt(registerRequestDto.Password, out var passwordHash,out var passwordSalt);
        var newUser = new User
        {
            EmailAddress = registerRequestDto.EmailAddress,
            TelephoneNumber = registerRequestDto.TelephoneNumber,
            AccountType = registerRequestDto.AccountType,
            Username = registerRequestDto.Username,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt
        };
       var addedUser = await _userRepository.AddUser(newUser);
       var token = CreateToken(registerRequestDto.EmailAddress);
       _logger.LogInformation("Registration for {} completed",registerRequestDto.EmailAddress);
       return new UserResponseDto
       {
           Status = "success",
           Message = "user registration success",
           Data = addedUser,
           Token = token
       };
    }

    public async Task<UserResponseDto> Login(LoginRequestDto loginRequestDto)
    {
        _logger.LogInformation("login in for {} initiated",loginRequestDto.EmailAddress);
        var createdUser = await _userRepository.GetUserByEmailAddress(loginRequestDto.EmailAddress);
        if (createdUser == null)
        {
            _logger.LogInformation("Login in for {} failure, email does not exist",loginRequestDto.EmailAddress);
            throw new NotFound404Exception("user email does not exist");
        }
        if (!VerifyPasswordHash(loginRequestDto.Password, createdUser.PasswordHash, createdUser.PasswordSalt))
        {
            _logger.LogInformation("Login in for {} failure, password incorrect",loginRequestDto.EmailAddress);
            throw new BadRequest400Exception("password incorrect");
        }

        var token = CreateToken(loginRequestDto.EmailAddress);
        _logger.LogInformation("Login in  for {} completed",loginRequestDto.EmailAddress);
        return new UserResponseDto
        {
            Message = "login success",
            Status = "success",
            Data = createdUser,
            Token = token
        };
    }

    public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        _logger.LogInformation("Verifying password hash");
        using var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt);
        var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        for (var i = 0; i < computedHash.Length; i++)
        {
            if (computedHash[i] != passwordHash[i])
            {
                return false;
            }
        }
        _logger.LogInformation("password hash verified");
        return true;
    }

    public void CreatePasswordHashAndSalt(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        _logger.LogInformation("creating password hash and salt");
        using var hmac = new System.Security.Cryptography.HMACSHA512();
        passwordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        _logger.LogInformation("creating password hash and salt completed");
    }

    public string CreateToken(string emailAddress)
    {
        _logger.LogInformation("creating JWT token");
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email,emailAddress)
        };
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_configuration.GetSection("JWT:Key").Value!));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(1),
            SigningCredentials = credentials,
            Audience = _configuration.GetSection("JWT:Audience").Value!,
            Issuer = _configuration.GetSection("JWT:Issuer").Value!,
            IssuedAt = DateTime.UtcNow,
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        _logger.LogInformation("writing JWT Token completed");
        return tokenHandler.WriteToken(token);
    }
}