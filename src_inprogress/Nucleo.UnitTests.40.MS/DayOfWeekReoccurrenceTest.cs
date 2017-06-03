using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo
{
	[TestClass]
	public class DayOfWeekReoccurrenceTest
	{
		[TestMethod]
		public void TestCreatingReoccurrence()
		{
			DayOfWeekReoccurrence reoccurrence = new DayOfWeekReoccurrence(DayOfWeek.Monday, WeekNumber.First);

			Assert.AreEqual(DayOfWeek.Monday, reoccurrence.Days);
			Assert.AreEqual(WeekNumber.First, reoccurrence.WeekNumbers);

			reoccurrence = new DayOfWeekReoccurrence();
			reoccurrence.Days = DayOfWeek.Monday | DayOfWeek.Wednesday | DayOfWeek.Friday;
			reoccurrence.WeekNumbers = WeekNumber.First | WeekNumber.Third | WeekNumber.Fifth;

			Assert.IsTrue((reoccurrence.Days & DayOfWeek.Monday) > 0);
			Assert.IsTrue((reoccurrence.Days & DayOfWeek.Wednesday) > 0);
			Assert.IsTrue((reoccurrence.Days & DayOfWeek.Friday) > 0);
			Assert.IsTrue((reoccurrence.WeekNumbers & WeekNumber.First) > 0);
			Assert.IsTrue((reoccurrence.WeekNumbers & WeekNumber.Third) > 0);
			Assert.IsTrue((reoccurrence.WeekNumbers & WeekNumber.Fifth) > 0);
		}
	}
}