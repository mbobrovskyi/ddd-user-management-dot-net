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

    public static Result<Email> Create(string value)
    {
        return Result.Ok(new Email(value));
    }
}