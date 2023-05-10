using Project_API.Entities;

namespace Project_API.Domain.UserAggregate
{
    public class UserAnimalSpecies : ValueObject
    {
        public string Breed { get; private set; }

        private UserAnimalSpecies() { }


        public UserAnimalSpecies(string breed)
        {
            Breed = breed;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Breed;
        }
    }
}
