using System;
using System.Web;
using System.Web.Security;
using System.Security.Principal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Services
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
		public void GettingListOfRolesForAUserReturnsEmpty()
		{
			Isolate.Fake.StaticMethods(typeof(Roles));
			Isolate.WhenCalled(() => Roles.Enabled).WillReturn(true);
			Isolate.WhenCalled(() => Roles.GetRolesForUser()).WillReturn(new string[] { });

			var ctx = Isolate.Fake.Instance<HttpContextBase>();
			var service = new MembershipUserSecurityService(ctx);

			var roles = service.GetRolesForUser();

			Assert.AreEqual(0, roles.Count);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingListOfRolesForAUserReturnsRolesMembershipRoles()
		{
			Isolate.Fake.StaticMethods(typeof(Roles));
			Isolate.WhenCalled(() => Roles.Enabled).WillReturn(true);
			Isolate.WhenCalled(() => Roles.GetRolesForUser()).WillReturn(new string[] { "Admin" });

			var ctx = Isolate.Fake.Instance<HttpContextBase>();
			var service = new MembershipUserSecurityService(ctx);

			var roles = service.GetRolesForUser();

			Assert.AreEqual(1, roles.Count);
			Assert.AreEqual("Admin", roles[0].Name);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingListOfRolesWhenRolesDisabledReturnsEmpty()
		{
			Isolate.Fake.StaticMethods(typeof(Roles));
			Isolate.WhenCalled(() => Roles.Enabled).WillReturn(false);

			var ctx = Isolate.Fake.Instance<HttpContextBase>();
			var service = new MembershipUserSecurityService(ctx);

			var roles = service.GetRolesForUser();

			Assert.AreEqual(0, roles.Count);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingAnonymousUserReturnsFalseForLoggedInStatus()
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
		public void GettingAuthenticatedUserReturnsTrueForLoggedInStatus()
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
		public void GettingNoUserIdentityReturnsFalseForLoggedInStatus()
		{
			//Arrange
			var principal = Isolate.Fake.Instance<IPrincipal>();

			var ctx = Isolate.Fake.Instance<HttpContextBase>();
			Isolate.WhenCalled(() => ctx.User).WillReturn(principal);

			//Act
			var service = new MembershipUserSecurityService(ctx);

			//Assert
			Assert.AreEqual(false, service.IsLoggedIn());

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingNoUserPrincipalReturnsFalseForLoggedInStatus()
		{
			//Arrange
			var ctx = Isolate.Fake.Instance<HttpContextBase>();
			Isolate.WhenCalled(() => ctx.User).WillReturn(null);

			//Act
			var service = new MembershipUserSecurityService(ctx);

			//Assert
			Assert.AreEqual(false, service.IsLoggedIn());

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
