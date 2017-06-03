using System;
using System.Web.UI;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Web.Pages;
using Nucleo.TestingTools;
using Nucleo.Web.Scripts.Configuration;


namespace Nucleo.Web.Scripts
{
	[TestClass]
	public class ReferenceScriptManagerTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingCommonFrameworkScriptsReturnsCorrectReferences()
		{
			//Arrange

			//Act
			var script = ReferenceScriptManager.GetFrameworkScript("Nucleo.Common", ScriptMode.Debug, ScriptFramework.WebForms);

			//Assert
			Assert.IsNotNull(script);
			Assert.AreEqual("Nucleo.Common.js", script.Name);
			Assert.AreEqual(typeof(BaseAjaxControl).Assembly.FullName, script.Assembly);
		}

		[TestMethod]
		public void GettingCheckFrameworkScriptsReturnsCorrectReferences()
		{
			//Arrange

			//Act
			var script = ReferenceScriptManager.GetScript(typeof(Nucleo.Web.Controls.Check), ScriptMode.Debug);

			Assert.IsNotNull(script);
			Assert.AreEqual("Nucleo.Web.Controls.Check.js", script.Name);
			Assert.AreEqual(typeof(Nucleo.Web.Controls.Check).Assembly.FullName, script.Assembly);
		}

		[TestMethod]
		public void GettingExternalScriptByNameReturnsCorrectReference()
		{
			//Arrange
			var sectionFake = Isolate.Fake.Instance<ExternalScriptSettingsSection>(Members.CallOriginal);
			Isolate.WhenCalled(() => sectionFake.ExternalScripts).WillReturn(
				new ExternalScriptElementCollection
				{
					new ExternalScriptElement("First", "Firstscript.js", "Firstscriptrelease.js")
				});

			Isolate.Fake.StaticMethods(typeof(ExternalScriptSettingsSection));
			Isolate.WhenCalled(() => ExternalScriptSettingsSection.Instance).WillReturn(sectionFake);

			//Act
			var script1 = ReferenceScriptManager.GetExternalScript("First");

			//Assert
			Assert.AreEqual("Firstscript.js", script1.Path);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingExternalScriptWithEmptyKeyThrowsException()
		{
			//Assert

			ExceptionTester.CheckException(true, (s) => { ReferenceScriptManager.GetExternalScript(string.Empty); });
		}

		[TestMethod]
		public void GettingExternalScriptWithNoConfigurationReturnsNull()
		{
			//Arrange
			Isolate.Fake.StaticMethods(typeof(ExternalScriptSettingsSection));
			Isolate.WhenCalled(() => ExternalScriptSettingsSection.Instance).WillReturn(null);

			//Act
			var reference = ReferenceScriptManager.GetExternalScript("First");

			//Assert
			Assert.IsNull(reference);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingExternalScriptWithNoMatchingElementReturnsNull()
		{
			//Arrange
			var sectionFake = Isolate.Fake.Instance<ExternalScriptSettingsSection>();
			Isolate.Fake.StaticMethods(typeof(ExternalScriptSettingsSection));

			Isolate.WhenCalled(() => sectionFake.ExternalScripts).WillReturn(
				new ExternalScriptElementCollection
				{
					new ExternalScriptElement("First", "FirstScript", "FirstScriptRelease"),
					new ExternalScriptElement("Second", "SecondScript", "SecondScriptRelease")
				});

			Isolate.WhenCalled(() => ExternalScriptSettingsSection.Instance).WillReturn(sectionFake);

			//Act
			var script1 = ReferenceScriptManager.GetExternalScript("Third");
			var script2 = ReferenceScriptManager.GetExternalScript("Zero");

			//Assert
			Assert.IsNull(script1, "Script 1 isn't null");
			Assert.IsNull(script2, "Script 2 isn't null");

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingExternalScriptWithNullKeyThrowsException()
		{
			try
			{
				ReferenceScriptManager.GetExternalScript(null);
				Assert.Fail("Null key didn't throw exception");
			}
			catch (ArgumentNullException ex)
			{
				Assert.AreEqual("key", ex.ParamName);
			}
		}

		[TestMethod]
		public void GettingScriptWorksOK()
		{
			//Act
			var script = ReferenceScriptManager.GetScript(typeof(Nucleo.Web.Controls.Check), ScriptMode.Release);

			//Assert
			Assert.AreEqual(typeof(Nucleo.Web.Controls.Check).FullName + ".js", script.Name);
		}

		[TestMethod]
		public void InvalidScriptReferenceReturnsSameType()
		{
			//Arrange
			//Act
			var script = ReferenceScriptManager.GetFrameworkScript("SFSDF", ScriptMode.Debug, ScriptFramework.WebForms);

			//Assert
			Assert.IsTrue(script.Name.StartsWith("SFSDF"));
		}

		[TestMethod]
		public void PassingInEmptyStringKeyThrowsException()
		{
			ExceptionTester.CheckException(true, (src) => { ReferenceScriptManager.GetFrameworkScript(string.Empty, ScriptMode.Debug, ScriptFramework.WebForms); });
		}

		[TestMethod]
		public void PassingInNullKeyThrowsException()
		{
			ExceptionTester.CheckException(true, (src) => { ReferenceScriptManager.GetFrameworkScript((string)null, ScriptMode.Debug, ScriptFramework.WebForms); });
			ExceptionTester.CheckException(true, (src) => { ReferenceScriptManager.GetScript((Type)null, ScriptMode.Debug); });
		}

		#endregion
	}
}
