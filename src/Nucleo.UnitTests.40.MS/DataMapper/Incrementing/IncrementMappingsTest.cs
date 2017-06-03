using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.DataMapper.Incrementing
{
	[TestClass]
	public class IncrementMappingsTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingMappingsReturnsCorrectValues()
		{
			//Arrange
			var map = Isolate.Fake.Instance<IncrementMappings>(Members.CallOriginal);

			//Act
			map.Register("F1", new object[] { "A", "B" });
			map.Register("F2", new object[] { "C", "D" });

			var results = map.GetMappings();

			//Assert
			Assert.AreEqual(2, results.Count);
			Assert.AreEqual("F1", results[0].Field);
			Assert.AreEqual("F2", results[1].Field);
		}

		[TestMethod]
		public void IsAtAllZerosReturnsFalse()
		{
			//Arrange
			var map = Isolate.Fake.Instance<IncrementMappings>(Members.CallOriginal);
			Isolate.NonPublic.Property.WhenGetCalled(map, "Values").WillReturn(new IncrementMappingCollection
			{
				new IncrementMapping { Field = "A", Values = new object[] { 1, 2 }, CurrentValueIndex = 0 },
				new IncrementMapping { Field = "B", Values = new object[] { 3, 4 }, CurrentValueIndex = 1 },
				new IncrementMapping { Field = "C", Values = new object[] { 5, 6 }, CurrentValueIndex = 0 },
				new IncrementMapping { Field = "D", Values = new object[] { 7, 8 }, CurrentValueIndex = 0 }
			});

			//Act
			var zero = map.IsAtAllZeros();

			//Assert
			Assert.AreEqual(false, zero);
		}

		[TestMethod]
		public void IsAtAllZerosReturnsTrue()
		{
			//Arrange
			var map = Isolate.Fake.Instance<IncrementMappings>(Members.CallOriginal);
			Isolate.NonPublic.Property.WhenGetCalled(map, "Values").WillReturn(new IncrementMappingCollection
			{
				new IncrementMapping { Field = "A", Values = new object[] { 1, 2 }, CurrentValueIndex = 0 },
				new IncrementMapping { Field = "B", Values = new object[] { 3, 4 }, CurrentValueIndex = 0 },
				new IncrementMapping { Field = "C", Values = new object[] { 5, 6 }, CurrentValueIndex = 0 },
				new IncrementMapping { Field = "D", Values = new object[] { 7, 8 }, CurrentValueIndex = 0 }
			});

			//Act
			var zero = map.IsAtAllZeros();

			//Assert
			Assert.AreEqual(true, zero);
		}

		[TestMethod]
		public void RegisteringMappingsAddsToUnderlyingCollection()
		{
			//Arrange
			var map = new IncrementMappings();

			//Act
			map.Register("F1", new object[] { "A", "B" });
			map.Register("F2", new object[] { "A", "B" });

			//Assert
			Assert.AreEqual(2, map.MappingCount);
		}

		#endregion
	}
}
