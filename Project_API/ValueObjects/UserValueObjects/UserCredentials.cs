using Project_API.Common;

namespace Project_API.ValueObjects.UserValueObjects
{
    public class UserCredentials : ValueObject
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserCredentials() { }
        public UserCredentials(string firstName, string lastName)
        {
            firstName = FirstName;
            lastName = LastName;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return FirstName;
            yield return LastName;

        }
    }
}
