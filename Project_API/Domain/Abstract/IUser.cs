using Project_API.Entities.UserAggregate;

namespace Project_API.Domain.Abstract
{
    public interface IUser:IUserRepository
    {
        int Age { get; }
        ICollection<UserAnimals> AnimalIds { get; }
        User_ID User_UUID { get; }
        UserAddress UserAddress { get; }
        UserCredentials UserCredentials { get; }
        string UserName { get; }

        void Adopt(StronglyTypedId<UserAnimals> animalId);
        void GiveAnimalToShelter(StronglyTypedId<UserAnimals> userAnimalsID);
    }
}