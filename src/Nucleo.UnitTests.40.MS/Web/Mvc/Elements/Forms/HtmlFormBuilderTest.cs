using System;
using System.Collections.Generic;
using System.Web.Routing;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Web.Mvc.Elements.Forms
{
	[TestClass]
	public class HtmlFormBuilderTest
	{
		#region " Tests "

		[TestMethod]
		public void BeginningFormWorksOK()
		{
			//Arrange
			var builder = Isolate.Fake.Instance<HtmlFormBuilder>(Members.CallOriginal);

			//Act
			var output = builder.Form((form) =>
				{
					form.ActionName = "A";
					form.ControllerName = "B";
					form.HtmlAttributes.Add("id", "C");
					form.RouteValues = new RouteValueDictionary(new { d = 3, e = 4 });
				}).GetForm();

			//Assert
			Assert.AreEqual("A", output.ActionName);
			Assert.AreEqual("B", output.ControllerName);
			Assert.AreEqual(1, output.HtmlAttributes.Count);
			Assert.AreEqual(2, output.RouteValues.Count);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void RenderingFormWithControllerAndActionWorksOK()
		{
			//Arrange
			var form = new HtmlForm
			{
				ControllerName = "Users",
				ActionName = "Admin",
				HtmlAttributes = new Dictionary<string, object>(),
				RouteValues = new RouteValueDictionary(new { a = 1, b = 2 })
			};

			var url = Isolate.Fake.Instance<UrlHelper>();
			Isolate.Swap.NextInstance<UrlHelper>().With(url);
			Isolate.WhenCalled(() => url.Action(null, null, null)).WillReturn("/Users/Admin?a=1&b=2");

			var factory = Isolate.Fake.Instance<NucleoElementFactory>();
			Isolate.WhenCalled(() => factory.Html.ViewContext.HttpContext.Request.RawUrl).WillReturn("/Home/Index");

			var builder = Isolate.Fake.Instance<HtmlFormBuilder>(Members.CallOriginal, ConstructorWillBe.Called, new object[] { factory });
			Isolate.NonPublic.WhenCalled(builder, "GetElement").WillReturn(form);

			//Act
			string content = builder.Render();

			//Assert
			StringAssert.Contains(content, "action=\"/Users/Admin?a=1&b=2\"");

			Isolate.CleanUp();
		}

		[TestMethod]
		public void RenderingFormWithNoControllerAndActionWorksOK()
		{
			//Arrange
			var requestContext = Isolate.Fake.Instance<RequestContext>();

			var factory = Isolate.Fake.Instance<NucleoElementFactory>();
			Isolate.WhenCalled(() => factory.Html.ViewContext.RequestContext).WillReturn(requestContext);
			Isolate.WhenCalled(() => factory.Html.ViewContext.HttpContext.Request.RawUrl).WillReturn("/Home/Index");

			var builder = Isolate.Fake.Instance<HtmlFormBuilder>(Members.CallOriginal);
			Isolate.NonPublic.Property.WhenGetCalled(builder, "ElementFactory").WillReturn(factory);

			var form = new HtmlForm
			{
				HtmlAttributes = new Dictionary<string, object>(),
				RouteValues = new RouteValueDictionary(new { a = 1, b = 2 })
			};

			Isolate.NonPublic.WhenCalled(builder, "GetElement").WillReturn(form);

			//Act
			string content = builder.Render();

			//Assert
			StringAssert.Contains(content, "action=\"/Home/Index\"");

			Isolate.CleanUp();
		}

		[TestMethod]
		public void SpecifyingActionAndRouteValuesAssignsOK()
		{
			//Arrange
			var builder = Isolate.Fake.Instance<HtmlFormBuilder>(Members.CallOriginal);

			var dict = new Dictionary<string, object>();
			dict.Add("A", 1);

			//Act
			var output = builder.Action("Index", new RouteValueDictionary(dict)).GetForm();

			//Assert
			Assert.AreEqual("Index", output.ActionName);
			Assert.IsNull(output.ControllerName);
			Assert.IsNotNull(output.RouteValues);
			Assert.AreEqual(1, output.RouteValues.Count);
			Assert.AreEqual(0, output.HtmlAttributes.Count);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void SpecifyingActionControllerAndRouteValuesAssignsOK()
		{
			//Arrange
			var builder = Isolate.Fake.Instance<HtmlFormBuilder>(Members.CallOriginal);

			var dict = new Dictionary<string, object>();
			dict.Add("A", 1);

			//Act
			var output = builder.Action("Index", "Home", new RouteValueDictionary(dict)).GetForm();

			//Assert
			Assert.AreEqual("Index", output.ActionName);
			Assert.AreEqual("Home", output.ControllerName);
			Assert.IsNotNull(output.RouteValues);
			Assert.AreEqual(1, output.RouteValues.Count);
			Assert.AreEqual(0, output.HtmlAttributes.Count);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void SpecifyingActionOnlyAssignsOK()
		{
			//Arrange
			var builder = Isolate.Fake.Instance<HtmlFormBuilder>(Members.CallOriginal);

			//Act
			var output = builder.Action("Index").GetForm();
			
			//Assert
			Assert.AreEqual("Index", output.ActionName);
			Assert.IsNull(output.ControllerName);
			Assert.AreEqual(0, output.RouteValues.Count);
			Assert.AreEqual(0, output.HtmlAttributes.Count);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void SpecifyingHtmlAttributesOnlyAssignsOK()
		{
			//Arrange
			var builder = Isolate.Fake.Instance<HtmlFormBuilder>(Members.CallOriginal);

			//Act
			var output = builder.HtmlAttributes(new { method = "post", id = "a" }).GetForm();

			//Assert
			Assert.IsNotNull(output);
			Assert.AreEqual("post", output.HtmlAttributes["method"]);
			Assert.AreEqual("a", output.HtmlAttributes["id"]);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void SpecifyingHtmlAttributesOnlyWithDictionaryAssignsOK()
		{
			//Arrange
			var builder = Isolate.Fake.Instance<HtmlFormBuilder>(Members.CallOriginal);

			var dict = new Dictionary<string, object>();
			dict.Add("method", "post");
			dict.Add("id", "a");

			//Act
			var output = builder.HtmlAttributes(dict).GetForm();

			//Assert
			Assert.IsNotNull(output);
			Assert.AreEqual("post", output.HtmlAttributes["method"]);
			Assert.AreEqual("a", output.HtmlAttributes["id"]);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void SpecifyingMethodOnlyAssignsOK()
		{
			//Arrange
			var builder = Isolate.Fake.Instance<HtmlFormBuilder>(Members.CallOriginal);

			//Act
			var output = builder.Method(FormMethod.Get).GetForm();

			//Assert
			Assert.AreEqual(1, output.HtmlAttributes.Count);
			Assert.AreEqual("Get", output.HtmlAttributes["method"]);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void SpecifyingRouteValuesOnlyAssignsOK()
		{
			//Arrange
			var builder = Isolate.Fake.Instance<HtmlFormBuilder>(Members.CallOriginal);

			var dict = new Dictionary<string, object>();
			dict.Add("A", 1);

			//Act
			
			var output = builder.Action(new RouteValueDictionary(dict)).GetForm();

			//Assert
			Assert.IsNull(output.ActionName);
			Assert.IsNull(output.ControllerName);
			Assert.IsNotNull(output.RouteValues);
			Assert.AreEqual(0, output.HtmlAttributes.Count);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void SpecifyingRouteValuesWithActionAndControllerAssignsOK()
		{
			//Arrange
			var builder = Isolate.Fake.Instance<HtmlFormBuilder>(Members.CallOriginal);

			var dict = new Dictionary<string, object>();
			dict.Add("action", "Index");
			dict.Add("controller", "Home");

			//Act

			var output = builder.Action(new RouteValueDictionary(dict)).GetForm();

			//Assert
			Assert.AreEqual("Index", output.ActionName);
			Assert.AreEqual("Home", output.ControllerName);
			Assert.IsNotNull(output.RouteValues);
			Assert.AreEqual(0, output.RouteValues.Count);
			Assert.AreEqual(0, output.HtmlAttributes.Count);

			Isolate.CleanUp();
		}

		#endregion
	}
}
