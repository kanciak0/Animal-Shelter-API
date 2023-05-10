
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

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

        [NotMapped]
        [AllowNull]
        public AnimalShelter AnimalShelter { get; }

        [NotMapped]
        public AnimalShelter_ID animal_shelter_Id { get; }
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
        public ShelteredAnimal(ShelteredAnimal_ID shelteredAnimal_ID, string name, ShelteredAnimalSpecies species, AnimalShelter_ID animal_shelter_id)
        {
            ShelteredAnimal_UUID = shelteredAnimal_ID;
            Name = name;
            Species = species;
            animal_shelter_Id = animal_shelter_id;
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