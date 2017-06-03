using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Extensions
{
	[TestClass]
	public class ObjectExtensionsTest
	{
		#region " Test Classes "

		protected class TestClass
		{
			public int Key { get; set; }
			public int Value { get; set; }
			public int Level { get; set; }

			public Subclass Sub { get; set; }
		}

		protected class Subclass { }

		#endregion



		#region " Tests "

		[TestMethod]
		public void BulkSettingPropertiesWorksOK()
		{
			//Arrange
			var obj = new TestClass();

			//Act
			obj.Action((o) =>
				{
					o.Key = 1;
					o.Value = 2;
					o.Level = 3;
				});

			//Assert
			Assert.AreEqual(1, obj.Key);
			Assert.AreEqual(2, obj.Value);
			Assert.AreEqual(3, obj.Level);
		}

		[TestMethod]
		public void CopyingDataFromOneObjectToAnotherWorksOK()
		{
			//Arrange
			var sub = new Subclass();
			var source = new TestClass
			{
				Key = 22,
				Level = 1,
				Value = 34,
				Sub = sub
			};
			
			//Act
			var copy = new TestClass();
			copy.CopyFrom(source);

			//Assert
			Assert.AreEqual(22, copy.Key);
			Assert.AreEqual(1, copy.Level);
			Assert.AreEqual(34, copy.Value);
			Assert.AreEqual(sub, copy.Sub);
		}

		public void CopyingDataFromOneObjectToDictionaryWorksOK()
		{
			//Arrange
			var sub = new Subclass();
			var source = new Dictionary<string, object>
			{ 
				{ "Not", 234 },
				{ "Level", 22 },
				{ "Value", 34 },
				{ "Test", "X" },
				{ "Sub", sub }
			};

			//Act
			var copy = new TestClass();
			copy.CopyFrom(source);

			//Assert
			Assert.AreEqual(0, copy.Key);
			Assert.AreEqual(22, copy.Level);
			Assert.AreEqual(34, copy.Value);
			Assert.AreEqual(sub, copy.Sub);
		}

		[TestMethod]
		public void CopyingDataFromOneObjectToDifferentTypeObjectWorksOK()
		{
			//Arrange
			var source = new
			{
				Not = 234,
				Key = 22,
				Value = 34,
				Test = "X"
			};

			//Act
			var copy = new TestClass();
			copy.CopyFrom(source);

			//Assert
			Assert.AreEqual(22, copy.Key);
			Assert.AreEqual(0, copy.Level);
			Assert.AreEqual(34, copy.Value);
			Assert.AreEqual(null, copy.Sub);
		}

		[TestMethod]
		public void CopyingDataFromOneObjectToDifferentTypeObjectWorksOK2()
		{
			//Arrange
			var sub = new Subclass();
			var source = new
			{
				Not = 234,
				Level = 22,
				Value = 34,
				Test = "X",
				Sub = sub
			};

			//Act
			var copy = new TestClass();
			copy.CopyFrom(source);

			//Assert
			Assert.AreEqual(0, copy.Key);
			Assert.AreEqual(22, copy.Level);
			Assert.AreEqual(34, copy.Value);
			Assert.AreEqual(sub, copy.Sub);
		}

		[TestMethod]
		public void GettingValueCreatesNewInstance()
		{
			//Arrange
			var obj = new TestClass();

			//Act
			var val = obj.Get(i => i.Sub);

			//Assert
			Assert.IsNotNull(val);
		}

		[TestMethod]
		public void GettingValueReturnsExistingInstance()
		{
			//Arrange
			var sub = new Subclass();
			var obj = new TestClass { Sub = sub };

			//Act
			var val = obj.Get(i => i.Sub);

			//Assert
			Assert.AreEqual(sub, val);
		}

		#endregion
	}
}
