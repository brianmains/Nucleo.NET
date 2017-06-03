using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Security
{
	[TestClass]
	public class AnonymousUserTest
	{
		[TestMethod]
		public void CreatingAssignsEmptyValues()
		{
			var user = new AnonymousUser();

			Assert.AreEqual("", user.Name);
			Assert.IsFalse(user.IsAuthenticated);
			Assert.AreEqual(0, user.GetRoles().Count);
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void IsInRoleWithEmptyThrowsException()
		{
			var user = new AnonymousUser();

			Assert.IsFalse(user.IsInRole(string.Empty));
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void IsInRoleWithNullThrowsException()
		{
			var user = new AnonymousUser();

			Assert.IsFalse(user.IsInRole(default(string)));
		}

		[TestMethod]
		public void IsInRoleAlwaysReturnsFalseForValidRoleName()
		{
			var user = new AnonymousUser();

			Assert.IsFalse(user.IsInRole("Administrator"));
			Assert.IsFalse(user.IsInRole("B"));
		}
	}
}
