using Project_API.Entities.Animal_ShelterAggregate;

namespace Project_API.Domain.Abstract
{
    public interface IClientRegistrationService
    {
        Client RegisterClient(Client_ID id, string username, ClientCredentials credentials, ClientAddress address, int age);
    }
}