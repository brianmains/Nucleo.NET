using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Views;


namespace Nucleo.Web.Routing
{
	[TestClass]
	public class ViewConventionRoutingEngineTest
	{
		#region " Test Classes "

		public interface ITestView : IView { }

		public class TestView : View, ITestView { }

		#endregion



		#region " Tests "

		[TestMethod]
		public void CreatingWithCustomSettingsAssignsOK()
		{
			var routing = new ViewConventionRoutingEngine("~", "ViewControls");

			Assert.AreEqual("~", routing.DefaultPath);
			Assert.AreEqual("ViewControls", routing.ViewNamespace);
			Assert.AreEqual(".aspx", routing.DefaultExtension);
		}

		[TestMethod]
		public void CreatingWithDefaultsAssignsOK()
		{
			var routing = new ViewConventionRoutingEngine();

			Assert.AreEqual("~/Views", routing.DefaultPath);
			Assert.AreEqual("Views", routing.ViewNamespace);
		}

		//[TestMethod]
		//public void NavigatingToAViewRoutesOK()
		//{
		//    Isolate.Fake.StaticMethods<HttpContext>();
		//    var response = Isolate.Fake.Instance<HttpResponseWrapper>();
		//    Isolate.Swap.NextInstance<HttpResponseWrapper>().With(response);

		//    var routing = new ViewConventionRoutingEngine("~", "Web");

		//    routing.Navigate(typeof(ITestView));

		//    Isolate.Verify.WasCalledWithExactArguments(() => response.Redirect("~/Routing/TestView.aspx"));

		//    Isolate.CleanUp();
		//}

		[TestMethod]
		public void RoutingToAViewInstanceReturnsFalse()
		{
			var routing = new ViewConventionRoutingEngine();
			var instance = Isolate.Fake.Instance<ITestView>();

			var result = routing.IsForSource(instance);

			Assert.IsFalse(result);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void RoutingToAViewTypeReturnsTrue()
		{
			var routing = new ViewConventionRoutingEngine();

			var result = routing.IsForSource(typeof(ITestView));

			Assert.IsTrue(result);
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void RoutingToNullThrowsException()
		{
			var routing = new ViewConventionRoutingEngine();

			routing.IsForSource(null);
		}

		#endregion
	}
}
