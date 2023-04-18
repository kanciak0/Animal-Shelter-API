using System.Diagnostics.Metrics;
using System.Reflection.Emit;

namespace Project_API.Entities.Animal_ShelterAggregate
{
    public class ClientAddress : ValueObject
    {
        public string City { get; private set; }    
        public string ZipCode { get; private set; }
        public string Street { get; private set; }
        public int HouseNumber { get; private set; }
        public ClientAddress(string city, string zipcode, string street, int housenumber)
        {
            City = city;
            ZipCode = zipcode;
            Street = street;
            HouseNumber = housenumber;
        }
        private ClientAddress() { }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return City;
            yield return Street;
            yield return ZipCode;
            yield return HouseNumber;
        }
    }

}
