using UserManagement.Common;

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
}