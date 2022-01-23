using MediatR;
using Twitter.Clone.Handlers.DTOs;

namespace Twitter.Clone.Handlers.Account.Commands.Register;
public record CreateUserDto(string Email, string Password, string FullName, string UserName);
public class CreateNewUserCommand : IRequest<UserDto>
{
    public CreateNewUserCommand(CreateUserDto createUserDto)
    {
        Email = createUserDto.Email;
        Password = createUserDto.Password;
        FullName = createUserDto.FullName;
        Username = createUserDto.UserName;
    }

    public string Email { get; set; }
    public string Password { get; set; }
    public string FullName { get; set; }
    public string Username { get; set; }
}