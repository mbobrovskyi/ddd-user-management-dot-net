using UserManagement.Common;

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
}