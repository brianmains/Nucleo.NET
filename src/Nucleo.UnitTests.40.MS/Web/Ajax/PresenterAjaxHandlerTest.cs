using System;
using System.Web;
using System.Collections.Specialized;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Presentation;
using Nucleo.Web.Presentation;
using Nucleo.Views;


namespace Nucleo.Web.Ajax
{
	[TestClass]
	public class PresenterAjaxHandlerTest
	{
		#region " Test Classes "

		[PresenterAjax]
		protected class SimplePresenter : BaseWebPresenter
		{
			public SimplePresenter(IView view) 
				: base(view) { }

			public static bool OK { get; set; }

			[PresenterWebMethod]
			public static void DoThis() { OK = true; }
		}

		[PresenterAjax]
		protected class ComplexPresenter : BaseWebPresenter
		{
			public ComplexPresenter(IView view)
				: base(view) { }

			public static bool OK { get; set; }

			[PresenterWebMethod]
			public static void DoThis(int key, string name) { OK = true; }
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void PresenterWithoutParamsInvokesOK()
		{
			//Arrange
			var handler = new PresenterAjaxHandler();
			var context = Isolate.Fake.Instance<HttpContext>();
			Isolate.WhenCalled(() => context.Request.QueryString).WillReturn(new NameValueCollection());

			//Act
			handler.ProcessPresenter(context, typeof(SimplePresenter), "DoThis");

			//Assert
			Assert.AreEqual(true, SimplePresenter.OK);
		}

		[TestMethod]
		public void PresenterWithParamsFails()
		{
			//Arrange
			var handler = new PresenterAjaxHandler();
			var context = Isolate.Fake.Instance<HttpContext>();
			Isolate.WhenCalled(() => context.Request.QueryString).WillReturn(new NameValueCollection());

			//Act
			handler.ProcessPresenter(context, typeof(SimplePresenter), "DoThis");

			//Assert
			Assert.AreEqual(true, SimplePresenter.OK);
		}

		[TestMethod]
		public void PresenterWithParamsInvokesOK()
		{
			//Arrange
			var values = new NameValueCollection();
			values.Add("key", "1");
			values.Add("name", "Test");

			var handler = new PresenterAjaxHandler();
			var context = Isolate.Fake.Instance<HttpContext>();
			Isolate.WhenCalled(() => context.Request.QueryString).WillReturn(values);

			//Act
			handler.ProcessPresenter(context, typeof(SimplePresenter), "DoThis");

			//Assert
			Assert.AreEqual(true, SimplePresenter.OK);
		}

		#endregion
	}
}
