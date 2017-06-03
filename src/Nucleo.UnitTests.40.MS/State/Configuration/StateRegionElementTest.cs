using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.State.Configuration
{
	[TestClass]
	public class StateRegionElementTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingRegionWorksOK()
		{
			//Arrange
			var region = default(StateRegionElement);

			//Act
			region = new StateRegionElement { Name = "Test" };

			//Assert
			Assert.AreEqual("Test", region.Name);
		}

		#endregion
	}
}
