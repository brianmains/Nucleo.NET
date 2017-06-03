using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.DataMapper.Incrementing
{
	[TestClass]
	public class IncrementMappingTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingAndSettingPropertiesWorksOK()
		{
			//Arrange
			var mapping = new IncrementMapping();

			//Act
			mapping.CurrentValueIndex = 2;
			mapping.Field = "X";
			mapping.Values = new object[] { "A", "B" };

			//Assert
			Assert.AreEqual(2, mapping.CurrentValueIndex);
			Assert.AreEqual("X", mapping.Field);
			Assert.AreEqual(2, mapping.Values.Length);
		}

		[TestMethod]
		public void GettingOutOfBoundsValueReturnsNull()
		{
			//Arrange
			var mapping = new IncrementMapping
			{
				CurrentValueIndex = 3,
				Values = new object[] { "A", "B", "C" }
			};

			//Act
			var value = mapping.GetValue();

			//Assert
			Assert.IsNull(value);
		}

		[TestMethod]
		public void GettingValueAtCurrentIndexReturnsCorrectValue()
		{
			//Arrange
			var mapping = new IncrementMapping
			{
				CurrentValueIndex = 0,
				Values = new object[] { "A", "B", "C" }
			};

			//Act
			var value1 = mapping.GetValue();
			mapping.CurrentValueIndex = 2;
			var value2 = mapping.GetValue();

			//Assert
			Assert.AreEqual("A", value1);
			Assert.AreEqual("C", value2);
		}

		[TestMethod]
		public void IncrementingValuesIncrementsValue()
		{
			//Arrange
			var mapping = new IncrementMapping
			{
				CurrentValueIndex = 0,
				Values = new object[] { "A", "B", "C" }
			};

			//Act
			var value1 = mapping.Increment();
			var value2 = mapping.Increment();

			//Assert
			Assert.AreEqual("C", mapping.GetValue());
		}

		[TestMethod]
		public void IncrementingValuesReturnsCorrectValue()
		{
			//Arrange
			var mapping = new IncrementMapping
			{
				CurrentValueIndex = 0,
				Values = new object[] { "A", "B", "C" }
			};

			//Act
			var value1 = mapping.Increment();
			var value2 = mapping.Increment();
			var value3 = mapping.Increment();

			//Assert
			Assert.AreEqual(true, value1);
			Assert.AreEqual(true, value2);
			Assert.AreEqual(false, value3);
		}

		#endregion
	}
}
