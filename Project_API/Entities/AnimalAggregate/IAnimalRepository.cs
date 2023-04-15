namespace Project_API.Entities.AnimalAggregate
{
    public interface IAnimalRepository:IDisposable
    {
        IEnumerable<Animal> GetAnimals();
        Animal GetAnimalByID(Animal_ID animalid);
        void InsertAnimal(Animal animal);
        void DeleteAnimal(Animal_ID animalid);
        void UpdateAnimal(Animal animal);
        void Save();
    }
}
