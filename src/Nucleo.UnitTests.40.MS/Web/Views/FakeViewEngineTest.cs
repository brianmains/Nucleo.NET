using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Web.Views
{
	[TestClass]
	public class FakeViewEngineTest
	{
		#region " Test Classes "

		protected class TestView : IView, IDisposable
		{
			public bool Disposed;

			public void Dispose()
			{
				Disposed = true;
			}

			public void Render(ViewContext viewContext, System.IO.TextWriter writer)
			{
				
			}
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void FindingPartialViewReturnsPassedInResult()
		{
			//Arrange
			var view = Isolate.Fake.Instance<IView>();
			var viewEngine = new FakeViewEngine();
			var result = new ViewEngineResult(view, viewEngine);

			//Act
			viewEngine.Result = result;
			var output = viewEngine.FindPartialView(new ControllerContext(), "Test", true);

			//Assert
			Assert.AreEqual(result, output);
		}

		[TestMethod]
		public void FindingPartialViewWithFakePartialViewAndNullNameReturnsTrue()
		{
			//Arrange
			var view = new FakePartialView();
			var viewEngine = new FakeViewEngine();
			var result = new ViewEngineResult(view, viewEngine);

			//Act
			viewEngine.Result = result;
			var output = viewEngine.FindPartialView(new ControllerContext(), "App_Offline", false);

			//Assert
			Assert.AreEqual(result, output);
		}

		[TestMethod]
		public void FindingPartialViewWithFakePartialViewChecksNameAndReturnsFalse()
		{
			//Arrange
			var view = new FakePartialView("App_Offline");
			var viewEngine = new FakeViewEngine();
			var result = new ViewEngineResult(view, viewEngine);

			//Act
			viewEngine.Result = result;
			var output = viewEngine.FindPartialView(new ControllerContext(), "Test", false);

			//Assert
			Assert.IsNull(output);
		}

		[TestMethod]
		public void FindingPartialViewWithFakePartialViewChecksNameAndReturnsTrue()
		{
			//Arrange
			var view = new FakePartialView("App_Offline");
			var viewEngine = new FakeViewEngine();
			var result = new ViewEngineResult(view, viewEngine);

			//Act
			viewEngine.Result = result;
			var output = viewEngine.FindPartialView(new ControllerContext(), "App_Offline", false);

			//Assert
			Assert.AreEqual(result, output);
		}

		[TestMethod]
		public void FindingPartialViewWithFakeViewAndNullNameReturnsFalse()
		{
			//Arrange
			var view = new FakeView();
			var viewEngine = new FakeViewEngine();
			var result = new ViewEngineResult(view, viewEngine);

			//Act
			viewEngine.Result = result;
			var output = viewEngine.FindPartialView(new ControllerContext(), "App_Offline", false);

			//Assert
			Assert.AreEqual(result, output);
		}

		[TestMethod]
		public void FindingViewReturnsPassedInResult()
		{
			//Arrange
			var view = Isolate.Fake.Instance<IView>();
			var viewEngine = new FakeViewEngine();
			var result = new ViewEngineResult(view, viewEngine);

			//Act
			viewEngine.Result = result;
			var output = viewEngine.FindView(new ControllerContext(), "Test", "Master", true);

			//Assert
			Assert.AreEqual(result, output);
		}

		[TestMethod]
		public void FindingViewWithFakePartialViewAndNullNameReturnsFalse()
		{
			//Arrange
			var view = new FakePartialView();
			var viewEngine = new FakeViewEngine();
			var result = new ViewEngineResult(view, viewEngine);

			//Act
			viewEngine.Result = result;
			var output = viewEngine.FindView(new ControllerContext(), "App_Offline", null, false);

			//Assert
			Assert.AreEqual(result, output);
		}

		[TestMethod]
		public void FindingViewWithFakeViewAndNullNameReturnsTrue()
		{
			//Arrange
			var view = new FakeView();
			var viewEngine = new FakeViewEngine();
			var result = new ViewEngineResult(view, viewEngine);

			//Act
			viewEngine.Result = result;
			var output = viewEngine.FindView(new ControllerContext(), "App_Offline", null, false);

			//Assert
			Assert.AreEqual(result, output);
		}

		[TestMethod]
		public void FindingViewWithFakeViewChecksNameAndReturnsFalse()
		{
			//Arrange
			var view = new FakeView("App_Offline");
			var viewEngine = new FakeViewEngine();
			var result = new ViewEngineResult(view, viewEngine);

			//Act
			viewEngine.Result = result;
			var output = viewEngine.FindView(new ControllerContext(), "Test", null, false);

			//Assert
			Assert.IsNull(output);
		}

		[TestMethod]
		public void FindingViewWithFakeViewChecksNameAndReturnsTrue()
		{
			//Arrange
			var view = new FakeView("App_Offline");
			var viewEngine = new FakeViewEngine();
			var result = new ViewEngineResult(view, viewEngine);

			//Act
			viewEngine.Result = result;
			var output = viewEngine.FindView(new ControllerContext(), "App_Offline", null, false);

			//Assert
			Assert.AreEqual(result, output);
		}

		[TestMethod]
		public void ReleasingViewThatIsDisposableWorksOK()
		{
			var view = new TestView();
			var viewEngine = new FakeViewEngine();

			//Act
			viewEngine.ReleaseView(new ControllerContext(), view);

			//Assert
			Assert.IsTrue(view.Disposed);
		}

		[TestMethod]
		public void ReleasingViewThatIsntDisposableWorksOK()
		{
			var view = Isolate.Fake.Instance<IView>();
			var viewEngine = new FakeViewEngine();

			//Act

			//Assert
			viewEngine.ReleaseView(new ControllerContext(), view);
		}

		#endregion
	}
}
