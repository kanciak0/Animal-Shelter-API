using Project_API.Entities;
using Project_API.ValueObjects;
using Project_API.ValueObjects.UserValueObjects;

namespace Project_API.DTO
{

    public class GetUserDto
    {
        public User_ID User_Uuid { get; set; }
        public string UserName { get; set; }
        public Address Address { get; set; }
        public UserCredentials UserCredentials { get; set; }

        public List<GetAnimalDto> Animals { get; set; }
    }

    public class GetAnimalDto
    {
        public Animal_ID Animal_Uuid { get; set; }
        public string Name { get; set; }
        public Species Species { get; set; }
    }
}

