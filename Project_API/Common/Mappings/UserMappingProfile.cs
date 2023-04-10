using Project_API.DTO;
using Project_API.Entities;
using Project_API.Features.User;

namespace Project_API.Common.Mappings
{
    public static class UserMappingProfile
    {
        public static GetUserDto MapToDto(this User_Entity user)
        {
            return new GetUserDto
            {
                User_Uuid = user.User_UUID,
                UserName = user.UserName,
                Address = user.Address,
                UserCredentials = user.Credentials,
                Animals = user.Animals.Select(a => a.MapToDto()).ToList()
            };
        }
    }
}

