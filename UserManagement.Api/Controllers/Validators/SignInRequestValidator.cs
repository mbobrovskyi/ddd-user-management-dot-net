using Common.Api;
using FluentValidation;
using UserManagement.Controllers.DataContracts;
using UserManagement.Domain.ValueObjects;

namespace UserManagement.Controllers.Validators;

public class SignInRequestValidator : AbstractValidator<SignInRequest>
{
    public SignInRequestValidator()
    {
        RuleFor(x => x.Email).MustBeValueObject(x => Email.Create(x));
        RuleFor(x => x.Password).MustBeValueObject(x => HashPassword.Create(x));
    }
}