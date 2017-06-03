using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.TestingTools;


namespace Nucleo.Web.ClientSettings
{
	[TestClass]
	public class WebServiceSettingsTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingEmptySettingsAssignsNothing()
		{
			//Arrange
			var settings = default(WebServiceSettings);

			//Act
			settings = new WebServiceSettings();

			//Assert
			Assert.AreEqual(0, settings.TimeLimit);
			Assert.IsNull(settings.Url);
		}

		[TestMethod]
		public void CreatingEmptySettingsWithNoPropertyUsesDefault()
		{
			//Arrange
			var settings = new WebServiceSettings();
			var registrar = Isolate.Fake.Instance<IContentRegistrar>();
			var descriptor = new FakeDescriptor();

			//Act
			((IScriptComponent)settings).RegisterAjaxDescriptors(registrar, descriptor);

			//Assert
			Assert.IsTrue(descriptor.References.ContainsKey("webServiceSettings"));

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CreatingEmptySettingsWithPropertyUsesCustomProperty()
		{
			//Arrange
			var settings = new WebServiceSettings("test");
			var registrar = Isolate.Fake.Instance<IContentRegistrar>();
			var descriptor = new FakeDescriptor();

			//Act
			((IScriptComponent)settings).RegisterAjaxDescriptors(registrar, descriptor);

			//Assert
			Assert.IsTrue(descriptor.References.ContainsKey("test"));

			Isolate.CleanUp();
		}

		[TestMethod]
		public void SettingUrlWithAsmxWorksOK()
		{
			//Arrange
			var settings = Isolate.Fake.Instance<WebServiceSettings>(Members.CallOriginal);

			//Act
			settings.Url = "page.asmx";

			//Assert
			Assert.AreEqual("page.asmx", settings.Url);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void SettingUrlWithAspxWorksOK()
		{
			//Arrange
			var settings = Isolate.Fake.Instance<WebServiceSettings>(Members.CallOriginal);

			//Act
			settings.Url = "page.aspx";

			//Assert
			Assert.AreEqual("page.aspx", settings.Url);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void SettingUrlWithInvalidExtensionThrowsError()
		{
			//Arrange
			var settings = Isolate.Fake.Instance<WebServiceSettings>(Members.CallOriginal);

			//Act

			//Assert
			ExceptionTester.CheckException(true, (src) => { settings.Url = "page.ashx"; }, "invalid extension didn't throw error");

			Isolate.CleanUp();
		}

		[TestMethod]
		public void SettingUrlWithNoExtensionThrowsError()
		{
			//Arrange
			var settings = Isolate.Fake.Instance<WebServiceSettings>(Members.CallOriginal);

			//Act

			//Assert
			ExceptionTester.CheckException(true, (src) => { settings.Url = "page"; }, "no extension didn't throw error");

			Isolate.CleanUp();
		}

		[TestMethod]
		public void SettingUrlWithSvcWorksOK()
		{
			//Arrange
			var settings = Isolate.Fake.Instance<WebServiceSettings>(Members.CallOriginal);

			//Act
			settings.Url = "page.svc";

			//Assert
			Assert.AreEqual("page.svc", settings.Url);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void SettingUrlWithNullDoesNothing()
		{
			//Arrange
			var settings = Isolate.Fake.Instance<WebServiceSettings>(Members.CallOriginal);

			//Act
			settings.Url = null;

			//Assert
			Assert.AreEqual(null, settings.Url);
		}

		#endregion
	}
}
