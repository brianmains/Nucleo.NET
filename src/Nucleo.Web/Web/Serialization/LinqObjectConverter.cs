#if !NET20
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Data.Linq.Mapping;


namespace Nucleo.Web.Serialization
{
	public class LinqObjectConverter : JavaScriptConverter
	{
		#region " Methods "

		public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
		{
			object linqObject = Activator.CreateInstance(type);

			foreach (KeyValuePair<string, object> propertyValues in dictionary)
			{
				PropertyInfo property = type.GetProperty(propertyValues.Key);
				if (property != null && property.CanWrite)
					property.SetValue(linqObject, propertyValues.Value, null);
			}

			return linqObject;
		}

		public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
		{
			Dictionary<string, object> propertyValues = new Dictionary<string, object>();

			PropertyInfo[] properties = obj.GetType().GetProperties();
			foreach (PropertyInfo property in properties)
			{
				if (property.CanRead && Attribute.GetCustomAttribute(property, typeof(ColumnAttribute)) != null)
					propertyValues.Add(property.Name, property.GetValue(obj, null));
			}

			return propertyValues;
		}

		public override IEnumerable<Type> SupportedTypes
		{
			get { return null; }
		}

		#endregion
	}
}
#endif