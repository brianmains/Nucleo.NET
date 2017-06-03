using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;




namespace Nucleo.Web.Binding
{
	[TestClass]
	public class ModelBindingTests
	{
		#region " Test Classes "

		class TestModel
		{
			public string FirstName { get; set; }

			public string LastName { get; set; }

			public int Key { get; set; }

			public DateTime Created { get; set; }
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void BindingGenericModelInstantiatesAndReturnsModel()
		{
			//Arrange
			var collection = new FormCollection
			{
				{ "FirstName", "Ted" },
				{ "LastName", "Ryerson" },
				{ "Key", "ABC" },
				{ "Created", "A/C/DEFG" }
			};

			//Act
			var binding = new ModelBinding();
			var model = binding.Write<TestModel>(collection);

			//Assert
			Assert.AreEqual(0, model.Key);
			Assert.AreEqual(DateTime.MinValue, model.Created);
			Assert.AreEqual("Ted", model.FirstName);
			Assert.AreEqual("Ryerson", model.LastName);
			Assert.IsTrue(binding.HasErrors);
		}

		[TestMethod]
		public void BindingModelWithFieldErrorsReportsThem()
		{
			//Arrange
			var model = new TestModel();
			var collection = new FormCollection
			{
				{ "FirstName", "Ted" },
				{ "LastName", "Ryerson" },
				{ "Key", "ABC" },
				{ "Created", "A/C/DEFG" }
			};

			//Act
			var binding = new ModelBinding();
			binding.Write(model, collection);

			//Assert
			Assert.AreEqual(0, model.Key);
			Assert.AreEqual(DateTime.MinValue, model.Created);
			Assert.AreEqual("Ted", model.FirstName);
			Assert.AreEqual("Ryerson", model.LastName);
			Assert.IsTrue(binding.HasErrors);
		}

		[TestMethod]
		public void BindingModelWorksOK()
		{
			//Arrange
			var model = new TestModel();
			var collection = new FormCollection
			{
				{ "FirstName", "Ted" },
				{ "LastName", "Ryerson" },
				{ "Key", "1" },
				{ "Created", "1/1/2010" }
			};

			//Act
			var binding = new ModelBinding();
			binding.Write(model, collection);

			//Assert
			Assert.AreEqual("Ted", model.FirstName);
			Assert.AreEqual("Ryerson", model.LastName);
			Assert.AreEqual(1, model.Key);
			Assert.AreEqual(new DateTime(2010, 1, 1), model.Created);
		}

		[TestMethod]
		public void BindingNullFormReturnsNull()
		{
			//Arrange
			var binder = new ModelBinding();

			//Act
			var result = binder.Write(new object(), null);

			//Assert
			Assert.IsFalse(result);
		}

		[TestMethod]
		public void BindingNullModelThrowsException()
		{
			//Arrange
			var binder = new ModelBinding();

			//Act


			//Assert
			ExceptionTester.CheckException(true, (s) => { binder.Write(null, new FormCollection()); });
		}

		[TestMethod]
		public void GettingFormValuesFromModelsWorksOK()
		{
			//Arrange
			var binder = new ModelBinding();

			//Act
			var form = binder.Read(new { Key = 1, Name = "X" });

			//Assert
			Assert.AreEqual("1", form["Key"]);
			Assert.AreEqual("X", form["Name"]);
		}

		[TestMethod]
		public void GettingFormValuesWithNullCollectionThrowsException()
		{
			//Arrange
			var binder = new ModelBinding();

			//Act


			//Assert
			ExceptionTester.CheckException(true, (s) => { binder.Read(null); });
		}

		#endregion
	}
}
