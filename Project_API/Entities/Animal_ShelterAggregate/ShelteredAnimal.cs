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
            public static HealthCondition Healthy = new HealthCondition("Healthy", nameof(Healthy));
            public static HealthCondition Sick = new HealthCondition("Sick", nameof(Sick));
            public HealthCondition(string id, string name) : base(id, name) { }
        }
    }
}
