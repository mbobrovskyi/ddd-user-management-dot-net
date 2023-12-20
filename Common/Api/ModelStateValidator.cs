using Common.Errors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Common.Api;

public static class ModelStateValidator
{
    public static IActionResult ValidateModelState(ActionContext context)
    {
        var errors = new Dictionary<string, IEnumerable<string>>();
        foreach ((string fieldName, ModelStateEntry entry) in context.ModelState)
        {
            errors[fieldName] = new List<string>();
            errors[fieldName] = entry.Errors.Select(x => x.ErrorMessage);
        }

        var metaData = new Dictionary<string, object>
        {
            ["errors"] = errors
        };
        
        return new ErrorActionResult
        {
            Code = "ValidationError",
            Message = "One or more validation errors occured.",
            MetaData = metaData
        };
    }
}