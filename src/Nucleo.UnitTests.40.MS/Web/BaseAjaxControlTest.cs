using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.EventArguments;
using Nucleo.TestingTools;
using Nucleo.Web.Pages;
using Nucleo.Web.Styles;
using Nucleo.Web.Core;


namespace Nucleo.Web
{
	[TestClass]
	public class BaseAjaxControlTest
	{
		#region " Supporting Classes "

		protected class FakeAjaxControl : BaseAjaxControl
		{
			public ScriptManager Manager
			{
				get;
				set;
			}



			public FakeAjaxControl() : base() { }

			public FakeAjaxControl(ScriptManager manager)
			{
				this.Manager = manager;
			}
			
			protected override void GetAjaxScriptDescriptors(IContentRegistrar registrar)
			{
				
			}

			protected override void GetAjaxScriptReferences(IContentRegistrar registrar)
			{
				
			}

			protected override ScriptManager GetScriptManager(Page page)
			{
				return this.Manager ?? new ScriptManager();
			}
		}

		#endregion
		


		#region " Tests "

		[TestMethod]
		public void InitializingControlWithAjaxManagerRegistersComponent()
		{
			//Arrange
			var ctl = new FakeAjaxControl();
			var mgr = new NucleoAjaxManager();
			var singleton = Isolate.Fake.Instance<WebSingletonManager>();
			Isolate.WhenCalled(() => singleton.GetEntry<NucleoAjaxManager>()).WillReturn(mgr);

			var page = new FakePage(new Control[] { mgr, ctl })
			{
				CurrentContext = new PageRequestContext { Singletons = singleton }
			};

			//Act
			page.FireEvent(PageEvent.Init);

			//Assert
			Assert.AreEqual(1, mgr.Components.Count);

			Isolate.CleanUp();
		}
		
		[TestMethod]
		public void InitializingControlWithoutAjaxManagerDoesntThrowException()
		{
			try
			{
				FakeAjaxControl control = new FakeAjaxControl { RegisterWithScriptManager = false };
				var page = new FakePage(control);

				page.FireEvent(PageEvent.Init);
			}
			catch (Exception ex)
			{
				Assert.Fail("The init event threw an exception, possibly because it required an AjaxManager to be on the page");
			}
		}

		[TestMethod]
		public void InitializingControlWithStylesheetManagerRegistersComponent()
		{
			//Arrange
			var ctl = new FakeAjaxControl() { EnableCustomTheming = true };
			var mgr = new StylesheetManager();
			var singleton = Isolate.Fake.Instance<WebSingletonManager>();
			Isolate.WhenCalled(() => singleton.GetEntry<StylesheetManager>()).WillReturn(mgr);

			var page = new FakePage(new Control[] { ctl, mgr })
			{
				CurrentContext = new PageRequestContext { Singletons = singleton }
			};

			//Act
			page.FireEvent(PageEvent.Init);

			//Assert
			Assert.AreEqual(1, mgr.Components.Count);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void PreRenderValidatesParameters()
		{
			//Arrange
			var ctl = new FakeAjaxControl { RegisterWithScriptManager = false };
			var page = new FakePage(ctl);
			var set = false;

			ctl.ValidateState += delegate(object sender, ValidateEventArgs e)
			{
				set = true;
			};

			//Act
			page.FireEvent(PageEvent.PreRender);

			//Assert
			Assert.IsTrue(set);
		}

		[TestMethod]
		public void SettingRegisterWithScriptManagerToFalseDoesntRegisterControl()
		{
			//Arrange
			var mgr = Isolate.Fake.Instance<ScriptManager>();
			Isolate.WhenCalled(() => mgr.RegisterScriptControl<BaseAjaxControl>(null)).IgnoreCall();

			var ajaxControl = new FakeAjaxControl(mgr) { RegisterWithScriptManager = false };
			var page = new FakePage(ajaxControl);

			//Act
			page.FireEvent(PageEvent.PreRender);

			//Assert
			Isolate.Verify.WasNotCalled(() => { mgr.RegisterScriptControl<BaseAjaxControl>(null); });

			Isolate.CleanUp();
		}

		[TestMethod]
		public void SettingRegisterWithScriptManagerToTrueDoesRegisterControl()
		{
			//Arrange
			var mgr = Isolate.Fake.Instance<ScriptManager>();
			Isolate.WhenCalled(() => mgr.RegisterScriptControl<BaseAjaxControl>(null)).IgnoreCall();

			var ajaxControl = new FakeAjaxControl(mgr) { RegisterWithScriptManager = true };
			var page = new FakePage(ajaxControl);

			//Act
			page.FireEvent(PageEvent.PreRender);

			//Assert
			Isolate.Verify.WasCalledWithAnyArguments(() => { mgr.RegisterScriptControl<BaseAjaxControl>(null); });

			Isolate.CleanUp();
		}

		[TestMethod]
		public void ValidationThrowsExceptionWhenIncorrect()
		{
			//Arrange
			var ctl = new FakeAjaxControl { RegisterWithScriptManager = false };
			var page = new FakePage(ctl);

			ctl.ValidateState += delegate(object sender, ValidateEventArgs e)
			{
				e.IsValid = false;
			};

			//Act

			//Assert
			ExceptionTester.CheckException(true, (src) => { page.FireEvent(PageEvent.PreRender); });
		}

		#endregion
	}
}
