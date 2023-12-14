using FluentNHibernate.Mapping;
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure;

public class UserMap : ClassMap<User>
{
    public UserMap()
    {
        Id(x => x.Id);
        Component(x => x.Email);
        Component(x => x.Username);
        Component(x => x.FirstName);
        Component(x => x.LastName);
        Component(x => x.CreatedAt);
        Component(x => x.UpdatedAt);
    }
}