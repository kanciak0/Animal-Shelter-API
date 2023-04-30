using Project_API.Entities.AnimalAggregate;
using Project_API.Entities.UserAggregate;

namespace Project_API.DTO
{

    public class GetUserDto
    {
        public User_ID User_Uuid { get; set; }
        public string UserName { get; set; }
        public UserAddress Address { get; set; }
        public UserCredentials UserCredentials { get; set; }

        public List<GetAnimalDto> Animals { get; set; }
    }

    public class GetAnimalDto
    {
        public Animal_ID Animal_Uuid { get; set; }
        public string Name { get; set; }
        public Species Species { get; set; }
        public string Condition { get; set; }
    }

    public enum HealthCondition
    {
        Sick,
        Healthy
    }
}

