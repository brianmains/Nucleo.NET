using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Web.Filters
{
	[TestClass]
	public class AjaxOnlyRequestAttributeTest
	{
		#region " Tests "

		[TestMethod]
		public void ExecutingActionForNonAjaxRequestWorksAsExpected()
		{
			//Arrange
			var httpCtx = Isolate.Fake.Instance<HttpContextBase>();
			Isolate.WhenCalled(() => httpCtx.Request.IsAjaxRequest());

			var actionCtx = Isolate.Fake.Instance<ActionExecutingContext>();
			Isolate.WhenCalled(() => actionCtx.HttpContext).WillReturn(httpCtx);

			//Act
			var attribute = new AjaxOnlyRequestAttribute();

			//Assert


			Isolate.CleanUp();
		}

		#endregion
	}
}
