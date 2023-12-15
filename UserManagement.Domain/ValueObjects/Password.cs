using Common.Domain;
using FluentResults;

namespace UserManagement.Domain.ValueObjects;

public class Password : ValueObject
{
    public string Value { get; }

    private Password(string value)
    {
        Value = value;
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static Result<Password> Create(string value)
    {
        return new Password(value);
    }
}