using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Web.MetadataModel
{
	[TestClass]
	public class BaseXmlModelMetadataProviderTest : BaseXmlModelMetadataProvider
	{
		private ModelMetadata _propertyMetadata = null;
		private ModelMetadata _typeMetadata = null;



		#region " Test Classes "

		protected class TestClass
		{
			public int Key { get; set; }
			public string Name { get; set; }
			public DateTime CreatedDate { get; set; }
		}

		#endregion



		#region " Constructors "

		public BaseXmlModelMetadataProviderTest()
			: base("") { }

		#endregion



		#region " Methods "

		public override ModelMetadata GetXmlMetadataForProperty(XDocument document, XElement propertyMetadata, Type containerType, Func<object> modelAccessor)
		{
			return _propertyMetadata;
		}

		public override ModelMetadata GetXmlMetadataForType(XDocument document, XElement typeMetadata, Type type, Func<object> modelAccessor)
		{
			return _typeMetadata;
		}

		public override IDictionary<string, object> GetXmlPropertyAttributes(XDocument document, XElement propertyMetadata)
		{
			return null;
		}

		#endregion




		#region " Tests "

		[TestMethod]
		public void GettingMetadataForFullyNamedTypeWorksOK()
		{
			//Arrange
			XDocument doc = XDocument.Parse(string.Format(
				@"<root>
					<entity type=""{0}""></entity>
				</root>", typeof(TestClass).FullName));
			var provider = new BaseXmlModelMetadataProviderTest();

			//Act
			var element = provider.GetMetadataElement(doc, typeof(TestClass));

			//Assert
			Assert.IsNotNull(element);
			Assert.AreEqual("entity", element.Name.LocalName);
		}

		[TestMethod]
		public void GettingMetadataForShortNamedTypeWorksOK()
		{
			//Arrange
			XDocument doc = XDocument.Parse(string.Format(
				@"<root>
					<entity type=""{0}""></entity>
				</root>", typeof(TestClass).Name));
			var provider = new BaseXmlModelMetadataProviderTest();

			//Act
			var element = provider.GetMetadataElement(doc, typeof(TestClass));

			//Assert
			Assert.IsNotNull(element);
			Assert.AreEqual("entity", element.Name.LocalName);
		}

		#endregion

	}
}
//