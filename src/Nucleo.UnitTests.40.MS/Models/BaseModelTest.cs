using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Collections;
using Nucleo.TestingTools;


namespace Nucleo.Models
{
	[TestClass]
	public class BaseModelTest
	{
		#region " Test Class "

		protected class TestingAttribute : IModelInjection
		{
			
		}

		public class FakeModel : BaseModel
		{
			private Dictionary<string, ModelValueEntry> _entries = new Dictionary<string, ModelValueEntry>();

			public FakeModel() { }

			public FakeModel(Dictionary<string, ModelValueEntry> entries)
			{
				_entries = entries;
			}

			protected override IDictionary<string, ModelValueEntry> CreateValues()
			{
				if (_entries == null)
					_entries = new Dictionary<string, ModelValueEntry>();

				return _entries;
			}

			public void AddOrUpdate(string name, object entry)
			{
				base.AddOrUpdateValue(name, entry);
			}

			public void AddOrUpdate(string name, ModelValueEntry entry)
			{
				base.AddOrUpdateValue(name, entry);
			}

			public void AddOrUpdate(string name, Action<ModelValueEntry> entry)
			{
				base.AddOrUpdateValue(name, entry);
			}
			
			public bool Remove(string key)
			{
				return base.RemoveValue(key);
			}
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void AddingValuesWithAttributesWorksOK()
		{
			//Arrange
			var dict = new Dictionary<string, ModelValueEntry>();
			var modelFake = new FakeModel(dict);

			//Act
			modelFake.AddOrUpdate("Test", new ModelValueEntry { Value = 123, Attributes = new ObjectCollection { new TestingAttribute() } });
			modelFake.AddOrUpdate("dsf", new ModelValueEntry { Value = 345, Attributes = new ObjectCollection { new TestingAttribute() } });

			//Assert
			Assert.AreEqual(2, dict.Count);
			Assert.AreEqual(123, dict["Test"].Value);
			Assert.AreEqual(345, dict["dsf"].Value);
		}

		[TestMethod]
		public void AddingValuesWithoutAttributesWorksOK()
		{
			//Arrange
			var dict = new Dictionary<string, ModelValueEntry>();
			var modelFake = new FakeModel(dict);

			//Act
			modelFake.AddOrUpdate("Test", 123);
			modelFake.AddOrUpdate("dsf", 456);

			//Assert
			Assert.AreEqual(2, dict.Count);
			Assert.AreEqual(123, dict["Test"].Value);
			Assert.AreEqual(456, dict["dsf"].Value);
		}

		[TestMethod]
		public void AddingValuesWorksOK()
		{
			//Arrange
			var dict = new Dictionary<string, ModelValueEntry>(); 
			var modelFake = new FakeModel(dict);

			//Act
			modelFake.AddOrUpdate("Test", new ModelValueEntry { Value = 123 });
			modelFake.AddOrUpdate("dsf", new ModelValueEntry { Value = 345 });

			//Assert
			Assert.AreEqual(2, dict.Count);
			Assert.AreEqual(123, dict["Test"].Value);
		}

		[TestMethod]
		public void GettingValuesWorksOK()
		{
			//Arrange
			var dict = new Dictionary<string, ModelValueEntry>();
			dict.Add("Test", new ModelValueEntry { Name = "Test", Value = 123 });

			var modelFake = new FakeModel(dict);

			//Act
			var value1 = modelFake.GetValue("Test");
			var value2 = modelFake.GetValue("123");

			//Assert
			Assert.AreEqual(123, value1);
			Assert.AreEqual(null, value2);
		}

		[TestMethod]
		public void GettingValuesWithGenericsWorksOK()
		{
			//Arrange
			var dict = new Dictionary<string, ModelValueEntry>();
			dict.Add("Test", new ModelValueEntry { Name = "Test", Value = 123 });

			var modelFake = new FakeModel(dict);

			//Act
			var value1 = modelFake.GetValue<int>("Test");
			var value2 = modelFake.GetValue<int>("123");
			var value3 = modelFake.GetValue<string>("SDF");
			var value4 = modelFake.GetValue<int>("Test");

			//Assert
			Assert.AreEqual(123, value1);
			Assert.AreEqual(default(int), value2);
			Assert.AreEqual(default(string), value3);
		}

		[TestMethod]
		public void RemovingValuesWithNullNameThrowsException()
		{
			var modelFake = new FakeModel();

			ExceptionTester.CheckException(true, (src) => { modelFake.Remove(null); });
			ExceptionTester.CheckException(true, (src) => { modelFake.Remove(string.Empty); });
		}

		[TestMethod]
		public void RemovingValuesWorksOK()
		{
			//Arrange
			var dict = new Dictionary<string, ModelValueEntry>();
			dict.Add("Test", new ModelValueEntry { Name = "Test", Value = 123 });

			var modelFake = new FakeModel(dict);

			//Act
			modelFake.Remove("Test");

			//Assert
			Assert.IsFalse(dict.ContainsKey("Test"));
		}

		[TestMethod]
		public void UpdatingValuesWorksOK()
		{
			//Arrange
			var dict = new Dictionary<string, ModelValueEntry>();
			dict.Add("Test", new ModelValueEntry { Name = "Test", Value = 123 });

			var modelFake = new FakeModel(dict);

			//Act
			modelFake.AddOrUpdate("Test", (e) => 
			{ 
				e.Value = 456; 
			});

			//Assert
			Assert.AreEqual(456, dict["Test"].Value);
		}

		#endregion
	}
}
