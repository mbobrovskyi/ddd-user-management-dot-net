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
    
    public static Result<LastName> Create(string value)
    {
        return new LastName(value);
    }
}