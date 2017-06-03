using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;




namespace Nucleo.EventsManagement.Listeners
{
	[TestClass]
	public class EntityTypeListenerCriteriaTest
	{
		#region " Test Classes "

		protected class InvalidTestClass { }

		protected class TestClass { }

		protected class TestClass2 : TestClass { }

		#endregion



		#region " Tests "

		[TestMethod]
		public void AnyMatchMatchesOK()
		{
			//Arrange
			var any = new AnyListenerCriteria();

			//Act
			var listener = new EntityTypeListenerCriteria(typeof(TestClass));
			var match = listener.IsMatch(any);

			//Assert
			Assert.IsTrue(match);
		}

		[TestMethod]
		public void ConstructingWithNullThrowsException()
		{
			//Assert
			ExceptionTester.CheckException(true, (s) => { new EntityTypeListenerCriteria(null); });
		}

		[TestMethod]
		public void IsMatchForEntityTypeReturnsFalse()
		{
			//Arrange
			var listener = new EntityTypeListenerCriteria(typeof(TestClass));

			//Act
			var compare = new EntityTypeListenerCriteria(typeof(InvalidTestClass));
			var match = compare.IsMatch(listener);

			//Assert
			Assert.IsFalse(match);
		}

		[TestMethod]
		public void IsMatchForDifferentEntityTypeReturnsTrue()
		{
			//Arrange
			var listener = new EntityTypeListenerCriteria(typeof(TestClass));

			//Act
			var compare = new EntityTypeListenerCriteria(typeof(TestClass2));
			var match = listener.IsMatch(compare);

			//Assert
			Assert.IsTrue(match);
		}

		[TestMethod]
		public void IsMatchForSameEntityTypeReturnsTrue()
		{
			//Arrange
			var listener = new EntityTypeListenerCriteria(typeof(TestClass));

			//Act
			var compare = new EntityTypeListenerCriteria(typeof(TestClass));
			var match = compare.IsMatch(listener);

			//Assert
			Assert.IsTrue(match);
		}

		#endregion
	}
}
