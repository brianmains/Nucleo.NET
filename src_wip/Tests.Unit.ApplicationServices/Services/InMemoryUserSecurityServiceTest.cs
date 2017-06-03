using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Nucleo.Security;


namespace Nucleo.Services
{
	[TestClass]
	public class InMemoryUserSecurityServiceTest
	{
		#region " Tests "

		[TestMethod]
		public void CheckingIfInTheCurrentRoleReturnsCorrectRole()
		{
			//Arrange
			var service = new InMemoryUserSecurityService("Test", true, new RoleCollection
				{
					new Role("Admin"),
					new Role("Users")
				});

			//Act
			var output1 = service.IsInRole("Admin");
			var output2 = service.IsInRole("PowerUsers");

			//Assert
			Assert.IsTrue(output1);
			Assert.IsFalse(output2);
		}

		[TestMethod]
		public void GettingLoggedInStatusWorksAsExpected()
		{
			//Arrange
			var service = new InMemoryUserSecurityService("Test", true, null);

			//Act
			var output = service.IsLoggedIn();

			//Assert
			Assert.IsNotNull(output);
			Assert.AreEqual(true, output);
		}

		[TestMethod]
		public void GettingRolesForUserWorksAsExpected()
		{
			//Arrange
			var service = new InMemoryUserSecurityService("Test", true, new RoleCollection
				{
					new Role("Admin"),
					new Role("Users")
				});

			//Act
			var output = service.GetRolesForUser();

			//Assert
			Assert.IsNotNull(output);
			Assert.AreEqual(2, output.Count);
		}

		[TestMethod]
		public void GettingUserNameWorksAsExpected()
		{
			//Arrange
			var service = new InMemoryUserSecurityService("Test", true, null);

			//Act
			var output = service.GetUserName();

			//Assert
			Assert.IsNotNull(output);
			Assert.AreEqual("Test", output);
		}

		#endregion
	}
}
