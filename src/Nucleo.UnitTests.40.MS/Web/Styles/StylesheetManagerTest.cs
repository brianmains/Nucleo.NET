using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Web.Core;
using Nucleo.Web.Pages;
using Nucleo.Web.Pages.Testing;
using Nucleo.TestingTools;


namespace Nucleo.Web.Styles
{
	[TestClass]
	public class StylesheetManagerTest
	{
		#region " Tests "

		[TestMethod]
		public void AddingComponentsWorksOK()
		{
			//Arrange
			var ctl = Isolate.Fake.Instance<BaseAjaxControl>();
			var styles = new StylesheetManager();

			//Act
			styles.AddComponent(ctl);

			//Assert
			Assert.AreEqual(1, styles.Components.Count);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void DuplicateReferencesThrowsAnException()
		{
			//Arrange
			var singletons = Isolate.Fake.Instance<IWebSingletonManager>();
			Isolate.WhenCalled(() => singletons.HasEntry<StylesheetManager>()).WillReturn(true);

			var mgr = new StylesheetManager();
			var page = new FakePage(mgr)
			{
				CurrentContext = new PageRequestContext { Singletons = singletons }
			};

			//Act

			//Assert
			ExceptionTester.CheckException(true, (src) => { page.FireEvent(PageEvent.Init); });

			Isolate.CleanUp();
		}

		[TestMethod]
		public void NoHeaderThrowsException()
		{
			//Arrange
			var styles = new StylesheetManager();
			var pages = new PageRunner();
			pages.AddControl(styles);

			//Act
			

			//Assert
			ExceptionTester.CheckException(true, (s) => { pages.FireEvent(PageControllerEvent.ValidateState); });

			Isolate.CleanUp();
		}

		#endregion
	}
}
