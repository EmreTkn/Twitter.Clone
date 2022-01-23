using Twitter.Clone.Models.Concrete;

namespace Twitter.Clone.Handlers.Services.Interfaces;
public interface ITokenService
{
    (string, string) CreateToken(IdentityUser user);
    string CreateGuestToken(string name);
}