using System.Text.Json.Serialization;

namespace Project_API.Entities.AnimalAggregate
{
    public class Species : ValueObject
    {
        [JsonPropertyName("Name")]
        [JsonInclude]
        public string _Species { get; private set; }

        private Species() { }

       
        public Species(string species)
        {
            _Species = species;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return _Species;

        }
    }
}
