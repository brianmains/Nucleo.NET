using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Web.ClientState
{
	[TestClass]
	public class ClientStateDataTest
	{
		#region " Test Class "

		public class JsonTest
		{
			#region " Properties "

			public string Name
			{
				get;
				set;
			}

			public string Value
			{
				get;
				set;
			}

			#endregion
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void AddingValuesToClientDataAddsValues()
		{
			var data = new ClientStateData();
			data.Values.Add("HasChanges", true);
			data.Values.Add("Text", "Text");

			Assert.AreEqual(2, data.Values.Count);
		}

		[TestMethod]
		public void ConvertingJsonUsingValidJsonReturnsCorrectClientState()
		{
			//Arrange
			string json = @"
				{
					values: { hasChanges: true, text: 'text', value: 'text' }
				}";

			//Act
			var data = ClientStateData.FromJson(json);

			//Assert
			Assert.AreEqual(3, data.Values.Count);
		}

		[TestMethod]
		public void ConvertingJsonWithNullValueThrowsException()
		{
			try
			{
				ClientStateData.FromJson(null);
			}
			catch (ArgumentNullException ex)
			{
				Assert.AreEqual("json", ex.ParamName);
			}

			try
			{
				ClientStateData.FromJson(string.Empty);
			}
			catch (ArgumentNullException ex)
			{
				Assert.AreEqual("json", ex.ParamName);
			}
		}

		[TestMethod]
		public void ConvertingToJsonReturnsCorrectString()
		{
			var stateData = new ClientStateData();
			stateData.Values.Add("HasChanges", true);

			var json = stateData.ToJson();

			Assert.AreEqual("{\"values\":{\"HasChanges\":true}}",json);
		}

		#endregion
	}
}
