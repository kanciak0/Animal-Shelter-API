using Project_API.Common.Models;
using Project_API.DTO;
using Project_API.Entities;
using Project_API.Features.User;

namespace Project_API.Common.Mappings
{
    public static class UserMappingProfile
    {
        public static GetUserDto MapToDto(this User user)
        {
            return new GetUserDto
            {
                User_Uuid = user.UUID,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                City = user.City,
                State = user.State,
                Country = user.Country,
                Animals = user.Animals.Select(a => a.MapToDto()).ToList()
            };
        }

        public static User MapToEntity(this GetUserDto userDto)
        {
            return new User
            {
                UserName = userDto.UserName,
                City = userDto.City,
                Country = userDto.Country,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                State = userDto.State,
                UUID = userDto.User_Uuid,
                Animals = userDto.Animals.Select(a => a.MapToEntity()).ToList()
            };
        }
    }
}

