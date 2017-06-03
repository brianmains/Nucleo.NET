using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.DataServices.Modules;


namespace Nucleo.DataServices.Results
{
	[TestClass]
	public class ExceptionDataServiceResultTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingResultWorksOK()
		{
			//Arrange
			var ex = new Exception("Test");

			//Act
			var result = new ExceptionDataServiceResult(null, ex);

			//Assert
			Assert.AreEqual(ex, result.Exception);
		}

		[TestMethod]
		public void GettingStatusWorksOK()
		{
			//Arrange
			var ex = new Exception("Test");
			var moduleFake = Isolate.Fake.Instance<IDataServiceModule>();
			Isolate.WhenCalled(() => moduleFake.DisplayName).WillReturn("Fake Display");

			//Act
			var message = new ExceptionDataServiceResult(moduleFake, ex).GetStatus();

			//Assert
			StringAssert.StartsWith(message, "The module 'Fake Display' reported the exception: ");
		}

		#endregion
	}
}
