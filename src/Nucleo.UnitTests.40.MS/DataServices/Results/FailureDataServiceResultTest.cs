using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.DataServices.Modules;


namespace Nucleo.DataServices.Results
{
	[TestClass]
	public class FailureDataServiceResultTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingResultWorksOK()
		{
			//Arrange
			var result = default(FailureDataServiceResult);
			var moduleFake = Isolate.Fake.Instance<IDataServiceModule>();
			Isolate.WhenCalled(() => moduleFake.DisplayName).WillReturn("Test");

			//Act
			result = new FailureDataServiceResult(moduleFake, "This is my status");

			//Assert
			Assert.AreEqual("The module 'Test' failed for the following reason: This is my status", result.GetStatus());
		}

		#endregion
	}
}
