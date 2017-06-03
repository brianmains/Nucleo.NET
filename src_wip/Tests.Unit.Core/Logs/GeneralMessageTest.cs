using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Logs
{
	[TestClass]
	public class GeneralMessageTest
	{
		#region " Tests "

		[TestMethod]
		public void AssigningMessageAssignsValuesCorrectly()
		{
			var messageFake = Isolate.Fake.Instance<GeneralMessage>();
			Isolate.WhenCalled(() => messageFake.Message).CallOriginal();
			Isolate.WhenCalled(() => messageFake.Message = "").CallOriginal();

			messageFake.Message = "Test Msg";

			Assert.AreEqual("Test Msg", messageFake.Message);
		}

		[TestMethod]
		public void CreatingObjectAssignsValuesCorrectly()
		{
			GeneralMessage message = null;

			message = new GeneralMessage();

			Assert.IsNull(message.Message);

			message = new GeneralMessage("Test");

			Assert.AreEqual("Test", message.Message);
		}

		#endregion
	}
}
