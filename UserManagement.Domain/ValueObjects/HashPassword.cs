using System.Text.RegularExpressions;
using Common.Domain;
using FluentResults;

namespace UserManagement.Domain.ValueObjects;

public class HashPassword : ValueObject
{
    private const int MinLength = 8;
    private const int MaxLength = 128;
    private const int WorkFactor = 13;
    
    public string Hash { get; }

    public HashPassword(string hash)
    {
        Hash = hash;
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Hash;
    }

    public bool Verify(string textPassword)
    {
        return BCrypt.Net.BCrypt.Verify(textPassword, Hash);
    }
    
    public static Result<HashPassword> Create(string textPassword)
    {
        if (string.IsNullOrWhiteSpace(textPassword))
        {
            return Common.Errors.Global.IsRequiredError();
        }

        textPassword = textPassword.Trim();
        
        if (textPassword.Length < MinLength)
        {
            return Common.Errors.Global.MinLengthError(MinLength);
        }
        
        if (textPassword.Length > MaxLength)
        {
            return Common.Errors.Global.MaxLengthError(MaxLength);
        }
        
        if (!Regex.IsMatch(textPassword, @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$"))
        {
            return Common.Errors.Global.IsNotValidError();
        }
        
        return new HashPassword(BCrypt.Net.BCrypt.HashPassword(textPassword, WorkFactor));
    }
}
