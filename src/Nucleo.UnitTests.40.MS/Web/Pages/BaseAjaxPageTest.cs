using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.TestingTools;
using Nucleo.Web.Description;
using Nucleo.Web.Pages.Widgets;


namespace Nucleo.Web.Pages
{
	[TestClass]
	public class BaseAjaxPageTest : BaseAjaxPage
	{
		private IContentRegistrar _registrar;



		#region " Test Classes "

		public class FakeWidget : PageWidget
		{
			public bool CssReferred { get; set; }
			public bool Described { get; set; }
			public bool ScriptReferred { get; set; }
			
			

			protected override void RegisterAjaxDescriptors(IContentRegistrar registrar, ComponentDescriptor currentDescriptor)
			{
				base.RegisterAjaxDescriptors(registrar, currentDescriptor);

				this.Described = true;
			}

			protected override void RegisterAjaxReferences(IContentRegistrar registrar)
			{
				base.RegisterAjaxReferences(registrar);

				this.ScriptReferred = true;
			}

			protected override void RegisterCssReferences(IContentRegistrar registrar)
			{
				base.RegisterCssReferences(registrar);

				this.CssReferred = true;
			}
		}

		#endregion



		#region " Properties "

		private IContentRegistrar Registrar
		{
			get
			{
				if (_registrar == null)
					_registrar = new ContentRegistrar();

				return _registrar;
			}
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Test helper method.
		/// </summary>
		/// <param name="widget"></param>
		public void AddWidget(PageWidget widget)
		{
			this.Widgets.Add(widget);
		}

		protected override IContentRegistrar GetContentRegistrar()
		{
			return new ContentRegistrar();
		}



		#endregion



		#region " Tests "

		[TestMethod]
		public void DescribingThePageDescribesAnyWidgets()
		{
			//Arrange
			var page = new BaseAjaxPageTest();
			var widget = new FakeWidget();
			page.AddWidget(widget);

			var descriptor = Isolate.Fake.Instance<ComponentDescriptor>(Members.CallOriginal);

			//Act
			((IAjaxScriptableComponent)page).GetAjaxScriptDescriptors(null, null);

			//Assert
			Assert.IsTrue(widget.Described);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingPageCssIncludesWidgetsCssByDefault()
		{
			//Arrange
			var page = new BaseAjaxPageTest();
			var widget = new FakeWidget();
			Isolate.NonPublic.WhenCalled(widget, "RegisterCssReferences").DoInstead((method) =>
				{
					IContentRegistrar registrar = (IContentRegistrar)method.Parameters[0];
					registrar.AddCssReference(new CssReferenceRequestDetails("~/test.css"));
				});
			page.AddWidget(widget);

			var reg = new ContentRegistrar();

			//Act
			page.GetPageCssReferences(reg);
			var css = reg.GetCssReferences();

			//Assert
			Assert.AreEqual(1, css.Count);
			Assert.AreEqual("~/test.css", css[0].Path);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingPageScriptsIncludesWidgetsScriptsByDefault()
		{
			//Arrange
			var page = new BaseAjaxPageTest();
			var widget = new FakeWidget();
			page.AddWidget(widget);

			var reg = new ContentRegistrar();

			//Act
			page.GetPageScriptReferences(reg);
			var scripts = reg.GetScripts();

			//Assert
			Assert.AreEqual(2, scripts.Count);
		}

		[TestMethod]
		public void RegisteringNullPageWidgetsThrowsException()
		{
			//Arrange
			var page = new BaseAjaxPageTest();

			//Act

			//Assert
			ExceptionTester.CheckException(true, (src) => { page.RegisterWidget(null); });
		}

		[TestMethod]
		public void RegisteringPageWidgetsAddsToCount()
		{
			//Arrange
			var widget1 = new FakeWidget();
			var widget2 = new FakeWidget();

			var page = new BaseAjaxPageTest();

			//Act
			page.RegisterWidget(widget1);
			page.RegisterWidget(widget2);

			//Assert
			Assert.AreEqual(2, page.WidgetCount);
		}

		#endregion
	}
}
