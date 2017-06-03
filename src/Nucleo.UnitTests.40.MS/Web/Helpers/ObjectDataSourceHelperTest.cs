using System;
using System.Collections.Specialized;
using System.Web.UI.WebControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Web.Helpers
{
	[TestClass]
	public class ObjectDataSourceHelperTest
	{
		[TestMethod]
		public void TestSwitchValuesToNewParameter()
		{
			OrderedDictionary dictionary = new OrderedDictionary();
			dictionary.Add("EventID", 1);
			dictionary.Add("EventName", "Test");
			dictionary.Add("EventDate", new DateTime(2007, 5, 1));

			ObjectDataSourceMethodEventArgs e = new ObjectDataSourceMethodEventArgs(dictionary);
			ObjectDataSourceHelper.SwitchValuesToNewParameters(e, new string[] { "EventID", "EventName", "EventDate" }, new string[] { "intEventID", "strEventName", "dtEventDate" });
			Assert.IsTrue(dictionary.Contains("intEventID"));
			Assert.IsTrue(dictionary.Contains("strEventName"));
			Assert.IsTrue(dictionary.Contains("dtEventDate"));
			Assert.IsFalse(dictionary.Contains("EventID"));
			Assert.IsFalse(dictionary.Contains("EventName"));
			Assert.IsFalse(dictionary.Contains("EventDate"));

			Assert.AreEqual(1, dictionary["intEventID"]);
			Assert.AreEqual("Test", dictionary["strEventName"]);
			Assert.AreEqual(new DateTime(2007, 5, 1), dictionary["dtEventDate"]);
		}
	}

}
