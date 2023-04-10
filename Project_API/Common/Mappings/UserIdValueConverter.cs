using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project_API.Entities;

namespace Project_API.Common.Mappings
{
    public class UserIdValueConverter : ValueConverter<User_ID, Guid>
    {
        public UserIdValueConverter() : base(
            id => id.Value,
            guid => new User_ID(guid)

        )
        { }
    }
}
