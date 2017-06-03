using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Reflection;
using Nucleo.Web.ButtonControls;
using Nucleo.Web.Core;
using Nucleo.Web.Controls;
using Nucleo.Web.Controls.Configuration;
using Nucleo.Web.Pages;
using Nucleo.Web.Tags;

using Nucleo.Context.Services;
using Nucleo.Web.Context.Services;


namespace Nucleo.Web
{
	[TestClass]
	public class NucleoAjaxManagerTest : FakePage
	{
		#region " Supporting Classes "

		[
		WebScriptMetadata(typeof(FakeScriptMetadata)),
		WebRenderer(typeof(FakeWebRenderer)),
		WebLegacyRenderer(typeof(FakeWebLegacyRenderer))
		]
		protected class FakeAjaxControl : BaseAjaxControl
		{
			protected override void GetAjaxScriptDescriptors(IContentRegistrar registrar) { }

			protected override void GetAjaxScriptReferences(IContentRegistrar registrar) { }
		}

		protected class FakeScriptMetadata : WebScriptMetadata
		{
			public override ScriptReferencingRequestDetailsCollection GetPrimaryScripts()
			{
				return new ScriptReferencingRequestDetailsCollection
				{
					new ScriptReferencingRequestDetails("fake.js", ScriptMode.Release)
				};
			}
		}

		protected class FakeWebRenderer : WebRenderer
		{
			public override TagElement Render() { return new TagElement("SPAN"); }
		}

		protected class FakeWebLegacyRenderer : WebLegacyRenderer
		{
			public override void Render(BaseControlWriter writer) { }
		}

		protected class NewScriptMetadata : WebScriptMetadata
		{
			public override ScriptReferencingRequestDetailsCollection GetPrimaryScripts()
			{
				return new ScriptReferencingRequestDetailsCollection
				{
					new ScriptReferencingRequestDetails("new.js", ScriptMode.Release)
				};
			}
		}

		protected class NewWebRenderer : WebRenderer
		{
			public override TagElement Render() { return new TagElement("DIV"); }
		}

		protected class NewWebLegacyRenderer : WebLegacyRenderer
		{
			public override void Render(BaseControlWriter writer) { }
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void AddedNucleoServiceReferencesCopiesToScriptManagerWhenAuthenticated()
		{
			//Arrange
			var scriptManager = new ScriptManager();
			Isolate.Fake.StaticMethods(typeof(ScriptManager));
			Isolate.WhenCalled(() => ScriptManager.GetCurrent(null)).WillReturn(scriptManager);

			var ctx = Isolate.Fake.Instance<IWebContext>();
			Isolate.WhenCalled(() => ctx.UserSecurity.IsLoggedIn()).WillReturn(true);

			var ajax = new NucleoAjaxManager();
			var page = new FakePage(ajax)
			{
				CurrentContext = new PageRequestContext { Context = ctx }
			};

			ajax.Services.Add(new NucleoServiceReference("a.asmx") { InclusionOptions = ServiceReferenceIncludeOptions.Any });
			ajax.Services.Add(new NucleoServiceReference("b.asmx") { InclusionOptions = ServiceReferenceIncludeOptions.UserAuthenticated });
			ajax.Services.Add(new NucleoServiceReference("c.asmx") { InclusionOptions = ServiceReferenceIncludeOptions.UserUnauthenticated });

			//Act
			page.FireEvent(PageEvent.Load);

			//Assert
			Assert.AreEqual(2, scriptManager.Services.Count);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void AddedNucleoServiceReferencesCopiesToScriptManagerWhenUnauthenticated()
		{
			//Arrange
			var scriptManager = new ScriptManager();
			Isolate.Fake.StaticMethods(typeof(ScriptManager));
			Isolate.WhenCalled(() => ScriptManager.GetCurrent(null)).WillReturn(scriptManager);

			var ctx = Isolate.Fake.Instance<IWebContext>();
			Isolate.WhenCalled(() => ctx.UserSecurity.IsLoggedIn()).WillReturn(false);

			var ajax = new NucleoAjaxManager();
			var page = new FakePage(ajax)
			{
				CurrentContext = new PageRequestContext { Context = ctx }
			};

			ajax.Services.Add(new NucleoServiceReference("a.asmx") { InclusionOptions = ServiceReferenceIncludeOptions.Any });
			ajax.Services.Add(new NucleoServiceReference("b.asmx") { InclusionOptions = ServiceReferenceIncludeOptions.UserUnauthenticated });
			ajax.Services.Add(new NucleoServiceReference("c.asmx") { InclusionOptions = ServiceReferenceIncludeOptions.UserAuthenticated });

			//Act
			page.FireEvent(PageEvent.Load);

			//Assert
			Assert.AreEqual(2, scriptManager.Services.Count);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void AddedServiceReferencesCopiesToScriptManager()
		{
			//Arrange
			var scriptManager = new ScriptManager();
			Isolate.Fake.StaticMethods(typeof(ScriptManager));
			Isolate.WhenCalled(() => ScriptManager.GetCurrent(null)).WillReturn(scriptManager);

			var ctx = Isolate.Fake.Instance<IWebContext>();
			Isolate.WhenCalled(() => ctx.UserSecurity.IsLoggedIn()).WillReturn(false);

			var ajax = new NucleoAjaxManager();
			var page = new FakePage(ajax)
			{
				CurrentContext = new PageRequestContext { Context = ctx }
			};
			ajax.Services.Add(new ServiceReference("a.asmx"));
			ajax.Services.Add(new ServiceReference("b.asmx"));

			//Act
			page.FireEvent(PageEvent.Load);

			//Assert
			Assert.AreEqual(2, scriptManager.Services.Count);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CreatingDescriptorCreatesBehaviorDescriptorForBehavior()
		{
			//Arrange
			var buttonExtender = new ButtonEnabledExtender();

			var scriptDetails = Isolate.Fake.Instance<ScriptDescriptionRequestDetails>();
			Isolate.WhenCalled(() => scriptDetails.ClientType).WillReturn("Nucleo.Web.ButtonControls.ButtonEnabledExtender");
			Isolate.WhenCalled(() => scriptDetails.ControlReference).WillReturn(buttonExtender);
			Isolate.WhenCalled(() => scriptDetails.RequestObjectType).WillReturn(typeof(ButtonEnabledExtender));
			Isolate.WhenCalled(() => scriptDetails.TargetID).WillReturn("ctl100_extender");

			//Act
			var descriptor = NucleoAjaxManager.CreateDescriptor(scriptDetails);

			//Assert
			Assert.IsInstanceOfType(descriptor, typeof(NucleoScriptBehaviorDescriptor));

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CreatingDescriptorCreatesControlDescriptorForControl()
		{
			//Arrange
			var link = new Link();

			var scriptDetails = Isolate.Fake.Instance<ScriptDescriptionRequestDetails>();
			Isolate.WhenCalled(() => scriptDetails.ClientType).WillReturn("Nucleo.Web.Controls.Link");
			Isolate.WhenCalled(() => scriptDetails.ControlReference).WillReturn(link);
			Isolate.WhenCalled(() => scriptDetails.RequestObjectType).WillReturn(typeof(Link));
			Isolate.WhenCalled(() => scriptDetails.TargetID).WillReturn("ctl100_link");

			//Act
			var descriptor = NucleoAjaxManager.CreateDescriptor(scriptDetails);

			//Assert
			Assert.IsInstanceOfType(descriptor, typeof(NucleoScriptControlDescriptor));

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CreatingDescriptorForNonScriptControlThrowsException()
		{
			var textbox = new TextBox();

			var scriptDetails = Isolate.Fake.Instance<ScriptDescriptionRequestDetails>();
			Isolate.WhenCalled(() => scriptDetails.ControlReference).WillReturn(textbox);
			Isolate.WhenCalled(() => scriptDetails.RequestObjectType).WillReturn(typeof(TextBox));
			Isolate.WhenCalled(() => scriptDetails.TargetID).WillReturn("ctl100_box");

			try
			{
				var descriptor = NucleoAjaxManager.CreateDescriptor(scriptDetails);
				Assert.Fail("An exception didn't throw when creating a descriptor with an invalid control");
			}
			catch (InvalidCastException ex)
			{
				Assert.IsNotNull(ex, "Exception is null");
				Assert.AreEqual("The control being described must be a script or extender control", ex.Message);
			}

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingComponentsByReferenceNameReturnsActualReferences()
		{
			FakeAjaxControl control = new FakeAjaxControl();
			control.ReferenceName = "TestRef";

			NucleoAjaxManager manager = new NucleoAjaxManager();
			manager.Components.Add(control);

			var components = manager.GetByReferenceName("TestRef");
			Assert.AreEqual(1, components.Count);
			Assert.IsInstanceOfType(components[0], typeof(FakeAjaxControl));
		}

		[TestMethod]
		public void GettingPostbackHyperlinkReturnsCorrectUrl()
		{
			Isolate.Fake.StaticMethods<NucleoAjaxManager>(Members.CallOriginal);
			Isolate.NonPublic.WhenCalled(typeof(NucleoAjaxManager), "GetPostbackClientHyperlinkInternal").WillReturn("__doPostBack('button', '')");

			string script = NucleoAjaxManager.GetPostbackClientHyperlink(this, "");

			Assert.AreEqual("__doPostBack('button', '')", script);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingPostbackHyperlinkReturnsCorrectUrl2()
		{
			//Arrange
			Isolate.Fake.StaticMethods<NucleoAjaxManager>(Members.CallOriginal);
			Isolate.NonPublic.WhenCalled(typeof(NucleoAjaxManager), "GetPostbackClientHyperlinkInternal").WillReturn("__doPostBack('button', '')");

			//Act
			string script = NucleoAjaxManager.GetPostbackClientHyperlink(this, "", true);

			//Assert
			Assert.AreEqual("__doPostBack('button', '')", script);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void RegisteringCssFilesAddsFilesToHeader()
		{
			//Arrange
			var page = Isolate.Fake.Instance<FakePage>(Members.CallOriginal);
			page.AddAjaxFrameworkControls();
			var header = new HtmlHead();
			Isolate.WhenCalled(() => page.Header).WillReturn(header);

			var mgr = (NucleoAjaxManager)page.Controls[1];
			mgr.Registrar.AddCssReference(new CssReferenceRequestDetails("scripts.css"));
			mgr.Registrar.AddCssReference(new CssReferenceRequestDetails("controlskins.css"));

			//Act
			mgr.NonPublic().Method("AddCssReferencesInternal").Invoke();

			//Assert
			Assert.AreEqual(2, page.Header.Controls.Count);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void ResolvingUrlInTestFormatWithNoContextReturnsSameUrl()
		{
			//Arrange
			
			//Act
			var url = NucleoAjaxManager.ResolveClientUrl("myurl.png");

			//Assert
			Assert.AreEqual("myurl.png", url);
		}

		#endregion
	}
}
