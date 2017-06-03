using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Security
{
	[TestClass]
	public class RoleCollectionTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingRolesFromStringArrayWorksOK()
		{
			//Arrange
			var roles = new string[] { "A", "B", "C" };

			//Act
			var output = new RoleCollection(roles);

			//Assert
			Assert.AreEqual(3, output.Count);
			Assert.AreEqual("A", output[0].Name);
			Assert.AreEqual("C", output[2].Name);
		}

		[TestMethod]
		public void SplittingRolesArrayStringWorksOK()
		{
			//Arrange
			

			//Act
			var output = RoleCollection.FromString("A,B,C");

			//Assert
			Assert.AreEqual(3, output.Count);
			Assert.AreEqual("A", output[0].Name);
			Assert.AreEqual("C", output[2].Name);
		}

		#endregion
	}
}
