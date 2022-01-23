using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Twitter.Clone.Handlers.Services.Interfaces;
using Twitter.Clone.Models.Abstract;
using Twitter.Clone.Models.Concrete;

namespace Twitter.Clone.Handlers.Services.Concrete;
public class TokenService : ITokenService
{
    private readonly IAppSettings _appSettings;
    private readonly SymmetricSecurityKey _key;
    public TokenService(IAppSettings appSettings)
    {
        _appSettings = appSettings;
        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.TokenSecretKey));
    }

    public string CreateGuestToken(string name)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, name),
            new Claim(ClaimTypes.Role, "Guest")
        };

        return CreateToken(claims);
    }

    public (string, string) CreateToken(IdentityUser user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, "User")
        };
        var accessToken = CreateToken(claims);
        var refreshToken = CreateRefreshToken();
        return (accessToken, refreshToken);
    }

    private string CreateToken(List<Claim> claims)
    {
        var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddMinutes(15),
            SigningCredentials = creds,
            Issuer = _appSettings.TokenIssuer
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
    public string CreateRefreshToken()
    {
        byte[] number = new byte[32];
        using (RandomNumberGenerator random = RandomNumberGenerator.Create())
        {
            random.GetBytes(number);
            return Convert.ToBase64String(number);
        }
    }
}