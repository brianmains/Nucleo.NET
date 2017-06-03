using Nucleo.Presentation;
using Nucleo.Presentation.Context.Caching;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Presentation.Creation;

namespace Nucleo.Presentation
{
	[TestClass]
	public class PresenterOptionsTest
	{
		[TestMethod]
		public void GettingAndSettingPropertiesWorksOK()
		{
			//Arrange
			var cache = Isolate.Fake.Instance<IPresenterContextCache>();
			var creator = Isolate.Fake.Instance<IPresenterCreator>();
			var options = new PresenterOptions();

			//Act
			options.ContextCache = cache;
			options.Creator = creator;

			//Assert
			Assert.AreEqual(cache, options.ContextCache);
			Assert.AreEqual(creator, options.Creator);
		}
	}
}
