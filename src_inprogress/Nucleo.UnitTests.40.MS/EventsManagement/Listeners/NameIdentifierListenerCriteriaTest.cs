using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Nucleo.TestingTools;


namespace Nucleo.EventsManagement.Listeners
{
	[TestClass]
	public class NameIdentifierListenerCriteriaTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingListenerWorksOK()
		{
			//Arrange
			var obj = "test";
			

			//Act
			var listener = new NameIdentifierListenerCriteria(obj);

			//Assert
			Assert.AreEqual(obj, listener.Identifier);
		}

		[TestMethod]
		public void NullEntityThrowsException()
		{
			//Arrange
			
			//Act

			//Assert
			ExceptionTester.CheckException(true, (src) => { new NameIdentifierListenerCriteria(null); });
		}

		#endregion
	}
}
