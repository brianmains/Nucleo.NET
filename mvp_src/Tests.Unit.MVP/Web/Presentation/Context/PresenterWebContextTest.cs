﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Web.Core;


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
			var context = Isolate.Fake.Instance<IServicesContext>();
			var registry = Isolate.Fake.Instance<ISingletonManager>();

			//Act
			ctx.Context = context;
			ctx.Singletons = registry;

			//Assert
			Assert.AreEqual(context, ctx.Context);
			Assert.AreEqual(registry, ctx.Singletons);

			Isolate.CleanUp();
		}
	}
}
