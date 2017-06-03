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

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void CallingProcessWithEmptyMethodThrowsException()
		{
			var context = Isolate.Fake.Instance<HttpContext>();
			new PresenterAjaxHandler().ProcessPresenter(context, typeof(SimplePresenter), string.Empty);
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void CallingProcessWithNullMethodThrowsException()
		{
			var context = Isolate.Fake.Instance<HttpContext>();
			new PresenterAjaxHandler().ProcessPresenter(context, typeof(SimplePresenter), null);
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentException))
		]
		public void CallingProcessWithMissingMethodInPresenterThrowsException()
		{
			var context = Isolate.Fake.Instance<HttpContext>();
			new PresenterAjaxHandler().ProcessPresenter(context, typeof(SimplePresenter), "DOESNTEXISTINPRESENTER");
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void CallingProcessWithoutPresenterThrowsException()
		{
			var context = Isolate.Fake.Instance<HttpContext>();
			new PresenterAjaxHandler().ProcessPresenter(context, null, "DoThis");
		}

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
