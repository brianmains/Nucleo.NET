using System;
using System.Collections.Generic;
using TypeMock.ArrangeActAssert;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Nucleo.Reflection;
using Nucleo.Web;
using Nucleo.Web.Mvc.ButtonControls;

namespace Nucleo.Web.Mvc.Content
{
	[TestClass]
	public class ContentManagerTest
	{
		#region " Tests "

		[TestMethod]
		public void RegisteringComponentAddsFrameworkScripts()
		{
			//Arrange
			var contentManagerFake = Isolate.Fake.Instance<ContentManager>(Members.CallOriginal);
			var builderFake = Isolate.Fake.Instance<ButtonControlBuilder>();

			//Act
			contentManagerFake.RegisterComponent(builderFake);
			var registrar = contentManagerFake.NonPublic().Property("Registrar").GetValue<ContentRegistrar>();

			//Assert
			StringAssert.StartsWith(registrar.GetScripts()[0].Name, "Nucleo.Framework");
		}

		#endregion
	}
}
