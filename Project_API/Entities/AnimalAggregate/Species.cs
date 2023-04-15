namespace Project_API.Entities.AnimalAggregate
{
    public class Species : ValueObject
    {

        public string _Species { get; set; }

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
