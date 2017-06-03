using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Security
{
	[TestClass]
	public class AuthenticatedUserTest
	{
		[TestMethod]
		public void CreatingAssignsValues()
		{
			var role = Isolate.Fake.Instance<Role>();
			Isolate.WhenCalled(() => role.Name).WillReturn("Admin");

			var roles = new RoleCollection();
			roles.Add(role);

			var user = new AuthenticatedUser("Ted", roles);

			Assert.AreEqual("Ted", user.Name);
			Assert.IsTrue(user.IsAuthenticated);
			Assert.IsTrue(user.IsInRole("Admin"));
			Assert.IsFalse(user.IsInRole("Power"));
			Assert.AreEqual(1, user.GetRoles().Count);

			Isolate.CleanUp();
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException)),
		Isolated
		]
		public void CreatingWithNNameThrowsException()
		{
			var roles = Isolate.Fake.Instance<RoleCollection>();

			new AuthenticatedUser(string.Empty, roles);
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException)),
		Isolated
		]
		public void CreatingWithNullNameThrowsException()
		{
			var roles = Isolate.Fake.Instance<RoleCollection>();

			new AuthenticatedUser(null, roles);
		}

		[TestMethod]
		public void CreatingWithNullRolesAssignsOK()
		{
			var user = new AuthenticatedUser("Ted", null);

			Assert.IsNotNull(user.GetRoles());
		}

		[
		TestMethod,
		Isolated
		]
		public void CheckingWhetherUserIsInGivenRoleReturnsFalse()
		{
			var role = Isolate.Fake.Instance<Role>();
			Isolate.WhenCalled(() => role.Name).WillReturn("Admin");

			var roles = new RoleCollection();
			roles.Add(role);

			var user = new AuthenticatedUser("Ted", roles);

			Assert.IsFalse(user.IsInRole("PowerUser"));
		}

		[
		TestMethod,
		Isolated
		]
		public void CheckingWhetherUserIsInGivenRoleReturnsTrue()
		{
			var user = Isolate.Fake.Instance<AuthenticatedUser>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => user.GetRoles()).WillReturn(new RoleCollection { new Role("Admin") });

			Assert.IsTrue(user.IsInRole("Admin"));
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException)),
		Isolated
		]
		public void PassingEmptyToIsInRoleThrowsException()
		{
			var user = Isolate.Fake.Instance<AuthenticatedUser>(Members.CallOriginal, ConstructorWillBe.Ignored);

			user.IsInRole(string.Empty);
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException)),
		Isolated
		]
		public void PassingNullToIsInRoleThrowsException()
		{
			var user = Isolate.Fake.Instance<AuthenticatedUser>(Members.CallOriginal, ConstructorWillBe.Ignored);

			user.IsInRole(null);
		}

	}
}
