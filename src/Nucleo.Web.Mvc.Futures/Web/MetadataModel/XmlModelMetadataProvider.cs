using System;
using System.Reflection;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Web.Mvc;


namespace Nucleo.Web.MetadataModel
{
	public class XmlModelMetadataProvider : BaseXmlModelMetadataProvider
	{
		#region " Constructors "

		public XmlModelMetadataProvider(string path)
			: base(path) { }

		#endregion



		#region " Methods "

		protected virtual void AssignMetadataValue(ModelMetadata metadata, string name, object value)
		{
			PropertyInfo property = metadata.GetType().GetProperty(name);
			if (property == null || !property.CanWrite)
				return;

			if (value == null)
			{
				property.SetValue(metadata, null, null);
				return;
			}

			if (property.PropertyType.Equals(typeof(System.Collections.IDictionary)))
			{
				IDictionary<string, object> output = new Dictionary<string, object>();
				string[] values = value.ToString().Split(',');

				foreach (string pair in values)
				{
					string[] entry = pair.Split('=');
					if (entry.Length == 2)
						output.Add(entry[0], entry[1]);
				}

				property.SetValue(metadata, output, null);
			}
			else
			{
				property.SetValue(metadata, Convert.ChangeType(value, property.PropertyType), null);
			}
		}

		public override ModelMetadata GetXmlMetadataForProperty(XDocument document, XElement propertyMetadata, Type containerType, Func<object> modelAccessor)
		{
			ModelMetadata metadata = new ModelMetadata(this, containerType, modelAccessor, Type.GetType(propertyMetadata.Attribute("type").Value), propertyMetadata.Name.LocalName);
			IDictionary<string, object> attributes = this.GetXmlPropertyAttributes(document, propertyMetadata);

			foreach (KeyValuePair<string, object> attribute in attributes)
				this.AssignMetadataValue(metadata, attribute.Key, attribute.Value);

			return metadata;
		}

		public override ModelMetadata GetXmlMetadataForType(XDocument document, XElement typeMetadata, Type type, Func<object> modelAccessor)
		{
			ModelMetadata metadata = new ModelMetadata(this, null, modelAccessor, type, null);
			


			return metadata;
		}

		public override IDictionary<string, object> GetXmlPropertyAttributes(XDocument document, XElement propertyMetadata)
		{
			IDictionary<string, object> output = new Dictionary<string, object>();
			IEnumerable<XElement> properties = propertyMetadata.Elements();

			foreach (XElement property in properties)
				output.Add(property.Name.LocalName, property.Value);

			return output;
		}

		#endregion
	}
}
