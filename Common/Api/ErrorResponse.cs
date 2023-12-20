using System.Diagnostics;
using System.Net;
using System.Text.Json.Serialization;

namespace Common.Api;

public class ErrorResponse
{
    public string Code { get; set; }
    public string Message { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    public HttpStatusCode HttpStatusCode { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, object> MetaData { get; set; }
}