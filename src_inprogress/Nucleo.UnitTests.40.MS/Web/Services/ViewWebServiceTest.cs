using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Presentation;


namespace Nucleo.Web.Services
{
	[TestClass]
	public class ViewWebServiceTest
	{
		#region " Test Classes "

		protected class TestView : ViewWebService
		{
			public TestView()
				: base() { }
		}

		#endregion


		[
		TestMethod,
		ExpectedException(typeof(Exceptions.PresenterNotFoundException)),
		Isolated
		]
		public void LoadingMissingPresenterThrowsException()
		{
			Isolate.Fake.StaticMethods(typeof(PresenterFactory));
			Isolate.WhenCalled(() => PresenterFactory.Create(null)).WillReturn(null);

			var service = new TestView();
		}

		[TestMethod]
		public void LoadingPresenterWorksOK()
		{
			var presenter = Isolate.Fake.Instance<IPresenter>();

			Isolate.Fake.StaticMethods(typeof(PresenterFactory));
			Isolate.WhenCalled(() => PresenterFactory.Create(null)).WillReturn(presenter);

			var service = new TestView();

			Isolate.CleanUp();
		}
	}
}
