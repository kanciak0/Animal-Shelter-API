using Project_API.Domain.Abstract;
using Project_API.Entities.Animal_ShelterAggregate;
using Project_API.Entities.UserAggregate;

public static class ClientMapper
{
     public static Client CreateClient(User user, IClientRegistrationService registrationService)
    {
        var clientCredentials = new ClientCredentials(user.UserCredentials.FirstName, user.UserCredentials.LastName);
        var clientAddress = new ClientAddress(user.UserAddress.City, user.UserAddress.ZipCode, user.UserAddress.Street, user.UserAddress.HouseNumber);
        var clientId = new Client_ID(user.User_UUID.Value);
        return registrationService.RegisterClient(clientId, user.UserName, clientCredentials, clientAddress, user.Age);
    }
}
