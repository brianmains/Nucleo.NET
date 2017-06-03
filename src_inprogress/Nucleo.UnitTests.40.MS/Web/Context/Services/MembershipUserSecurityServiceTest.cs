using System;
using System.Web;
using System.Web.Security;
using System.Security.Principal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Web.Context.Services
{
	[TestClass]
	public class MembershipUserSecurityServiceTest
	{
		#region " Tests "

		[TestMethod]
		public void CheckingRoleStatusWorksOK()
		{
			//Arrange
			var sec = new GenericPrincipal(new GenericIdentity("Ted", "Auth"), new string[] { "1", "2", "3" });
			var ctx = Isolate.Fake.Instance<HttpContextBase>();
			Isolate.WhenCalled(() => ctx.User).WillReturn(sec);

			Isolate.Fake.StaticMethods(typeof(Roles));
			Isolate.WhenCalled(() => Roles.IsUserInRole("A")).WillReturn(true);
			Isolate.WhenCalled(() => Roles.IsUserInRole("C")).WillReturn(true);
			Isolate.WhenCalled(() => Roles.IsUserInRole("D")).WillReturn(false);

			//Act
			var service = new MembershipUserSecurityService(ctx);

			//Assert
			Assert.IsTrue(service.IsInRole("A"));
			Assert.IsTrue(service.IsInRole("C"));
			Assert.IsFalse(service.IsInRole("D"));

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingRolesWorksOK()
		{
			//Arrange
			var sec = new GenericPrincipal(new GenericIdentity("Ted", "Auth"), new string[] { "1", "2", "3" });
			var ctx = Isolate.Fake.Instance<HttpContextBase>();
			Isolate.WhenCalled(() => ctx.User).WillReturn(sec);

			Isolate.Fake.StaticMethods(typeof(Roles));
			Isolate.WhenCalled(() => Roles.GetRolesForUser()).WillReturn(new string[] { "A", "B", "C" });

			//Act
			var service = new MembershipUserSecurityService(ctx);

			//Assert
			var roles = service.GetRolesForUser();
			Assert.AreEqual(3, roles.Count);
			Assert.AreEqual("A", roles[0].Name);
			Assert.AreEqual("C", roles[2].Name);

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
			var service = new MembershipUserSecurityService(ctx);

			//Assert
			Assert.AreEqual(false, service.IsLoggedIn());

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingLoggedInStatusReturnsTrue()
		{
			//Arrange
			var sec = new GenericPrincipal(new GenericIdentity("Ted", "Auth"), new string[] { "1", "2", "3" });
			var ctx = Isolate.Fake.Instance<HttpContextBase>();
			Isolate.WhenCalled(() => ctx.User).WillReturn(sec);

			//Act
			var service = new MembershipUserSecurityService(ctx);

			//Assert
			Assert.AreEqual(true, service.IsLoggedIn());

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingUserNameReturnsCorrectName()
		{
			//Arrange
			var sec = new GenericPrincipal(new GenericIdentity("Ted", "Auth"), new string[] { "1", "2", "3" });
			var ctx = Isolate.Fake.Instance<HttpContextBase>();
			Isolate.WhenCalled(() => ctx.User).WillReturn(sec);

			//Act
			var service = new MembershipUserSecurityService(ctx);

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
			var service = new MembershipUserSecurityService(ctx);

			//Assert
			Assert.AreEqual("", service.GetUserName());

			Isolate.CleanUp();
		}

		#endregion
	}
}
