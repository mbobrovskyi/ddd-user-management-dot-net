using System.Globalization;
using Common.Common;
using Common.Domain;
using UserManagement.Controllers.DataContracts;
using UserManagement.Domain.Aggregates;

namespace UserManagement.Controllers.Mappers;

public static class UserMapper
{
    public static UserDto UserToResponse(User user)
    {
        return new UserDto
        {
            Id = user.Id,
            Email = user.Email.Value,
            FirstName = user.FirstName.Value,
            LastName = user.LastName.Value,
            CreatedAt = user.CreatedAt.ToString(DateTimeFormats.IsoString, CultureInfo.InvariantCulture),
            UpdatedAt = user.UpdatedAt.ToString(DateTimeFormats.IsoString, CultureInfo.InvariantCulture)
        };
    }
}