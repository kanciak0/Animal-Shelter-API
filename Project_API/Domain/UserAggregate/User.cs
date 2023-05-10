using Project_API.Domain.UserAggregate;

namespace Project_API.Entities.UserAggregate
{
    public class User
    {
        public User_ID User_UUID { get; private set; }
        public string UserName { get; private set; }
        public UserCredentials UserCredentials { get; private set; }
        public UserAddress UserAddress { get; private set; }
        public int Age { get; private set; }
        public ICollection<UserAnimals> Animals { get; private set; } = new List<UserAnimals>();

        private User() { }
        public User(string username, UserCredentials credentials, UserAddress address, int age)
        {
            User_UUID = new User_ID(Guid.NewGuid());
            UserName = username;
            UserCredentials = credentials;
            UserAddress = address;
            Age = age;
        }

        public void Adopt(UserAnimals userAnimals)
        {
            Animals.Add(userAnimals);
        }
        public void GiveAnimalToShelter(UserAnimalId animalId)
        {
            if (animalId == null) throw new ArgumentNullException(nameof(animalId));
            var animalToRemove = Animals.SingleOrDefault(a => a.AnimalId == animalId);
            if (animalToRemove != null)
            {
                Animals.Remove(animalToRemove);
            }
        }

    }
}

        