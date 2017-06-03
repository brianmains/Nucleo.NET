using System;
using System.Web;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Web.Services
{
	[TestClass]
	public class PresenterServiceBinderTest
	{
		[TestMethod]
		public void CreatingPresenterServiceBinderDoesntThrowException()
		{
			var context =Isolate.Fake.Instance<HttpContextBase>();

			new PresenterServiceBinder(context);

			Isolate.CleanUp();
		}
	}
}
