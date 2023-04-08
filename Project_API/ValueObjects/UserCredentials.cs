using Project_API.Common;
using System.Diagnostics.Metrics;

namespace Project_API.ValueObjects
{
    public class UserCredentials : ValueObject
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
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
