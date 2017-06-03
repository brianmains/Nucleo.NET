using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Validation
{
	[TestClass]
	public class ValidationSessionTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingSessionCreatesItems()
		{
			//Arrange
			var itemsFake = Isolate.Fake.Instance<ValidationItemCollection>();
			
			//Act
			var session = new ValidationSession(itemsFake);

			//Assert
			Assert.AreEqual(itemsFake, session.Items);
		}

		[TestMethod]
		public void MergingSessionsWorksOK()
		{
			//Arrange
			var itemsFake1 = Isolate.Fake.Instance<ValidationItemCollection>(Members.CallOriginal);
			itemsFake1.Add(new ValidationItem("Error1", new ErrorValidationType(), "My error"));

			var itemsFake2 = Isolate.Fake.Instance<ValidationItemCollection>(Members.CallOriginal);
			itemsFake2.Add(new ValidationItem("Error2", new ErrorValidationType(), "My error"));

			var session1 = new ValidationSession(itemsFake1);
			var session2 = new ValidationSession(itemsFake2);

			//Act
			session1.MergeSession(session2);

			//Assert
			Assert.AreEqual(2, session1.Items.Count);
		}

		#endregion
	}
}
