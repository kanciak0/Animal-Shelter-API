using Project_API.Entities.Animal_ShelterAggregate;
using Project_API.Entities.UserAggregate;

public static class ClientMapper
{
     public static Client CreateClient(User user, AnimalShelter shelter)
    {
        var clientCredentials = new ClientCredentials(user.UserCredentials.FirstName, user.UserCredentials.LastName);
        var clientAddress = new ClientAddress(user.UserAddress.City, user.UserAddress.ZipCode, user.UserAddress.Street, user.UserAddress.HouseNumber);
        var clientId = new Client_ID(user.User_UUID.ToGuid());
        return shelter.RegisterClient(clientId, user.UserName, clientCredentials, clientAddress, user.Age);
    }
}
