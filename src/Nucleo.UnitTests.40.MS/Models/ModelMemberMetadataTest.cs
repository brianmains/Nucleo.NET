using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Models
{
	[TestClass]
	public class ModelMemberMetadataTest
	{
		#region " Test Classes "

		protected class TestClass
		{
			public int Key { get; set; }
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void CreatingWithModelMetadataAssignsPropsOK()
		{
			//Arrange
			var cls = Isolate.Fake.Instance<TestClass>();
			var prop = cls.GetType().GetProperty("Key");
			var def = Isolate.Fake.Instance<IModelInjection>();

			//Act
			var metadata = new ModelMemberMetadata(cls, prop, def);
			metadata.SetMemberValue(456);

			//Assert
			Assert.AreEqual(456, cls.Key);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CreatingWithModelMetadataWithAttributesAssignsPropsOK()
		{
			//Arrange
			var cls = Isolate.Fake.Instance<TestClass>();
			var prop = cls.GetType().GetProperty("Key");
			var def = Isolate.Fake.Instance<IModelInjection>();
			var attribs = new Dictionary<string, object>();
			attribs.Add("Test", 1);

			//Act
			var metadata = new ModelMemberMetadata(cls, prop, def, attribs);

			//Assert
			Assert.IsNotNull(metadata.Attributes);
			Assert.AreEqual(1, metadata.Attributes["Test"]);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CreatingWithModelMetadataWithoutPropertyInfoAssignsPropsOK()
		{
			//Arrange
			var cls = new TestClass();
			var def = Isolate.Fake.Instance<IModelInjection>();

			//Act
			var metadata = new ModelMemberMetadata(cls, null, def);

			//Assert
			Assert.AreEqual(cls, metadata.Model);
			Assert.AreEqual(def, metadata.InjectionDefinition);

			Isolate.CleanUp();
		}

		#endregion
	}
}
