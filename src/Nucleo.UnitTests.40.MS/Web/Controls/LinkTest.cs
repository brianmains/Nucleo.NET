using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Context;
using Nucleo.Context.Services;
using Nucleo.Web.Context;
using Nucleo.EventArguments;
using Nucleo.Web.Context.Services;


namespace Nucleo.Web.Controls
{
	[TestClass]
	public class LinkTest
	{
		#region " Tests "
		
		[TestMethod]
		public void GettingTargetForNewWindowReturnsCorrectTargetValue()
		{
			//Arrange
			Link link = new Link();

			//Act
			link.Target = LinkTargetOptions.NewWindow;

			//Assert
			Assert.AreEqual("_blank", link.GetTarget());
		}

		[TestMethod]
		public void GettingTargetForSameWindowReturnsCorrectTargetValue()
		{
			//Arrange
			Link link = new Link();

			//Act
			link.Target = LinkTargetOptions.SameWindow;

			//Assert
			Assert.AreEqual("_self", link.GetTarget());
		}

		[TestMethod]
		public void GettingTextReturnsCorrectTextStatements()
		{
			//Arrange
			Link link = new Link();
			
			//Act
			link.Text = "Test Text";

			//Assert
			Assert.AreEqual("Test Text", link.Text);
			Assert.AreEqual("Test Text", link.GetText());
		}

		[TestMethod]
		public void GettingTextWithFormatStringReturnsCorrectTextStatements()
		{
			//Arrange
			Link link = new Link();

			//Act
			link.Text = "Test Text";
			link.TextFormat = "My test: {0}";

			//Assert
			Assert.AreEqual("Test Text", link.Text);
			Assert.AreEqual("My test: Test Text", link.GetText());
		}

		[TestMethod]
		public void GettingUrlWithFormatStringGetsCorrectUrl()
		{
			//Arrange
			Link link = new Link();

			link.NavigateUrlFormatString = "default.aspx?id={0}";
			link.NavigateUrl = "ABC123";
			Assert.AreEqual("default.aspx?id=ABC123", link.GetUrl());
		}

		[TestMethod]
		public void GettingUrlWithNullValueReturnsNull()
		{
			//Arrange
			Link link = new Link();

			//Act
			link.NavigateUrl = null;

			//Act
			Assert.IsNull(link.GetUrl());
		}

		[TestMethod]
		public void GettingUrlWithoutFormatStringGetsCorrectUrl()
		{
			//Arrange
			Link link = new Link();

			//Act
			link.NavigateUrl = "http://www.yahoo.com";

			//Assert
			Assert.AreEqual("http://www.yahoo.com", link.GetUrl());
		}

		[TestMethod]
		public void RaisingClickPostbackFiresCorrectEvent()
		{
			//Arrange
			Link link = new Link();
			bool success = false;

			link.Clicked += delegate(object sender, EventArgs e)
			{
				success = true;
			};

			//Act
			((IPostBackEventHandler)link).RaisePostBackEvent("click");

			//Assert
			Assert.AreEqual(true, success);
		}

		[TestMethod]
		public void RaisingRedirectPostbackFiresCorrectEvent()
		{
			//Arrange
			Link link = new Link();
			bool success = false;

			link.Redirecting += delegate(object sender, RedirectEventArgs e)
			{
				e.CancelRedirect = true;
				success = true;
			};

			//Act
			((IPostBackEventHandler)link).RaisePostBackEvent("redirect");

			//Assert
			Assert.AreEqual(true, success);
		}

		[TestMethod]
		public void RaisingRedirectPostbackUsesApplicationContext()
		{
			//Arrange
			var fakeService = new FakeNavigationService();

			var contextFake = Isolate.Fake.Instance<ApplicationContext>();
			Isolate.Fake.StaticMethods(typeof(ApplicationContext));
			Isolate.WhenCalled(() => ApplicationContext.GetCurrent()).WillReturn(contextFake);
			Isolate.WhenCalled(() => contextFake.GetService<INavigationService>()).WillReturn(fakeService);

			Link link = new Link();
			link.NavigateUrl = "http://www.google.com";

			//Act
			((IPostBackEventHandler)link).RaisePostBackEvent("redirect");

			//Assert

			Assert.AreEqual("http://www.google.com", fakeService.LastRoute);
		}

		#endregion
	}
}
