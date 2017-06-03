using System;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Context;
using Nucleo.Web.Presentation.Context;


namespace Nucleo.Web.Presentation
{
	[TestClass]
	public class BaseWebPresenterTest
	{
		#region " Test Classes "

		protected class TestPresenter : BaseWebPresenter
		{
			public TestPresenter()
				: base(null) { }
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void CreatingPresenterContextWorksOK()
		{
			//Arrange
			Isolate.Fake.StaticMethods(typeof(ApplicationContext));
			Isolate.WhenCalled(() => ApplicationContext.GetCurrent()).WillReturn(null);

			Isolate.Fake.StaticMethods(typeof(HttpContext));
			var httpCtx = Isolate.Fake.Instance<HttpContextWrapper>();
			Isolate.Swap.NextInstance<HttpContextWrapper>().With(httpCtx);

			//Act
			var presenter = new TestPresenter();
			var hasContext = presenter.HasCurrentContext;
			var output = presenter.CurrentContext;
			var hasContext2 = presenter.HasCurrentContext;

			//Assert
			Assert.IsFalse(hasContext);
			Assert.IsNotNull(output.EventRegistry);
			Assert.IsNotNull(output.Singletons);
			Assert.IsTrue(hasContext2);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingAndSettingContextWorksOK()
		{
			//Arrange
			var presenter = new TestPresenter();
			var ctx = new PresenterWebContext();

			//Act
			presenter.CurrentContext = ctx;

			//Assert
			Assert.AreEqual(ctx, presenter.CurrentContext);
		}

		#endregion
	}
}
