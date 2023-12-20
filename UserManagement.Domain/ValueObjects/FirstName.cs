using Common;
using Common.Domain;
using FluentResults;

namespace UserManagement.Domain.ValueObjects;

public class FirstName : ValueObject
{
    public string Value { get; }
    
    private FirstName(string value)
    {
        Value = value;
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    
    public const int MinLength = 1;
    public const int MaxLength = 64;

    public static Result<FirstName> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return Common.Errors.Global.IsRequiredError();
        }

        var firstName = value.Trim();
        
        if (firstName.Length < MinLength)
        {
            return Common.Errors.Global.MinLengthError(MinLength);
        }
        
        if (firstName.Length > MaxLength)
        {
            return Common.Errors.Global.MaxLengthError(MaxLength);
        }
        
        return new FirstName(firstName);
    }
}