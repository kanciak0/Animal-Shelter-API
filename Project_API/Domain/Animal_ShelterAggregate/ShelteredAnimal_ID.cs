namespace Project_API.Entities.Animal_ShelterAggregate;

public class ShelteredAnimal_ID : StronglyTypedId<ShelteredAnimal_ID>
{
    public ShelteredAnimal_ID(Guid value) : base(value)
    {
    }
    public static ShelteredAnimal_ID FromGuid(Guid guid)
    {
        return new ShelteredAnimal_ID(guid);
    }
}
