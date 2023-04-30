namespace Project_API.Entities.Animal_ShelterAggregate;

public class Client_ID : StronglyTypedId<Client_ID>
{
    public Client_ID(Guid value) : base(value)
    {
    }
    public static Client_ID FromGuid(Guid guid)
    {
        return new Client_ID(guid);
    }
}

