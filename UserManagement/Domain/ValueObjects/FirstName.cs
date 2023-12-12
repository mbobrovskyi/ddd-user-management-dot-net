using UserManagement.Common;

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
}