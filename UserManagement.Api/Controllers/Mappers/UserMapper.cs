using System.Globalization;
using UserManagement.Controllers.DataContracts;
using UserManagement.Domain.Aggregates;

namespace UserManagement.Controllers.Mappers;

public static class UserMapper
{
    public static UserDto UserToResponse(User user)
    {
        var dto = new UserDto
        {
            Id = user.Id,
            Email = user.Email.Value,
            Username = user.Username.Value,
            FirstName = user.FirstName.Value,
            LastName = user.LastName.Value,
            CreatedAt = user.CreatedAt.ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture),
            UpdatedAt = user.UpdatedAt.ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture)
        };
        return dto;
    }
}