using Project_API.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Project_API.Entities
{
    public class User_Entity
    {

        private User_Entity() { }
        public User_ID User_UUID { get; private set; }
        public string UserName { get; private set; }
        public UserCredentials Credentials { get; private set; }
        public Address Address { get; private set; }
        public virtual ICollection<Animal_Entity> Animals { get; private set; } = new List<Animal_Entity>();
        public static User_Entity Create(string username, UserCredentials credentials, Address address)
        {
            var user = new User_Entity
            {
                User_UUID = new User_ID(Guid.NewGuid()),
                UserName = username,
                Credentials = credentials,
                Address = address
            };
            return user;
        }
        public static User_Entity Update(User_ID uuid,string username)
        {
            var user = new User_Entity
            {
                User_UUID = uuid,
                UserName = username,
            };
            return user;
        }
        public static User_Entity Username(string username)
        {
            var user = new User_Entity
            { UserName = username };
            return user;
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
