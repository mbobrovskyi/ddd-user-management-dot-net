namespace UserManagement.Common;

public class Result<T> : Result
{
    public T Value { get; } 
    
    protected Result(bool isSuccess, List<ResultError>? errors, T value) : base(isSuccess, errors)
    {
        Value = value;
    }
}