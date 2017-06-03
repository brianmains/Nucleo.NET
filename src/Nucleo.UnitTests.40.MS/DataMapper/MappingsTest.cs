using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.DataMapper
{
	[TestClass]
	public class MappingsTest
	{
		#region " Test Classes "

		protected class TestClass
		{
			public string Name { get; set; }
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void GettingMappingWithExpressionWorksOK()
		{
			//Arrange
			var value = Isolate.Fake.Instance<IValue>();

			//Act
			var field = Mappings.Map<TestClass>(i => i.Name, value);

			//Assert
			Assert.AreEqual("Name", field.Field);
			Assert.AreEqual(value, field.Value);
		}

		[TestMethod]
		public void GettingMappingWithNameWorksOK()
		{
			//Arrange
			var value = Isolate.Fake.Instance<IValue>();

			//Act
			var field = Mappings.Map("Name", value);

			//Assert
			Assert.AreEqual("Name", field.Field);
			Assert.AreEqual(value, field.Value);

			Isolate.CleanUp();
		}

		#endregion
	}
}
