using Project_API.Common;

namespace Project_API.ValueObjects
{
    public class Address : ValueObject
    {

        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }


        public Address() { }

        public Address(string city, string state, string country)
        {
            City = city;
            State = state;
            Country = country;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return City;
            yield return State;
            yield return Country;
        }
    }
}
