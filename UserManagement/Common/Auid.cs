namespace UserManagement.Common;

public class Auid : ValueObject
{
    public long Value { get; }

    private Auid()
    {
        Value = 0;
    }

    private Auid(long value)
    {
        Value = value;
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static Auid Parse(long value)
    {
        ArgumentNullException.ThrowIfNull(value);
        return new Auid(value);
    }

    public static Auid Empty = new Auid();
}