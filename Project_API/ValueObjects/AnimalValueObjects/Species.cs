using Project_API.Common;

namespace Project_API.ValueObjects.UserValueObjects
{
    public class Species : ValueObject
    {

        public string _Species { get; set; }

        public Species() { }

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
