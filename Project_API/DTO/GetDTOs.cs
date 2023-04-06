namespace Project_API.DTO
{

    public class GetUserDto
    {
        public Guid User_Uuid { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public List<GetAnimalDto> Animals { get; set; }
    }

    public class GetAnimalDto
    {
        public Guid Animal_Uuid { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
    }
}

