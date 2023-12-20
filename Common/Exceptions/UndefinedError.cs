using Common.Errors;

namespace Common.Exceptions;

public class UndefinedError : HttpError
{
    public UndefinedError(Exception exception) : base(exception.Message) {}
}
