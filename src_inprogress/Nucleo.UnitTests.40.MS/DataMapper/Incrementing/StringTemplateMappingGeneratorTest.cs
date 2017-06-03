using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.DataMapper.Incrementing
{
	[TestClass]
	public class StringTemplateMappingGeneratorTest
	{
		#region " Tests "

		[TestMethod]
		public void GeneratingAStringTemplateWorksOK()
		{
			//Arrange
			var map = Isolate.Fake.Instance<IncrementMappings>(Members.CallOriginal);
			Isolate.WhenCalled(() => map.GetMappings()).WillReturn(new IncrementMappingCollection
			{
				new IncrementMapping { Field = "Key", Values = new object[] { "This", "Second" }, CurrentValueIndex = 0 },
				new IncrementMapping { Field = "Name", Values = new object[] { "First Item", "is" }, CurrentValueIndex = 1 },
				new IncrementMapping { Field = "Value", Values = new object[] { "b", "c", "a" }, CurrentValueIndex = 2 },
				new IncrementMapping { Field = "Value", Values = new object[] { "b", "test", "a" }, CurrentValueIndex = 1 }
			});

			var gen = new StringTemplateMappingGenerator("{0} {1} {2} {3}");

			//Act
			var value = gen.Generate(map);

			//Assert
			Assert.AreEqual("This is a test", value);
		}

		#endregion
	}
}
