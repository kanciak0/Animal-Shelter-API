using System.Collections.Concurrent;
using System.ComponentModel;
using System.Globalization;

public class StronglyTypedIdConverter : TypeConverter
{
    private static readonly ConcurrentDictionary<Type, TypeConverter> ActualConverters = new();

    private readonly TypeConverter _innerConverter;

    public StronglyTypedIdConverter(Type stronglyTypedIdType)
    {
        _innerConverter = ActualConverters.GetOrAdd(stronglyTypedIdType, CreateActualConverter);
    }

    public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) =>
        _innerConverter.CanConvertFrom(context, sourceType);
    public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) =>
        _innerConverter.CanConvertTo(context, destinationType);
    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) =>
        _innerConverter.ConvertFrom(context, culture, value);
    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType) =>
        _innerConverter.ConvertTo(context, culture, value, destinationType);


    private static TypeConverter CreateActualConverter(Type stronglyTypedIdType)
    {
        if (!StronglyTypedIdHelper.IsStronglyTypedId(stronglyTypedIdType, out var idType))
            throw new InvalidOperationException($"The type '{stronglyTypedIdType}' is not a strongly typed id");

        var actualConverterType = typeof(StronglyTypedIdConverter<>).MakeGenericType(idType);
        return (TypeConverter)Activator.CreateInstance(actualConverterType, stronglyTypedIdType)!;
    }
}