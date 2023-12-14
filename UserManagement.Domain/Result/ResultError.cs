namespace UserManagement.Common;

public class ResultError
{
    public static ResultError None = new ResultError("", "");

    public string Code { get; }
    public string Description { get; } = "";
    
    public ResultError(string code, string description)
    {
        Code = code;
        Description = description;
    }
}