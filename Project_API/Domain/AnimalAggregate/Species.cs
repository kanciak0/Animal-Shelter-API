using System.Text.Json.Serialization;

namespace Project_API.Entities.AnimalAggregate
{
    public class Species : ValueObject
    {
        public string Breed { get; private set; }

        private Species() { }

       
        public Species(string breed)
        {
            Breed = breed;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Breed;
        }
    }
}
