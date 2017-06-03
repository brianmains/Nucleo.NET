using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Models;
using Nucleo.Web.Core;


namespace Nucleo.Web.Controllers
{
	[TestClass]
	public class MvcRequestContextTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingAndSettingPropsWorksOK()
		{
			//Arrange
			var ctx = Isolate.Fake.Instance<IWebContext>();
			var mgr = Isolate.Fake.Instance<ModelInjectionManager>();

			//Act
			var cc = new MvcRequestContext();
			cc.Context = ctx;
			cc.ModelInjection = mgr;

			//Assert
			Assert.AreEqual(ctx, cc.Context);
			Assert.AreEqual(mgr, cc.ModelInjection);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void LoadingWebContextWorksOK()
		{
			//Arrange
			var ctx = Isolate.Fake.Instance<IWebContext>();
			Isolate.WhenCalled(() => ctx.CurrentHandler).WillReturn("X");

			Isolate.Fake.StaticMethods(typeof(WebContext));
			Isolate.WhenCalled(() => WebContext.GetCurrent()).WillReturn(ctx);

			//Act
			var cc = new MvcRequestContext { Context = ctx };

			//Assert
			Assert.AreEqual("X", cc.Context.CurrentHandler);

			Isolate.CleanUp();
		}

		#endregion
	}
}
