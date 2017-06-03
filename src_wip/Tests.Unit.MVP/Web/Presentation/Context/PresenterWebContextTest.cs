using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Services;


namespace Nucleo.Web.Presentation.Context
{
	[TestClass]
	public class PresenterWebContextTest
	{
		[TestMethod]
		public void GettingAndSettingPropertiesWorksOK()
		{
			//Arrange
			var ctx = new PresenterWebContext();
			var registry = Isolate.Fake.Instance<IStaticInstanceManager>();

			//Act
			ctx.Singletons = registry;

			//Assert
			Assert.AreEqual(registry, ctx.Singletons);

			Isolate.CleanUp();
		}
	}
}
