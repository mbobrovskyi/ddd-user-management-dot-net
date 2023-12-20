using Common.Domain;

namespace UserManagement.Domain.ValueObjects;

public class TokenData : ValueObject
{
    public string Token { get; }
    public int ExpIn { get; }
    public DateTime ExpTime { get; }
 
    public TokenData(string token, int expIn, DateTime expTime)
    {
        Token = token;
        ExpIn = expIn;
        ExpTime = expTime;
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Token;
    }
}