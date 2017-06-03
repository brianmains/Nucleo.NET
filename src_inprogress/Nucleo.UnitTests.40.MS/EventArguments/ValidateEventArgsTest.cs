using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.EventArguments
{
	[TestClass]
	public class ValidateEventArgsTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingWithArgsWorksOK()
		{
			//Arrange


			//Act
			var args = new ValidateEventArgs(false);

			//Assert
			Assert.AreEqual(false, args.IsValid);
		}

		[TestMethod]
		public void CreatingWithEmptyArgsWorksOK()
		{
			//Arrange
			

			//Act
			var args = new ValidateEventArgs();

			//Assert
			Assert.AreEqual(true, args.IsValid);
		}

		[TestMethod]
		public void GettingAndSettingWorksOK()
		{
			//Arrange
			var args = new ValidateEventArgs { IsValid = true };

			//Act
			args.IsValid = false;

			//Assert
			Assert.AreEqual(false, args.IsValid);
		}
		
		#endregion
	}
}
