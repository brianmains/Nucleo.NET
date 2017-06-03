using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Text
{
	[TestClass]
	public class MessageTest
	{
		[TestMethod]
		public void TestCreatingObject()
		{
			Message message = new Message(Guid.NewGuid(), "Welcome", "Welcome to our site");
			Assert.AreNotEqual(Guid.Empty, message.ID);
			Assert.AreEqual("Welcome", message.Title);
			Assert.AreEqual("Welcome to our site", message.Text);
			Assert.AreEqual(null, message.EndDate);
			
			message = new Message(Guid.NewGuid(), "Hello", "Hello all", new DateTime(2007, 1, 1), null);
			Assert.AreNotEqual(Guid.Empty, message.ID);
			Assert.AreEqual("Hello", message.Title);
			Assert.AreEqual("Hello all", message.Text);
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2007, 1, 1), message.EffectiveDate));
		}
	}
}
