using System.Net;

namespace Common.Errors;

public class HttpError : Exception
{
    public string Code { get; }
    public HttpStatusCode HttpStatusCode { get; }
    public Dictionary<string, object> MetaData { get; }
    
    public HttpError(string message) 
        : base(message)
    {
        Code = GetType().Name;
        HttpStatusCode = HttpStatusCode.InternalServerError;
    }
    
    public HttpError(string message, HttpStatusCode httpStatusCode) 
        : this(message)
    {
        Code = GetType().Name;
        HttpStatusCode = httpStatusCode;
    }
    
    public HttpError(string message, HttpStatusCode httpStatusCode, Dictionary<string, object> metaData)
        : this(message)
    {
        Code = GetType().Name;
        HttpStatusCode = httpStatusCode;
    }
}