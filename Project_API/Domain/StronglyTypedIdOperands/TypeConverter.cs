using System;
using System.ComponentModel;

public class GenericTypeConverter<T> : TypeConverter
{
    public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
    {
        return sourceType == typeof(string);
    }

    public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
    {
        string strValue = value as string;
        if (strValue != null)
        {
            try
            {
                return (T)Convert.ChangeType(strValue, typeof(T));
            }
            catch (Exception)
            {
                throw new ArgumentException($"Invalid value '{strValue}' for type '{typeof(T).Name}'.");
            }
        }
        return base.ConvertFrom(context, culture, value);
    }
}
