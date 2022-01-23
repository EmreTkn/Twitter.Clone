using FluentValidation;
using Twitter.Clone.Data.Abstract;

namespace Twitter.Clone.Handlers.Account.Commands.RefreshToken;
public class RefreshTokenCommandValidator : AbstractValidator<RefreshTokenCommand>
{
    public RefreshTokenCommandValidator(IIdentityRepository identityRepository)
    {
        RuleFor(x => x.RefreshToken).NotEmpty().WithMessage("RefreshToken is required");
        RuleFor(x => x)
            .MustAsync(async (root, command, context, cancellationToken) =>
            {
                var user = await identityRepository
                .GetAsync(x => x.RefreshToken == command.RefreshToken && x.RefreshTokenExpiration > DateTime.Now);
                if (user == null) return false;
                return true;
            }).WithMessage("Invalid refresh token.");
    }
}