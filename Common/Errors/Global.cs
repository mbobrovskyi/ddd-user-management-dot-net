namespace Common.Errors;

public static class Global
{
    public static FluentResults.Error IsRequiredError() =>
        new FluentResults.Error( "Value is required.");
        
    public static FluentResults.Error MinLengthError(int minLength) =>
        new FluentResults.Error( $"Min length is {minLength}.");
        
    public static FluentResults.Error MaxLengthError(int maxLength) =>
        new FluentResults.Error( $"Max length is {maxLength}.");
        
    public static FluentResults.Error IsNotValidError() =>
        new FluentResults.Error( "Value is not valid.");
    
}