using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Reflection;


namespace Nucleo.Web.Settings
{
	[TestClass]
	public class ListSettingsBuilderTest
	{
		#region " Test Classes "

		protected class ListTestClass
		{
			public int Key { get; set; }
			public string Name { get; set; }
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void AddingItemsToListWorksOK()
		{
			//Arrange
			var builder = new ListSettingsBuilder<ListTestClass>();

			//Act
			builder.Add(new ListTestClass { Key = 1, Name = "1" });
			builder.Add(new ListTestClass { Key = 2, Name = "2" });
			builder.Add(new ListTestClass { Key = 3, Name = "3" });
			builder.Add(new ListTestClass { Key = 4, Name = "4" });
			builder.Add(new ListTestClass { Key = 5, Name = "5" });

			var vals = builder.NonPublic().Property("Items").GetValue<IEnumerable<ListTestClass>>();

			//Assert
			Assert.AreEqual(5, vals.Count());
			Assert.AreEqual(1, vals.First().Key);
			Assert.AreEqual(5, vals.Last().Key);
		}

		[TestMethod]
		public void GettingItemsReturnsItems()
		{
			//Arrange
			var list = new List<ListTestClass>();
			list.Add(new ListTestClass { Key = 1, Name = "1" });
			list.Add(new ListTestClass { Key = 2, Name = "2" });
			list.Add(new ListTestClass { Key = 3, Name = "3" });
			list.Add(new ListTestClass { Key = 4, Name = "4" });
			list.Add(new ListTestClass { Key = 5, Name = "5" });

			var builderFake = Isolate.Fake.Instance<ListSettingsBuilder<ListTestClass>>(Members.CallOriginal);
			Isolate.NonPublic.Property.WhenGetCalled(builderFake, "Items").WillReturn(list);

			//Act
			var items = builderFake.GetAll();

			//Assert
			Assert.AreEqual(5, items.Count());

			Isolate.CleanUp();
		}

		[TestMethod]
		public void InsertingItemsToListWorksOK()
		{
			//Arrange
			var builder = new ListSettingsBuilder<ListTestClass>();

			//Act
			builder.Insert(0, new ListTestClass { Key = 1, Name = "1" });
			builder.Insert(0, new ListTestClass { Key = 2, Name = "2" });
			builder.Insert(0, new ListTestClass { Key = 3, Name = "3" });
			builder.Insert(0, new ListTestClass { Key = 4, Name = "4" });
			builder.Insert(0, new ListTestClass { Key = 5, Name = "5" });

			var vals = builder.NonPublic().Property("Items").GetValue<IEnumerable<ListTestClass>>();

			//Assert
			Assert.AreEqual(5, vals.Count());
			Assert.AreEqual(5, vals.First().Key);
			Assert.AreEqual(1, vals.Last().Key);
		}

		#endregion
	}
}
