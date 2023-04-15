using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_API.Entities.AnimalAggregate
{
    public class Animal
    {
        public Animal(Animal_ID animal_ID, string name, Species species)
        {
            Animal_UUID = animal_ID;
            Name = name;
            Species = species;
        }
        public Animal_ID Animal_UUID { get;private set; }
        public string Name { get; private set; }
        public Species Species { get; private set; }
        public HealthCondition Condition { get; private set; }    
        private Animal() { }
        public class HealthCondition : Enumeration
        {
            public static HealthCondition Healthy = new(1, nameof(Healthy));
            public static HealthCondition Sick = new(2, nameof(Sick));
            public HealthCondition(int id, string name) : base(id, name) { }
        }
    }
}
