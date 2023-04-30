using Project_API.Domain.Abstract;
using Project_API.Entities.AnimalAggregate;

namespace Project_API.Entities.Animal_ShelterAggregate
{
    public class ShelteredAnimal
    {
        private ShelteredAnimal() { }
        public ShelteredAnimal_ID ShelteredAnimal_UUID { get; private set; }
        public string Name { get; private set; }
        public ShelteredAnimalSpecies Species { get; private set; }
        public HealthCondition Condition { get; private set; }
        public AdoptionStatus Status { get; private set; }
        public AnimalShelter AnimalShelter { get; }
        public int animal_shelter_Id { get; }
        public enum HealthCondition
        {
            Sick,
            Healthy
        }
        public enum AdoptionStatus
        {
            NotAdopted,
            Adopted
        }
        public void SetAdoptionStatus(AdoptionStatus status)
        {
            Status = status;
        }
        public void SetCondition(HealthCondition condition)
        {
            Condition = condition;
        }
        public ShelteredAnimal(ShelteredAnimal_ID shelteredAnimal_ID, string name, ShelteredAnimalSpecies species)
        {
            ShelteredAnimal_UUID = shelteredAnimal_ID;
            Name = name;
            Species = species;
        }

        //TODO: Make it through enumeration classes 
        /*       public class HealthCondition : Enumeration 
               {
                   public static HealthCondition Healthy = new HealthCondition("Healthy", nameof(Healthy));
                   public static HealthCondition Sick = new HealthCondition("Sick", nameof(Sick));
                   public HealthCondition(string id, string name) : base(id, name) { }
               }
           }*/
    }
}