namespace HandySquad.Services.Interfaces;

public interface IJwtService
{
    string CreateToken(string emailAddress);
}