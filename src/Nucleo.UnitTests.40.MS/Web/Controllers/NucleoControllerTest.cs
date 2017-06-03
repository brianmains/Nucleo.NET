using System;
using System.Web.Mvc;
using TypeMock.ArrangeActAssert;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Web.Controllers
{
	[TestClass]
	public class NucleoControllerTest
	{
		#region " Test Classes "

		public class TestController : NucleoController { }

		#endregion



		#region " Tests "

		[TestMethod]
		public void AssigningCustomControllerContextWorksOK()
		{
			//Arrange
			var ctlr = new TestController();
			var ctx = new MvcRequestContext();

			//Act
			ctlr.Context = ctx;

			//Assert
			Assert.AreEqual(ctx, ctlr.Context);
		}

		#endregion
	}
}