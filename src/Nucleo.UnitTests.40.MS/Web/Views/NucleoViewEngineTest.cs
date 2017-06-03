using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Web.Mvc.Configuration;
using Nucleo.Web.Views.Configuration;


namespace Nucleo.Web.Views
{
	[TestClass]
	public class NucleoViewEngineTest : NucleoViewEngine
	{
		#region " Tests "

		[TestMethod]
		public void InitializingViewEngineSetsUpCorrectPartialViewPaths()
		{
			//Arrange
			var section = new MvcSettingsSection();
			section.ViewSettings.PartialViewPath = "~/Views/Test/";
			section.ViewSettings.SearchPartialViewSubfolders = false;

			Isolate.Fake.StaticMethods(typeof(MvcSettingsSection));
			Isolate.WhenCalled(() => MvcSettingsSection.Instance).WillReturn(section);

			//Act
			var engine = new NucleoViewEngineTest();
			engine.InitializePaths();

			//Assert
			Assert.AreEqual(2, engine.PartialViewLocationFormats.Where(i => i.EndsWith(".ascx")).Count());

			Isolate.CleanUp();
		}

		[TestMethod]
		public void InitializingViewEngineSetsUpCorrectViewPaths()
		{
			//Arrange
			var section = new MvcSettingsSection();
			section.ViewSettings.ViewPath = "~/Views/Test/";

			Isolate.Fake.StaticMethods(typeof(MvcSettingsSection));
			Isolate.WhenCalled(() => MvcSettingsSection.Instance).WillReturn(section);

			//Act
			var engine = new NucleoViewEngineTest();
			engine.InitializePaths();

			//Assert
			Assert.AreEqual(2, engine.ViewLocationFormats.Where(i => i.EndsWith(".aspx")).Count());

			Isolate.CleanUp();
		}

		[TestMethod]
		public void InitializingViewEngineWithNoConfigSetsUpDefaultPaths()
		{
			//Arrange
			Isolate.WhenCalled(() => MvcSettingsSection.Instance).WillReturn(null);

			//Act
			var engine = new NucleoViewEngineTest();
			engine.InitializePaths();

			//Assert
			Assert.AreEqual("~/Views/{1}/{0}.aspx", engine.ViewLocationFormats[0]);
			Assert.AreEqual("~/Views/Shared/{0}.aspx", engine.ViewLocationFormats[1]);
			Assert.AreEqual("~/Views/{1}/{0}.ascx", engine.PartialViewLocationFormats[0]);
			Assert.AreEqual("~/Views/Shared/{0}.ascx", engine.PartialViewLocationFormats[1]);

			Isolate.CleanUp();
		}

		#endregion
	}
}
