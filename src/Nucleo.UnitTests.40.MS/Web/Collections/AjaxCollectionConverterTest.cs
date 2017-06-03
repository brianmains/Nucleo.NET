using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Web.Collections
{
	[TestClass]
	public class AjaxCollectionConverterTest
	{
		#region " Test Classes "

		protected class TestObject : IJsonOutput
		{
			public string Name { get; set; }
			public string Value { get; set; }

			public string ToJson()
			{
				return string.Format("{{ Name: '{0}', Value: '{1}' }}", this.Name, this.Value);
			}
		}


		protected class TestCollection : List<TestObject>, IAjaxSerializableCollection
		{
			private string _clientType = null;



			#region " Properties "

			public string ClientType
			{
				get { return _clientType; }
				set { _clientType = value; }
			}

			#endregion



			#region " Methods "

			public string GetClientCollectionType()
			{
				return this.ClientType;
			}

			public string ToJson()
			{
				string value = "";
				bool comma = false;

				foreach (var obj in this)
				{
					if (comma)
						value += ", ";
					else
						comma = true;

					value += obj.ToJson();
				}

				return value;
			}

			#endregion
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void ConvertingCollectionToJsonSucceeds()
		{
			var collection = new TestCollection
			{
				new TestObject { Name = "First", Value = "1" },
				new TestObject { Name = "Second", Value = "2" },
				new TestObject { Name = "Third", Value = "3" }
			};
			collection.ClientType = "Nucleo.Collections.Collection";

			string output = AjaxCollectionConverter.ConvertAjaxCollection(collection);

			Assert.AreEqual(string.Format("{{ ClientType: 'Nucleo.Collections.Collection', Values: [{0}] }}", collection.ToJson()), output, "JSON does not match");
		}

		[TestMethod]
		public void ConvertingCollectionWithNullCollectionTypeCreatesArray()
		{
			var collection = new TestCollection
			{
				new TestObject { Name = "First", Value = "1" },
				new TestObject { Name = "Second", Value = "2" },
				new TestObject { Name = "Third", Value = "3" }
			};

			string output = AjaxCollectionConverter.ConvertAjaxCollection(collection);

			Assert.AreEqual(string.Format("[{0}]", collection.ToJson()), output);
		}

		[TestMethod]
		public void ConvertingCollectionWithNullValueThrowsException()
		{
			try
			{
				AjaxCollectionConverter.ConvertAjaxCollection(null);
				Assert.Fail("Passing null value should throw exception, but didn't");
			}
			catch (ArgumentNullException ex)
			{
				Assert.AreEqual("collection", ex.ParamName);
			}
		}

		#endregion
	}
}
