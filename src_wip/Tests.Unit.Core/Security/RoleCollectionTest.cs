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
		public void CreatingWithDefaultContructorWorksOK()
		{
			new RoleCollection();
		}

		[TestMethod]
		public void CreatingWithEmptyCollectionAssignsNoValues()
		{
			var coll = new RoleCollection(new string[] { });

			Assert.AreEqual(0, coll.Count);
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void CreatingWithNullCollectionThrowsException()
		{
			new RoleCollection(null);
		}

		[TestMethod]
		public void SplittingEmptyRolesArrayStringWorksOK()
		{
			var coll = RoleCollection.FromString(string.Empty);

			Assert.AreEqual(0, coll.Count);
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void SplittingNullRolesArrayStringThrowsException()
		{
			RoleCollection.FromString(null);
		}

		[TestMethod]
		public void SplittingSingleItemReturnsThatItemOnly()
		{
			var output = RoleCollection.FromString("A");

			Assert.AreEqual(1, output.Count);
			Assert.AreEqual("A", output[0].Name);
		}

		[TestMethod]
		public void SplittingRolesArrayStringWorksOK()
		{
			var output = RoleCollection.FromString("A,B,C");

			Assert.AreEqual(3, output.Count);
			Assert.AreEqual("A", output[0].Name);
			Assert.AreEqual("C", output[2].Name);
		}

		#endregion
	}
}
