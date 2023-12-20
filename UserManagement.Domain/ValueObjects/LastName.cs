using Common.Domain;
using FluentResults;

namespace UserManagement.Domain.ValueObjects;

public class LastName : ValueObject
{
    public string Value { get; }
    
    private LastName(string value)
    {
        Value = value;
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    
    public const int MinLength = 1;
    public const int MaxLength = 64;
    
    public static Result<LastName> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return Common.Errors.Global.IsRequiredError();
        }

        var lastName = value.Trim();
        
        if (lastName.Length < MinLength)
        {
            return Common.Errors.Global.MinLengthError(MinLength);
        }
        
        if (lastName.Length > MaxLength)
        {
            return Common.Errors.Global.MaxLengthError(MaxLength);
        }
        
        return new LastName(lastName);
    }
}