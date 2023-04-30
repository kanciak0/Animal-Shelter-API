using Project_API.Entities.UserAggregate;

namespace Project_API.Domain.Abstract
{
    public interface IUser:IUserRepository
    {
        int Age { get; }
        ICollection<UserAnimalsID> AnimalIds { get; }
        User_ID User_UUID { get; }
        UserAddress UserAddress { get; }
        UserCredentials UserCredentials { get; }
        string UserName { get; }

        void Adopt(StronglyTypedId<UserAnimalsID> animalId);
        void GiveAnimalToShelter(StronglyTypedId<UserAnimalsID> userAnimalsID);
    }
}