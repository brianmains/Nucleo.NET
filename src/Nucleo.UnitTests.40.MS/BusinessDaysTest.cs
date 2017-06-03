using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo
{
	[TestClass]
	public class BusinessDaysTest
	{
		[TestMethod]
		public void Adding4DaysToAMondayDateAddsOK()
		{
			var days = new BusinessDays(4);

			var date = days.AddTo(new DateTime(2011, 2, 14));

			Assert.AreEqual("2/18/2011", date.ToShortDateString());
		}

		[TestMethod]
		public void Adding5DaysToAMondayDateAddsOK()
		{
			var days = new BusinessDays(5);

			var date = days.AddTo(new DateTime(2011, 2, 14));

			Assert.AreEqual("2/21/2011", date.ToShortDateString());
		}

		[TestMethod]
		public void Adding1DaysToAFridayDateAddsOK()
		{
			var days = new BusinessDays(1);

			var date = days.AddTo(new DateTime(2011, 2, 4));

			Assert.AreEqual("2/7/2011", date.ToShortDateString());
		}

		[TestMethod]
		public void Adding1DaysToASaturdayDateAddsOK()
		{
			var days = new BusinessDays(1);

			var date = days.AddTo(new DateTime(2011, 2, 5));

			Assert.AreEqual("2/7/2011", date.ToShortDateString());
		}






		[TestMethod]
		public void Subtracting4DaysToAFridayDateAddsOK()
		{
			var days = new BusinessDays(4);

			var date = days.SubtractFrom(new DateTime(2011, 2, 18));

			Assert.AreEqual("2/14/2011", date.ToShortDateString());
		}

		[TestMethod]
		public void Subtracting5DaysToAMondayDateAddsOK()
		{
			var days = new BusinessDays(5);

			var date = days.SubtractFrom(new DateTime(2011, 2, 2));

			Assert.AreEqual("1/26/2011", date.ToShortDateString());
		}

		[TestMethod]
		public void Subtracting1DaysToAFridayDateAddsOK()
		{
			var days = new BusinessDays(1);

			var date = days.SubtractFrom(new DateTime(2011, 2, 7));

			Assert.AreEqual("2/4/2011", date.ToShortDateString());
		}

		[TestMethod]
		public void Subtracting1DaysToASaturdayDateAddsOK()
		{
			var days = new BusinessDays(1);

			var date = days.SubtractFrom(new DateTime(2011, 2, 5));

			Assert.AreEqual("2/4/2011", date.ToShortDateString());
		}
	}
}
