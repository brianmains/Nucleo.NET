using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Extensions
{
	[TestClass]
	public class DateTimeValidationExtensionsTest
	{
		#region " Tests "

		[TestMethod]
		public void CheckingDatesWithoutTimeWorksOK()
		{
			//Arrange
			DateTime date1 = new DateTime(2007, 1, 1, 10, 12, 32);
			DateTime date2 = new DateTime(2007, 1, 1, 11, 34, 10);

			DateTime date3 = new DateTime(2007, 1, 2, 00, 00, 00);
			DateTime date4 = new DateTime(2007, 1, 1, 23, 59, 59);

			//Assert
			Assert.IsTrue(date1.AreEqual(date2, false));
			Assert.IsFalse(date3.AreEqual(date4, false));
		}

		[TestMethod]
		public void CheckingDatesWithTimeWorksOK()
		{
			//Arrange
			DateTime date1 = new DateTime(2007, 1, 1, 10, 20, 30);
			DateTime date2 = new DateTime(2007, 1, 1, 10, 20, 30);

			DateTime date3 = new DateTime(2007, 1, 1, 10, 20, 30);
			DateTime date4 = new DateTime(2007, 1, 1, 10, 20, 31);

			//Assert
			Assert.IsTrue(date1.AreEqual(date2, true));
			Assert.IsFalse(date3.AreEqual(date4, true));
		}

		[TestMethod]
		public void CheckingInRangeEndingBoundaryReturnsTrue()
		{
			//Arrange
			DateTime begin = new DateTime(2007, 1, 1, 10, 20, 30);
			DateTime end = new DateTime(2010, 1, 1, 10, 20, 30);

			//Act
			bool result = new DateTime(2010, 1, 1, 10, 20, 30).IsInRange(begin, end);

			//Assert
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void CheckingInRangeReturnsTrue()
		{
			//Arrange
			DateTime begin = new DateTime(2007, 1, 1, 10, 20, 30);
			DateTime end = new DateTime(2010, 1, 1, 10, 20, 30);

			//Act
			bool result = new DateTime(2008, 1, 1).IsInRange(begin, end);

			//Assert
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void CheckingInRangeStartingBoundaryReturnsTrue()
		{
			//Arrange
			DateTime begin = new DateTime(2007, 1, 1, 10, 20, 30);
			DateTime end = new DateTime(2010, 1, 1, 10, 20, 30);

			//Act
			bool result = new DateTime(2007, 1, 1, 10, 20, 30).IsInRange(begin, end);

			//Assert
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void CheckingOutOfRangeEndingBoundaryReturnsTrue()
		{
			//Arrange
			DateTime begin = new DateTime(2007, 1, 1, 10, 20, 30);
			DateTime end = new DateTime(2010, 1, 1, 10, 20, 30);

			//Act
			bool result = new DateTime(2010, 1, 1, 10, 20, 31).IsInRange(begin, end);

			//Assert
			Assert.IsFalse(result);
		}

		[TestMethod]
		public void CheckingOutOfRangeStartingBoundaryReturnsFalse()
		{
			//Arrange
			DateTime begin = new DateTime(2007, 1, 1, 10, 20, 30);
			DateTime end = new DateTime(2010, 1, 1, 10, 20, 30);

			//Act
			bool result = new DateTime(2007, 1, 1, 10, 20, 29).IsInRange(begin, end);

			//Assert
			Assert.IsFalse(result);
		}

		#endregion
	}
}
