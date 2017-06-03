using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Reflection;

using Nucleo.Collections;


namespace Nucleo.Web.Serialization
{
	public class GenericCollectionJavaScriptConverter<CT, IT> : JavaScriptConverter
		where CT : class, ICollection<IT>
		where IT: class
	{
		private SimpleCollection<Type> _supportedTypes = new SimpleCollection<Type>();



		#region " Properties "

		public override IEnumerable<Type> SupportedTypes
		{
			get { return _supportedTypes.ToArray(); }
		}

		#endregion



		#region " Methods "

		public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
		{
			CT collection = Activator.CreateInstance<CT>();

			if (type == null || !type.Equals(typeof(CT)))
				return collection;

			ArrayList itemList = (ArrayList)dictionary["Objects"];

			foreach (Dictionary<string, object> propertyDict in itemList)
				collection.Add(serializer.ConvertToType<IT>(propertyDict));

			return collection;
		}

		private PropertyInfo[] GetProperties()
		{
			return typeof(IT).GetProperties();
		}

		public void RegisterSupportedType(Type type)
		{
			_supportedTypes.Add(type);
		}

		public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
		{
			CT collection = obj as CT;
			Dictionary<string, object> returnedDict = new Dictionary<string,object>();

			if (collection == null || collection.Count == 0)
				return returnedDict;

			PropertyInfo[] properties = this.GetProperties();

			ArrayList itemList = new ArrayList();

			foreach (IT item in collection)
			{
				Dictionary<string, object> propertyDict = new Dictionary<string,object>();
				foreach (PropertyInfo property in properties)
					propertyDict.Add(property.Name, property.GetValue(item, null));

				itemList.Add(propertyDict);
			}

			returnedDict.Add("Objects", itemList);
			return returnedDict;
		}

		#endregion
	}
}
