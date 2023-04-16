namespace Project_API.Entities.UserAggregate
{
    public class UserAddress : ValueObject
    {
        public string City { get;  set; }
        public string State { get;  set; }
        public string Country { get;  set; }
        public string ZipCode { get;  set; }
        public string Street { get;  set; }  
        public int HouseNumber { get;  set; }
        private UserAddress() { }

        public UserAddress(string city, string state, string country, string zipcode, int housenumber)
        {
            City = city;
            State = state;
            Country = country;
            ZipCode = zipcode;
            HouseNumber = housenumber;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return City;
            yield return State;
            yield return Country;
            yield return ZipCode;
            yield return HouseNumber;
        }
    }
}
