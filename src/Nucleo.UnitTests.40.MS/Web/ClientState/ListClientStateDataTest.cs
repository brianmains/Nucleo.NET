using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Web.ClientState
{
	[TestClass]
	public class ListClientStateDataTest
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
		public void AddingAdditionsToClientDataAddsValues()
		{
			var data = new ListClientStateData();
			data.Additions.Add(new JsonTest { Name = "First", Value = "1" });
			data.Additions.Add(new JsonTest { Name = "Second", Value = "2" });
			data.Additions.Add(new JsonTest { Name = "Third", Value = "3" });

			Assert.AreEqual(3, data.Additions.Count);
		}

		[TestMethod]
		public void AddingRemovalsToClientDataAddsValues()
		{
			var data = new ListClientStateData();
			data.Removals.Add(new JsonTest { Name = "First", Value = "1" });
			data.Removals.Add(new JsonTest { Name = "Second", Value = "2" });
			data.Removals.Add(new JsonTest { Name = "Third", Value = "3" });

			Assert.AreEqual(3, data.Removals.Count);
		}

		[TestMethod]
		public void AddingUpdatesToClientDataAddsValues()
		{
			var data = new ListClientStateData();
			data.Updates.Add(new JsonTest { Name = "First", Value = "1" });
			data.Updates.Add(new JsonTest { Name = "Second", Value = "2" });
			data.Updates.Add(new JsonTest { Name = "Third", Value = "3" });

			Assert.AreEqual(3, data.Updates.Count);
		}

		[TestMethod]
		public void AddingValuesToClientDataAddsValues()
		{
			var data = new ListClientStateData();
			data.Values.Add("HasChanges", true);
			data.Values.Add("Text", "Text");

			Assert.AreEqual(2, data.Values.Count);
		}

		[TestMethod]
		public void ConvertingJsonUsingValidJsonReturnsCorrectClientState()
		{
			string json = @"
				{
					additions: [{ name: 'First', value: 1}, {name: 'Second', value: 2}],
					removals: [{ name: 'Third', value: 3 }],
					updates: [{ name: 'Fourth', value: 4}],
					values: { hasChanges: true, text: 'text', value: 'text' }
				}";

			var data = ListClientStateData.FromJson(json);

			Assert.AreEqual(2, data.Additions.Count);
			Assert.AreEqual(1, data.Removals.Count);
			Assert.AreEqual(1, data.Updates.Count);
			Assert.AreEqual(3, data.Values.Count);
		}

		[TestMethod]
		public void ConvertingJsonWithNullValueThrowsException()
		{
			try
			{
				ListClientStateData.FromJson(null);
			}
			catch (ArgumentNullException ex)
			{
				Assert.AreEqual("json", ex.ParamName);
			}

			try
			{
				ListClientStateData.FromJson(string.Empty);
			}
			catch (ArgumentNullException ex)
			{
				Assert.AreEqual("json", ex.ParamName);
			}
		}

		[TestMethod]
		public void ConvertingToJsonReturnsCorrectString()
		{
			var stateData = new ListClientStateData();
			stateData.Additions.Add(new
			{
				Name = "First",
				Value = 1
			});
			stateData.Removals.Add(new
			{
				Name = "Second",
				Value = 2
			});
			stateData.Updates.Add(new
			{
				Name = "Third",
				Value = 3
			});
			stateData.Values.Add("HasChanges", true);

			var json = stateData.ToJson();

			Assert.AreEqual("{\"additions\":[{\"Name\":\"First\",\"Value\":1}],\"removals\":[{\"Name\":\"Second\",\"Value\":2}],\"updates\":[{\"Name\":\"Third\",\"Value\":3}],\"values\":{\"HasChanges\":true}}", json);
		}

		#endregion
	}
}
