using Twitter.Clone.Models.Concrete;

namespace Twitter.Clone.Core.Interfaces;
public interface ITokenService
{
    (string, string) CreateToken(IdentityUser user);
    string CreateGuestToken(string name);
}