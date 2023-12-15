namespace UserManagement.Controllers.DataContracts;

public class TokenDto
{
    public string Token { get; }
    public long ExpIn { get; }
    public DateTime ExpTime { get; }
    public UserDto User { get; }
}