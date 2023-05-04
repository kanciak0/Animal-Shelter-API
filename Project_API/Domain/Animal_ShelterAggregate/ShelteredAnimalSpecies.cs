namespace Project_API.Entities.Animal_ShelterAggregate
{
    public class ShelteredAnimalSpecies: ValueObject
    {
        public string Breed { get; set; }

        private ShelteredAnimalSpecies() { }

        public ShelteredAnimalSpecies(string shelteredanimalspecies)
        {
            Breed = shelteredanimalspecies;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Breed;
        }
    }
}
