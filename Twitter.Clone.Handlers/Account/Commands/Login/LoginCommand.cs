using MediatR;
using Twitter.Clone.Handlers.DTOs;

namespace Twitter.Clone.Handlers.Account.Commands.Login;
public class LoginCommand : IRequest<UserDto>
{
    public LoginCommand(LoginDto loginDto)
    {
        Email = loginDto.Email;
        Password = loginDto.Password;
    }

    public string Email { get; set; }
    public string Password { get; set; }
}