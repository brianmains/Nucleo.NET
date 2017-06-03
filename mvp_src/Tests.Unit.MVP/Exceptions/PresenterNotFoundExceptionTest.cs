using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Exceptions
{
	[TestClass]
	public class PresenterNotFoundExceptionTest
	{
		[TestMethod]
		public void CreatingEmptyThrowsDefaultMessage()
		{
			//Arrange

			//Act
			var ex = new PresenterNotFoundException();

			//Assert
			Assert.AreEqual("The presenter could not be found.", ex.Message);
		}

		[TestMethod]
		public void CreatingWithPresenterAndExceptionPassesMessage()
		{
			//Arrange

			//Act
			var ex = new PresenterNotFoundException("TestPresenter", new Exception());

			//Assert
			Assert.AreEqual("The presenter 'TestPresenter' could not be found.", ex.Message);
			Assert.IsNotNull(ex.InnerException);
		}

		[TestMethod]
		public void CreatingWithPresenterPassesMessage()
		{
			//Arrange

			//Act
			var ex = new PresenterNotFoundException("TestPresenter");

			//Assert
			Assert.AreEqual("The presenter 'TestPresenter' could not be found.", ex.Message);
		}
	}
}
