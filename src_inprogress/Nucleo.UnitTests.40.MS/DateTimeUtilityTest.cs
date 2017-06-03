using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo
{
	[TestClass]
	public class DateTimeUtilityTest
	{
		[TestMethod]
		public void ConvertToBeginDateReturnsZeroes()
		{
			//Arranget
			DateTime beginDate = default(DateTime);
			DateTime beginDate2 = default(DateTime);

			//Act
			beginDate = DateTimeUtility.ConvertToBeginDate(DateTime.Now);
			beginDate2 = DateTimeUtility.ConvertToBeginDate(new DateTime(2007, 1, 1, 17, 45, 54));

			//Assert
			Assert.AreEqual(0, beginDate.Hour);
			Assert.AreEqual(0, beginDate.Minute);
			Assert.AreEqual(0, beginDate.Second);

			Assert.AreEqual(0, beginDate2.Hour);
			Assert.AreEqual(0, beginDate2.Minute);
			Assert.AreEqual(0, beginDate2.Second);
		}

		[TestMethod]
		public void ConvertToEndDateReturnsEndOfDay()
		{
			//Arrange
			DateTime endDate = default(DateTime);
			DateTime endDate2 = default(DateTime);

			//Act
			endDate = DateTimeUtility.ConvertToEndDate(DateTime.Now);
			endDate2 = DateTimeUtility.ConvertToEndDate(new DateTime(2007, 1, 1, 17, 45, 54));

			//Assert
			Assert.AreEqual(23, endDate.Hour);
			Assert.AreEqual(59, endDate.Minute);
			Assert.AreEqual(59, endDate.Second);
			
			Assert.AreEqual(23, endDate2.Hour);
			Assert.AreEqual(59, endDate2.Minute);
			Assert.AreEqual(59, endDate2.Second);
		}

		[TestMethod]
		public void TestIsSqlServerAppropriate()
		{
			Assert.IsTrue(DateTimeUtility.IsSqlServerAppropriate(DateTime.Now));
			Assert.IsTrue(DateTimeUtility.IsSqlServerAppropriate(DateTime.MaxValue));
			Assert.IsTrue(DateTimeUtility.IsSqlServerAppropriate(new DateTime(1753, 1, 1)));

			Assert.IsFalse(DateTimeUtility.IsSqlServerAppropriate(DateTime.MinValue));
			Assert.IsFalse(DateTimeUtility.IsSqlServerAppropriate(new DateTime(1752, 12, 31)));
		}

		[TestMethod]
		public void TestSqlServerMinimumDates()
		{
			Assert.AreEqual(1753, DateTimeUtility.SqlServerLongDateMinimum().Year);
			Assert.AreEqual(1900, DateTimeUtility.SqlServerShortDateMinimum().Year);
		}
	}
}
