using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Logs
{
	[TestClass]
	public class LogMessageTest : LogMessage
	{
		#region " Constructors "

		public LogMessageTest() 
			: base() { }

		public LogMessageTest(string category)
			: base(category) { }

		#endregion



		#region " Methods "

		protected override string GetMessage()
		{
			return "This is my message.";
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void AssigningCategoryAssignsValuesCorrectly()
		{
			LogMessageTest test = new LogMessageTest("TestCat");
			Assert.AreEqual("TestCat", test.Category);
		}

		[TestMethod]
		public void GettingMessageReturnsCorrectMessage()
		{
			LogMessageTest test = new LogMessageTest();
			Assert.AreEqual("This is my message.", test.GetMessage());
		}

		#endregion
	}
}
