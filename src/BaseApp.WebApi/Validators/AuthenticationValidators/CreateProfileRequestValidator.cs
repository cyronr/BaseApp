using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using System.Text.RegularExpressions;
using BaseApp.WebAPI.Requests.AuthenticationRequests;
using BaseApp.WebAPI.Validators.Utils;

namespace BaseApp.WebAPI.Validators.AuthenticationValidators;

public class CreateProfileRequestValidator<T> : AbstractValidator<T> where T : CreateProfileRequest
{
    public CreateProfileRequestValidator()
    {
        RuleFor(obj => obj.Email)
            .NotEmpty()
            .WithMessage(ValidationMessages.PropertyMustHaveValue)
            .NotEqual(ValidationValues.DefaultString)
            .WithMessage(ValidationMessages.PropertyMustHaveValue)
            .EmailAddress()
            .WithMessage("{PropertyName} is not valid email");

        RuleFor(obj => obj.Password)
            .NotEmpty()
            .WithMessage(ValidationMessages.PropertyMustHaveValue)
            .NotEqual(ValidationValues.DefaultString)
            .WithMessage(ValidationMessages.PropertyMustHaveValue);

        When(obj => !obj.PhoneNumber.IsNullOrEmpty(), () =>
        {
            RuleFor(obj => obj.PhoneNumber)
                .MinimumLength(9)
                .WithMessage("{PropertyName} must have at least 9 digits.")
                .Must(IsPhoneNumberValid)
                .WithMessage("{PropertyName} is not valid phone number.");

        });
    }

    private bool IsPhoneNumberValid(string phoneNumber)
    {
        if (phoneNumber is null || phoneNumber.Equals(string.Empty))
            return false;

        Regex phoneNumberRules = new Regex("[0-9]$");
        if (phoneNumberRules.IsMatch(phoneNumber))
            return true;

        return false;
    }
}
