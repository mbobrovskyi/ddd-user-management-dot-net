using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Common.Api;

public class ErrorActionResult : ErrorResponse, IActionResult
{
    public Task ExecuteResultAsync(ActionContext context)
    {
        var objectResult = new ObjectResult(this)
        {
            StatusCode = (int)HttpStatusCode
        };
        return objectResult.ExecuteResultAsync(context);
    }
}