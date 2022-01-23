using FluentValidation;
using Twitter.Clone.Data.Abstract;

namespace Twitter.Clone.Handlers.Account.Commands.Register;
public class CreateNewUserCommandValidator : AbstractValidator<CreateNewUserCommand>
{
    readonly IIdentityRepository _identityRepository;
    public CreateNewUserCommandValidator(IIdentityRepository identityRepository)
    {
        _identityRepository = identityRepository;

        RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required")
            .Matches(@"[0-9]+").WithMessage("Password should contain At least one numeric value")
            .Matches(@"[A-Z]+").WithMessage("Password should contain At least one upper case letter")
            .Matches(@".{8,}").WithMessage("Password should not be less than or greater than 8 characters");

        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("FullName is required.")
            .Matches(@"[A-Za-zÀ-ÖØ-öø-ÿ\s]").WithMessage("FullName cannot contain special characters.")
            .MaximumLength(60).WithMessage("FullName must not exceed 60 characters.");

        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Username is required.")
            .MaximumLength(30).WithMessage("Lastname must not exceed 30 characters.")
            .Matches(@"[\w]").WithMessage("Only letters, digits and underscores allowed.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .MustAsync(CheckEmail).WithMessage("Email already used.");
    }

    private async Task<bool> CheckEmail(string email, CancellationToken cancellationToken)
        => await _identityRepository.GetAsync(x => x.Email == email) == null;
}