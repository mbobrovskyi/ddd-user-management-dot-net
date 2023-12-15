using FluentNHibernate.Mapping;
using UserManagement.Domain.Aggregates;

namespace UserManagement.Infrastructure;

public class UserMap : ClassMap<User>
{
    public UserMap()
    {
        Id(x => x.Id);
        Map(x => x.Email);
        Map(x => x.Username);
        Map(x => x.FirstName);
        Map(x => x.LastName);
        Map(x => x.CreatedAt);
        Map(x => x.UpdatedAt);
    }
}