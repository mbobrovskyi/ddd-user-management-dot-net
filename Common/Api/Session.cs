namespace Common.Api;

public class Session
{
    public Guid SessionId { get; }
    public long UserId { get; }

    public Session(long userId)
    {
        SessionId = Guid.NewGuid();
        UserId = userId;
    }
}