using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.State
{
	[TestClass]
	public class StatePropertyTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingAnObjectAssignsCorrectValues()
		{
			//Arrange
			var property = default(StateProperty);
			var property2 = default(StateProperty);

			//Act
			property = new StateProperty("Name", null);
			property2 = new StateProperty("Test", 1);

			//Assert
			Assert.AreEqual("Name", property.Name);
			Assert.AreEqual(null, property.DefaultValue);
			
			Assert.AreEqual("Test", property2.Name);
			Assert.AreEqual(1, property2.DefaultValue);
		}

		[TestMethod]
		public void CreatingObjectUsingIsolationWorksOK()
		{
			//Arrange
			var property = default(StateProperty);

			//Act
			property = new StateProperty("Test", StatePropertyIsolation.PerUser, 123);

			//Assert
			Assert.AreEqual("Test", property.Name);
			Assert.AreEqual(StatePropertyIsolation.PerUser, property.Isolation);
			Assert.AreEqual(123, property.DefaultValue);
		}

		#endregion
	}
}