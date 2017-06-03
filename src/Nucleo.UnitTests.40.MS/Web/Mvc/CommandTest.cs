using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Web.Mvc
{
	[TestClass]
	public class CommandTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingCommandWorksOK()
		{
			//Arrange
			var command = default(Command);
			var command2 = default(Command);

			//Act
			command = new Command("click");
			command2 = new Command("command", "2");
			
			//Assert
			Assert.AreEqual("click", command.Name);
			Assert.AreEqual("command", command2.Name);
			Assert.AreEqual("2", command2.Argument);
		}

		#endregion
	}
}
