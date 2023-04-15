namespace Project_API.Entities.Animal_ShelterAggregate
{
    public class ShelteredAnimalSpecies: ValueObject
    {
        public string _ShelteredAnimalSpecies { get; set; }

        private ShelteredAnimalSpecies() { }

        public ShelteredAnimalSpecies(string shelteredanimalspecies)
        {
            _ShelteredAnimalSpecies = shelteredanimalspecies;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return _ShelteredAnimalSpecies;

        }
    }
}
