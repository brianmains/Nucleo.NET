using Nucleo.Presentation;
using Nucleo.Presentation;
using Nucleo.Presentation.Caching;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

namespace Nucleo.Presentation
{
	[TestClass]
	public class PresenterCacheOptionsTest
	{
		[TestMethod]
		public void GettingAndSettingPropertiesWorksOK()
		{
			//Arrange
			var options = new PresenterCacheOptions();
			var ctx = Isolate.Fake.Instance<IPresenterContextCache>();

			//Act
			options.ContextCache = ctx;

			//Assert
			Assert.AreEqual(ctx, options.ContextCache);

			Isolate.CleanUp();
		}
	}
}
