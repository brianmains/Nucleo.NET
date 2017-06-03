using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Orm.Validation
{
	[TestClass]
	public class ValidationMessageTest
	{
		[TestMethod]
		public void CreatesTheMessagesAssignsOK()
		{
			var msg = new ValidationMessage("Test Message", true);

			Assert.AreEqual("Test Message", msg.Message);
			Assert.AreEqual(true, msg.IsErrorResult);
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void CreatesTheMessagesWithEmptyMessageThrowsException()
		{
			new ValidationMessage(string.Empty, true);

		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void CreatesTheMessagesWithNullMessageThrowsException()
		{
			new ValidationMessage(null, true);

		}
	}
}
