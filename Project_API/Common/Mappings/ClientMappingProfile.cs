using Project_API.Entities.Animal_ShelterAggregate;
using Project_API.Entities.UserAggregate;

namespace Project_API.Common.Mappings
{
    public class ClientMappingProfile
    {
        public static Client FromUser(User user)
        {
            return Client.CreateClient(
                client_UUID: new Client_ID(user.User_UUID.Value),
                username: user.UserName,
                credentials: new ClientCredentials(user.UserCredentials.FirstName, user.UserCredentials.LastName),
                address: new ClientAddress(user.UserAddress.Street, user.UserAddress.City, user.UserAddress.State, user.UserAddress.HouseNumber),
                age: user.Age
            );
        }
    }
}
