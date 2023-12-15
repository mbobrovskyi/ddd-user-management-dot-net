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

    public static Result<FirstName> Create(string value)
    {
        return new FirstName(value);
    }
}