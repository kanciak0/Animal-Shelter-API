using Project_API.Domain.Animal_ShelterAggregate;
using Project_API.Entities.Animal_ShelterAggregate;

namespace Project_API.Domain.Abstract
{
    public interface IClient
    {
        Client.Responsibility _Responsibility { get; }
        ClientAddress Address { get; }
        int Age { get; }
        Client_ID Client_UUID { get; }
        ClientCredentials Credentials { get; }
        string UserName { get; }
    }
}