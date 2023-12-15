using Common.Domain;
using FluentResults;
using UserManagement.Domain.Aggregates;

namespace UserManagement.Domain.ValueObjects;

public class Username : ValueObject
{
    public string Value { get; }
    
    private Username(string value)
    {
        Value = value;
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    
    public static Result<Username> Create(string value)
    {
        return new Username(value);
    }
}