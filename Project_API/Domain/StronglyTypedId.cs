public class StronglyTypedId<T> where T : class
{
    private readonly Guid _value;

    public StronglyTypedId(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("The ID cannot be empty.", nameof(value));

        _value = value;
    }

    public Guid ToGuid() => _value;

    public override string ToString() => _value.ToString();

    public static implicit operator StronglyTypedId<T>(Guid value)
    {
        return new StronglyTypedId<T>(value);
    }
}