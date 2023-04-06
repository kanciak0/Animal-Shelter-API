namespace Project_API.Common.Models
{
    public class UserModel
    {


        public Guid _user_uuid;
        public string _username;
        public string _firstname;
        public string _lastname;
        public string _city;
        public string _state;
        public string _country;
        public ICollection<AnimalModel> _animals;

        public UserModel(
            Guid user_uuid,
            string userName,
            string firstName,
            string lastName,
            string city,
            string state,
            string country,
            ICollection<AnimalModel> animals)
        {
            _user_uuid = user_uuid;
            _username = userName;
            _firstname = firstName;
            _lastname = lastName;
            _city = city;
            _state = state;
            _country = country;
            _animals = animals;
        }
    }
}
