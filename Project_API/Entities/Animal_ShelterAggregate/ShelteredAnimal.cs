namespace Project_API.Entities.Animal_ShelterAggregate
{
    public class ShelteredAnimal
    {
        private ShelteredAnimal() { }
        public ShelteredAnimal_ID ShelteredAnimal_UUID { get; private set; }
        public string Name { get; private set; }
        public ShelteredAnimalSpecies Species { get; private set; }
        public HealthCondition Condition { get; private set; }
        public class HealthCondition : Enumeration 
        {
            public static HealthCondition Healthy = new HealthCondition(1, nameof(Healthy));
            public static HealthCondition Sick = new HealthCondition(2, nameof(Sick));
            public HealthCondition(int id, string name) : base(id, name) { }
        }
    }
}
