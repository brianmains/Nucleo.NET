using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Security
{
	[TestClass]
	public class RoleTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingRoleWorksOK()
		{
			//Arrange

			//Act
			var role = new Role("Test");

			//Assert
			Assert.AreEqual("Test", role.Name);
		}

		#endregion
	}
}
