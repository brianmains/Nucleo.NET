using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.TestingTools;
using Nucleo.Web.Action;
using Nucleo.Web.Action.Configuration;
using Nucleo.Web.Mvc.Configuration;


namespace Nucleo.Web.HtmlHelpers
{
	[TestClass]
	public class NucleoConfiguredActionExtensionsTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingNoConfiguredRouteProviderDefaultsToConfigurationFiles()
		{
			//Arrange
			var section = new MvcSettingsSection();
			section.RouteConfiguredActions.Add(new RouteConfiguredActionElement
			{
				Name = "Inbox",
				ControllerName = "Notifications",
				ActionName = "Messages"
			});
			section.RouteConfiguredActions.Add(new RouteConfiguredActionElement
			{
				Name = "My Details",
				ControllerName = "Me",
				ActionName = "Details"
			});

			Isolate.Fake.StaticMethods(typeof(MvcSettingsSection));
			Isolate.WhenCalled(() => MvcSettingsSection.Instance).WillReturn(section);

			var urlHelperFake = Isolate.Fake.Instance<UrlHelper>();
			Isolate.WhenCalled(() => urlHelperFake.Action("", "")).WillReturn("/Notifications/Messages");

			//Act
			var route = NucleoConfiguredActionExtensions.ConfiguredAction(urlHelperFake, "Inbox");

			//Assert
			Assert.AreEqual("/Notifications/Messages", route);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingMissingRouteThrowsException()
		{
			//Arrange
			var providerFake = Isolate.Fake.Instance<ConfiguredActionProvider>();
			Isolate.WhenCalled(() => providerFake.GetRoute(null)).WillReturn(null);

			var section = new MvcSettingsSection();
			Isolate.WhenCalled(() => section.Create<ConfiguredActionProvider>(null)).WillReturn(providerFake);

			Isolate.Fake.StaticMethods(typeof(MvcSettingsSection));
			Isolate.WhenCalled(() => MvcSettingsSection.Instance).WillReturn(section);

			var urlHelperFake = Isolate.Fake.Instance<UrlHelper>();

			//Act

			//Assert
			ExceptionTester.CheckException(true, (src) =>
			{
				NucleoConfiguredActionExtensions.ConfiguredAction(urlHelperFake, "Test");
			});

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingUrlsWorksOK()
		{
			//Arrange
			var section = new MvcSettingsSection();
			section.RouteConfiguredActions.Add(new RouteConfiguredActionElement
			{
				Name = "Inbox",
				ControllerName = "Notifications",
				 ActionName = "Messages"
			});
			section.RouteConfiguredActions.Add(new RouteConfiguredActionElement
			{
				Name = "My Details",
				ControllerName = "Me",
				ActionName = "Details"
			});

			Isolate.Fake.StaticMethods(typeof(MvcSettingsSection));
			Isolate.WhenCalled(() => MvcSettingsSection.Instance).WillReturn(section);

			var urlHelperFake = Isolate.Fake.Instance<UrlHelper>();
			Isolate.WhenCalled(() => urlHelperFake.Action("", "")).WillReturn("/Notifications/Messages");

			//Act
			var route = NucleoConfiguredActionExtensions.ConfiguredAction(urlHelperFake, "Inbox");

			//Assert
			Assert.AreEqual("/Notifications/Messages", route);

			Isolate.CleanUp();
		}

		#endregion
	}
}
