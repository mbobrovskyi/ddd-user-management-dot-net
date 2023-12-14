namespace UserManagement.Common;

public class Result
{
    public bool IsSuccess { get; protected set; }
    public List<ResultError>? Errors { get;  }

    protected Result(bool isSuccess, List<ResultError>? errors)
    {
        if (isSuccess && errors != null)
        {
            throw new InvalidOperationException();
        }

        if (!isSuccess && errors == null)
        {
            throw new InvalidOperationException();
        }
        
        IsSuccess = isSuccess;
        Errors = errors;
    }
    
    public bool IsFailure => !IsSuccess;

    public static Result Success()
    {
        return new Result(true, null);
    }

    public static Result Failure(List<ResultError> errors)
    {
        return new Result(false, errors);
    }
}