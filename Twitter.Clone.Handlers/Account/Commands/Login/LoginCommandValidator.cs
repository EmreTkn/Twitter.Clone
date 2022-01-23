using FluentValidation;
using Twitter.Clone.Data.Abstract;

namespace Twitter.Clone.Handlers.Account.Commands.Login;
public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator(IIdentityRepository identityRepository)
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
        RuleFor(x => x)
            .MustAsync(async (root, command, context, cancellationToken) =>
            {
                var user = await identityRepository.GetAsync(x => x.Email == command.Email && x.Password == command.Password);
                if (user == null) return false;
                return true;
            }).WithMessage("Incorrect username or password.");
    }
}
