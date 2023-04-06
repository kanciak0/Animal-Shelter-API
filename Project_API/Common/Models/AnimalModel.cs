namespace Project_API.Common.Models
{
    public class AnimalModel
    {


        public Guid _animal_uuid;
        public string _name;
        public string _species;
        public UserModel _user;

        public AnimalModel(Guid animal_uuid, string name, string species, UserModel user)
        {
            _animal_uuid = animal_uuid;
            _name = name;
            _species = species;
            _user = user;
        }
    }
}
