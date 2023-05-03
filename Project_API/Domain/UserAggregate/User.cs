using Project_API.Domain.Abstract;
using Project_API.Entities.AnimalAggregate;

namespace Project_API.Entities.UserAggregate
{
    public class User
    {

        public User_ID User_UUID { get; private set; }
        public string UserName { get; private set; }
        public UserCredentials UserCredentials { get; private set; }
        public UserAddress UserAddress { get; private set; }
        public int Age { get; private set; }
        public ICollection<UserAnimalsID> AnimalIds { get; private set; } = new List<UserAnimalsID>();

        private User() { }
        public User(string username, UserCredentials credentials, UserAddress address, int age)
        {
            User_UUID = new User_ID(Guid.NewGuid());
            UserName = username;
            UserCredentials = credentials;
            UserAddress = address;
            Age = age;
        }

        public void Adopt(StronglyTypedId<UserAnimalsID> animalId)
        {
            var userAnimalId = new UserAnimalsID(animalId.ToGuid());
            AnimalIds.Add(userAnimalId);
        }
        public void GiveAnimalToShelter(StronglyTypedId<UserAnimalsID> userAnimalId)
        {
            if (userAnimalId == null) throw new ArgumentNullException(nameof(userAnimalId));
            var animalIdToRemove = new UserAnimalsID(userAnimalId.ToGuid());
            AnimalIds.Remove(animalIdToRemove);
        }
    }
}

        