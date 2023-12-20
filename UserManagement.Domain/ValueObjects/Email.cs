using System.Text.RegularExpressions;
using Common.Domain;
using FluentResults;

namespace UserManagement.Domain.ValueObjects;

public class Email : ValueObject
{
    public string Value { get; }

    protected Email(string value)
    {
        Value = value;
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    
    public const int MaxLength = 320;

    public static Result<Email> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return Common.Errors.Global.IsRequiredError();
        }

        var email = value.Trim();
        
        if (email.Length > MaxLength)
        {
            return Common.Errors.Global.MaxLengthError(MaxLength);
        }

        if (!Regex.IsMatch(email, @"^(.+)@(.+)$"))
        {
            return Common.Errors.Global.IsNotValidError();
        }
        
        return new Email(email);
    }
}