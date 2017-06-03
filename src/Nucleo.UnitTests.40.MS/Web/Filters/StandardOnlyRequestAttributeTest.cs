using System;
using System.Reflection;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Web.Filters
{
	[TestClass]
	public class StandardOnlyRequestAttributeTest
	{
		[TestMethod]
		public void CheckingForValidRequestReturnsFalseForAjax()
		{
			//Arrange
			var ctx = Isolate.Fake.Instance<ControllerContext>();
			Isolate.WhenCalled(() => ctx.HttpContext.Request.IsAjaxRequest()).WillReturn(false);
			var method = Isolate.Fake.Instance<MethodInfo>();

			//Act
			var attrib = new StandardOnlyRequestAttribute();
			var result = attrib.IsValidForRequest(ctx, method);

			//Assert
			Assert.IsTrue(result);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CheckingForValidRequestReturnsTrueForAjax()
		{
			//Arrange
			var ctx = Isolate.Fake.Instance<ControllerContext>();
			Isolate.WhenCalled(() => ctx.HttpContext.Request.IsAjaxRequest()).WillReturn(true);
			var method = Isolate.Fake.Instance<MethodInfo>();

			//Act
			var attrib = new StandardOnlyRequestAttribute();
			var result = attrib.IsValidForRequest(ctx, method);

			//Assert
			Assert.IsFalse(result);

			Isolate.CleanUp();
		}
	}
}
