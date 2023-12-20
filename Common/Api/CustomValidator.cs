using Common.Domain;
using FluentResults;
using FluentValidation;

namespace Common.Api;

public static class CustomValidator
{
    public static IRuleBuilderOptions<T, string> MustBeValueObject<T, TValueObject>(
        this IRuleBuilder<T, string> ruleBuilder, 
        Func<string, Result<TValueObject>> factoryMethod
    ) where TValueObject : ValueObject
    {
        return (IRuleBuilderOptions<T, string>)ruleBuilder.Custom((value, context) =>
        {
            Result<TValueObject> result = factoryMethod(value);
            if (result.IsFailed)
            {
                foreach (var error in result.Errors)
                {
                    context.AddFailure(error.Message);
                }
            }
        });
    }
}