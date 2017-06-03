using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Nucleo.Exceptions;


namespace Nucleo
{
	[TestClass]
	public class GuardTest
	{
		#region " Not Null Tests "

		[TestMethod]
		public void NotNullWithDateTimeReturnsTrue()
		{
			Guard.NotNull(new DateTime(2000, 11, 1));
		}

		[TestMethod]
		public void NotNullWithDefaultDateTimeReturnsTrue()
		{
			Guard.NotNull(default(DateTime));
		}

		[TestMethod]
		public void NotNullWithEmptyStringReturnsTrue()
		{
			Guard.NotNull(string.Empty);
		}

		[TestMethod]
		public void NotNullWithIntReturnsTrue()
		{
			Guard.NotNull(11);
		}

		[TestMethod]
		public void NotNullWithIntZeroReturnsTrue()
		{
			Guard.NotNull(0);
		}

		[TestMethod]
		public void NotNullWithNewObjectReturnsTrue()
		{
			Guard.NotNull(new object());
		}

		[TestMethod]
		public void NotNullWithStringReturnsTrue()
		{
			Guard.NotNull("ABC");
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void NotNullWithNullStringThrowsException()
		{
			Guard.NotNull(default(string));
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void NotNullWithNullableDateTimeThrowsException()
		{
			Guard.NotNull(default(DateTime?));
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void NotNullWithNullableIntThrowsException()
		{
			Guard.NotNull(default(int?));
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void NotNullWithNullObjectThrowsException()
		{
			Guard.NotNull(default(object));
		}

		#endregion



		#region " Not Null Safe Tests "

		[TestMethod]
		public void NotNullSafeWithDateTimeReturnsTrue()
		{
			Assert.IsTrue(Guard.NotNullSafe(new DateTime(2000, 11, 1)));
		}

		[TestMethod]
		public void NotNullSafeWithDefaultDateTimeReturnsTrue()
		{
			Assert.IsTrue(Guard.NotNullSafe(default(DateTime)));
		}

		[TestMethod]
		public void NotNullSafeWithEmptyStringReturnsTrue()
		{
			Assert.IsTrue(Guard.NotNullSafe(string.Empty));
		}

		[TestMethod]
		public void NotNullSafeWithIntReturnsTrue()
		{
			Assert.IsTrue(Guard.NotNullSafe(11));
		}

		[TestMethod]
		public void NotNullSafeWithIntZeroReturnsTrue()
		{
			Assert.IsTrue(Guard.NotNullSafe(0));
		}

		[TestMethod]
		public void NotNullSafeWithNewObjectReturnsTrue()
		{
			Assert.IsTrue(Guard.NotNullSafe(new object()));
		}

		[TestMethod]
		public void NotNullSafeWithStringReturnsTrue()
		{
			Assert.IsTrue(Guard.NotNullSafe("ABC"));
		}

		[TestMethod]
		public void NotNullSafeWithNullStringThrowsException()
		{
			Assert.IsFalse(Guard.NotNullSafe(default(string)));
		}

		[TestMethod]
		public void NotNullSafeWithNullableDateTimeThrowsException()
		{
			Assert.IsFalse(Guard.NotNullSafe(default(DateTime?)));
		}

		[TestMethod]
		public void NotNullSafeWithNullableIntThrowsException()
		{
			Assert.IsFalse(Guard.NotNullSafe(default(int?)));
		}

		[TestMethod]
		public void NotNullSafeWithNullObjectThrowsException()
		{
			Assert.IsFalse(Guard.NotNullSafe(default(object)));
		}

		#endregion



		#region " NotNullOrEmpty and NotNullOrEmptySafe Tests "

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void NotNullOrEmptyWorksFailsWithEmptyString()
		{
			Guard.NotNullOrEmpty(string.Empty);
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void NotNullOrEmptyWorksFailsWithNullString()
		{
			Guard.NotNullOrEmpty(null);
		}

		[TestMethod]
		public void NotNullOrEmptyWorksWithSpace()
		{
			Guard.NotNullOrEmpty(" ");
		}

		[TestMethod]
		public void NotNullOrEmptyWorksWithText()
		{
			Guard.NotNullOrEmpty("ABCS");
		}

		[TestMethod]
		public void NotNullOrEmptySafeWorksFailsWithEmptyString()
		{
			Assert.IsFalse(Guard.NotNullOrEmptySafe(string.Empty));
		}

		[TestMethod]
		public void NotNullOrEmptySafeWorksFailsWithNullString()
		{
			Assert.IsFalse(Guard.NotNullOrEmptySafe(null));
		}

		[TestMethod]
		public void NotNullOrEmptySafeWorksWithSpace()
		{
			Assert.IsTrue(Guard.NotNullOrEmptySafe(" "));
		}

		[TestMethod]
		public void NotNullOrEmptySafeWorksWithText()
		{
			Assert.IsTrue(Guard.NotNullOrEmptySafe("ABCS"));
		}

		#endregion
	}
}
