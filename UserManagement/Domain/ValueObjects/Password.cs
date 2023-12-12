using UserManagement.Common;

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

    public Password Create(string value)
    {
        return new Password(value);
    }
}