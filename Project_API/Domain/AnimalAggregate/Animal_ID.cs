namespace Project_API.Entities.AnimalAggregate;
public class Animal_ID : StronglyTypedId<Animal_ID>
{
    public Animal_ID(Guid value) : base(value)
    {
    }
    public static Animal_ID FromGuid(Guid guid)
    {
        return new Animal_ID(guid);
    }
    public static Animal_ID NewId()
    {
        return new Animal_ID(Guid.NewGuid());
    }
}
