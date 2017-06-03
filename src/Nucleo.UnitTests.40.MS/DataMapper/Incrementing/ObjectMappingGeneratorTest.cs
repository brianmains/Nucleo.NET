using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.DataMapper.Incrementing
{
	[TestClass]
	public class ObjectMappingGeneratorTest
	{
		#region " Test Classes "

		public class TestClass
		{
			public string Key { get; set; }
			public string Name { get; set; }
			public int Value { get; set; }
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void CreatingObjectReturnsCorrectType()
		{
			//Arrange
			var gen = new ObjectMappingGenerator(typeof(TestClass));

			//Act

			//Assert
			Assert.AreEqual(typeof(TestClass), gen.ObjectType);
		}

		[TestMethod]
		public void GeneratingAnObjectAssignsOK()
		{
			//Arrange
			var map = Isolate.Fake.Instance<IncrementMappings>(Members.CallOriginal);
			Isolate.WhenCalled(() => map.GetMappings()).WillReturn(new IncrementMappingCollection
			{
				new IncrementMapping { Field = "Key", Values = new object[] { "First", "Second" }, CurrentValueIndex = 1 },
				new IncrementMapping { Field = "Name", Values = new object[] { "First Item", "Second Item" }, CurrentValueIndex = 0 },
				new IncrementMapping { Field = "Value", Values = new object[] { 1, 2, 3 }, CurrentValueIndex = 2 }
			});

			//Act
			var gen = new ObjectMappingGenerator(typeof(TestClass));
			var obj = gen.Generate(map) as TestClass;

			//Assert
			Assert.IsNotNull(obj);
			Assert.AreEqual("Second", obj.Key);
			Assert.AreEqual("First Item", obj.Name);
			Assert.AreEqual(3, obj.Value);
		}

		#endregion
	}
}
