using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_API.Entities
{
    public class Animal_Entity
    {
        private Animal_Entity() { }
        public Animal_ID Animal_UUID { get; private set; }
        public string Name { get;private set; }
        public string Species { get; private set; }
        public virtual User_Entity? User { get; private set; }
        public static Animal_Entity Create(string name, string species)
        {
            var animal = new Animal_Entity
            {
                Animal_UUID =new Animal_ID(Guid.NewGuid()),
                Name = name,
                Species = species,
            };
            return animal;
        }
    }
}
