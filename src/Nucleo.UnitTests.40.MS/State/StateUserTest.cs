using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.State
{
	[TestClass]
	public class StateUserTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingUserWorksOK()
		{
			//Arrange
			var user = default(StateUser);

			//Act
			user = new StateUser("MyUser", true);

			//Assert
			Assert.AreEqual("MyUser", user.UserName);
			Assert.AreEqual(true, user.IsAuthenticated);
		}

		#endregion
	}
}
