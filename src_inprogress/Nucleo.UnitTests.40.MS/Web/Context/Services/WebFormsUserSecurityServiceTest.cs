using System;
using System.Web;
using System.Security.Principal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Web.Context.Services
{
	[TestClass]
	public class WebFormsUserSecurityServiceTest
	{
		#region " Tests "

		[TestMethod]
		public void CheckingRoleStatusWorksOK()
		{
			//Arrange
			var sec = new GenericPrincipal(new GenericIdentity("Ted", "Auth"), new string[] { "A", "B", "C" });
			var ctx = Isolate.Fake.Instance<HttpContextBase>();
			Isolate.WhenCalled(() => ctx.User).WillReturn(sec);

			//Act
			var service = new WebFormsUserSecurityService(ctx);

			//Assert
			Assert.IsTrue(service.IsInRole("A"));
			Assert.IsTrue(service.IsInRole("C"));
			Assert.IsFalse(service.IsInRole("D"));

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingLoggedInStatusReturnsFalse()
		{
			//Arrange
			var sec = new GenericPrincipal(new GenericIdentity("", ""), null);
			var ctx = Isolate.Fake.Instance<HttpContextBase>();
			Isolate.WhenCalled(() => ctx.User).WillReturn(sec);

			//Act
			var service = new WebFormsUserSecurityService(ctx);

			//Assert
			Assert.AreEqual(false, service.IsLoggedIn());

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingLoggedInStatusReturnsTrue()
		{
			//Arrange
			var sec = new GenericPrincipal(new GenericIdentity("Ted", "Auth"), new string[] { "A", "B", "C" });
			var ctx = Isolate.Fake.Instance<HttpContextBase>();
			Isolate.WhenCalled(() => ctx.User).WillReturn(sec);

			//Act
			var service = new WebFormsUserSecurityService(ctx);

			//Assert
			Assert.AreEqual(true, service.IsLoggedIn());

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingUserNameReturnsCorrectName()
		{
			//Arrange
			var sec = new GenericPrincipal(new GenericIdentity("Ted", "Auth"), new string[] { "A", "B", "C" });
			var ctx = Isolate.Fake.Instance<HttpContextBase>();
			Isolate.WhenCalled(() => ctx.User).WillReturn(sec);

			//Act
			var service = new WebFormsUserSecurityService(ctx);

			//Assert
			Assert.AreEqual("Ted", service.GetUserName());

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingUserNameReturnsNull()
		{
			//Arrange
			var sec = new GenericPrincipal(new GenericIdentity("", ""), null);
			var ctx = Isolate.Fake.Instance<HttpContextBase>();
			Isolate.WhenCalled(() => ctx.User).WillReturn(sec);

			//Act
			var service = new WebFormsUserSecurityService(ctx);

			//Assert
			Assert.AreEqual("", service.GetUserName());

			Isolate.CleanUp();
		}

		#endregion
	}
}
