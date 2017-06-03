using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Xml.Linq;


namespace Nucleo.Web.MetadataModel
{
	public abstract class BaseXmlModelMetadataProvider : ModelMetadataProvider
	{
		private string _path = null;



		#region " Constructors "

		public BaseXmlModelMetadataProvider(string path)
		{
			_path = path;
		}

		#endregion



		#region " Methods "

		public abstract ModelMetadata GetXmlMetadataForProperty(XDocument document, XElement propertyMetadata, Type containerType, Func<object> modelAccessor);

		public abstract ModelMetadata GetXmlMetadataForType(XDocument document, XElement typeMetadata, Type type, Func<object> modelAccessor);

		public abstract IDictionary<string, object> GetXmlPropertyAttributes(XDocument document, XElement propertyMetadata);

		#endregion



		#region " Base Methods "

		/// <summary>
		/// Gets the XML element for the metadata container type.
		/// </summary>
		/// <param name="document">The document containing the definitions.</param>
		/// <param name="containerType">The container element type.</param>
		/// <returns>The XML element.</returns>
		protected virtual XElement GetMetadataElement(XDocument document, Type containerType)
		{
			//First try the full name for specificity
			XElement metadata = document.Root.Descendants().FirstOrDefault(i => i.Attribute("type") != null && i.Attribute("type").Value == containerType.FullName);
			//Try the local name for generic
			if (metadata == null)
				metadata = document.Root.Descendants().FirstOrDefault(i => i.Attribute("type") != null && i.Attribute("type").Value == containerType.Name);
			
			return metadata;
		}

		public override IEnumerable<ModelMetadata> GetMetadataForProperties(object container, Type containerType)
		{
			XDocument document = XDocument.Load(_path);
			XElement metadata = this.GetMetadataElement(document, containerType);
			if (metadata == null)
				return null;

			List<ModelMetadata> outputMetadata = new List<ModelMetadata>();

			foreach (XElement property in metadata.Elements())
				outputMetadata.Add(GetXmlMetadataForProperty(document, property, containerType, () => property));

			return outputMetadata;
		}

		public override ModelMetadata GetMetadataForProperty(Func<object> modelAccessor, Type containerType, string propertyName)
		{
			XDocument document = XDocument.Load(_path);
			XElement metadata = this.GetMetadataElement(document, containerType);
			if (metadata == null)
				return null;

			return GetXmlMetadataForProperty(document, metadata.Element(propertyName), containerType, modelAccessor);
		}

		public override ModelMetadata GetMetadataForType(Func<object> modelAccessor, Type modelType)
		{
			XDocument document = XDocument.Load(_path);
			XElement metadata = this.GetMetadataElement(document, modelType);
			if (metadata == null)
				return null;

			return GetXmlMetadataForType(document, metadata, modelType, modelAccessor);
		}

		#endregion
	}
}
