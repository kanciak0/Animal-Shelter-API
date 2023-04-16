using Azure.Identity;
using System.ComponentModel.DataAnnotations;

namespace Project_API.Entities.UserAggregate
{
    public class User
    {

        public User_ID User_UUID { get; private set; }
        public string UserName { get; private set; }
        public UserCredentials UserCredentials { get; private set; }
        public UserAddress UserAddress { get; private set; }
        public ICollection<UserAnimalsID> AnimalIds { get; set; } = new List<UserAnimalsID>();

        private User() { }
        public static User CreateUser(string username, UserCredentials credentials, UserAddress address)
        {
            var user = new User
            {
                User_UUID = new User_ID(Guid.NewGuid()),
                UserName = username,
                UserCredentials = credentials,
                UserAddress = address
            };
            return user;
        }

        public void GiveAnimalToShelter(UserAnimalsID userAnimalsID)
        {
            if (userAnimalsID == null) throw new NotImplementedException();
            AnimalIds.Remove(userAnimalsID);
        }
        public bool Equals(User_ID other)
        {
            return other != null && User_UUID.Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as User_ID);
        }

        public override int GetHashCode()
        {
            return User_UUID.Value.GetHashCode();
        }

    }
}
/*
  public static void AddUserAnimalException(User_ID user, ICollection<Animal_ID> animal, string path)
        {
            if (!File.Exists(path))
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine("--------File for user-animal uuid pairs for exception--------");

                    foreach (Animal_ID animalId in animal)
                    {
                        sw.WriteLine($"{user.Value}:{animalId.Value}");
                    }
                }
            }
            else
            {
                foreach (string line in File.ReadAllLines(path))
                {
                    if (!string.IsNullOrWhiteSpace(line)) continue;
                }

                using (StreamWriter sw = new StreamWriter(path))
                {
                    foreach (Animal_ID animalId in animal)
                    {
                        sw.WriteLine($"{user.Value}:{animalId.Value}");
                    }
                }
            }
        } */
