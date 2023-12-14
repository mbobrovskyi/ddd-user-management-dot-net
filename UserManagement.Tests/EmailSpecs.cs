using Xunit;

namespace UserManagement.Tests;

public class EmailSpecs
{
    [Theory]
    [InlineData("test@gmail.com")]
    [InlineData("t@g.c")]
    public void Email_valid(string email)
    {
    }
    
    [Theory]
    [InlineData("")]
    [InlineData("test")]
    [InlineData("t@g")]
    [InlineData("g.com")]
    public void Email_invalid(string email)
    {
    }
}