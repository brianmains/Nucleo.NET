using System;
using System.ComponentModel;
using System.Collections.Generic;


namespace Nucleo.Collections
{
	public class StringCollectionConverter : TypeConverter
	{
		private string _separator = ",";



		#region " Constructors "

		public StringCollectionConverter(string separator)
		{
			_separator = separator;
		}

		#endregion


		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			if (sourceType.IsAssignableFrom(typeof(StringCollection)))
				return true;
			else
				return base.CanConvertFrom(context, sourceType);
		}

		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			if (destinationType.IsAssignableFrom(typeof(string)))
				return true;
			else
				return base.CanConvertTo(context, destinationType);
		}

		public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
		{
			if (value is string)
				return StringCollection.FromList(value.ToString(), _separator);
			else
				return base.ConvertFrom(context, culture, value);
		}

		public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType.IsAssignableFrom(typeof(string)) && value != null)
				return ((StringCollection)value).ToSeparatedList(_separator);
			else
				return base.ConvertTo(context, culture, value, destinationType);
		}
	}
}
