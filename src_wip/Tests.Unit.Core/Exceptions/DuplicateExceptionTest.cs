using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Exceptions
{
	[TestClass]
	public class DuplicateExceptionTest
	{
		[TestMethod]
		public void CreatingBaseExceptionCreatesOK()
		{
			var ex = new DuplicateException();

			Assert.AreEqual("A duplicate has been detected.", ex.Message);
		}

		[TestMethod]
		public void CreatingExceptionWithCustomMessageAndInnerExceptionCreatesOK()
		{
			var ex = new DuplicateException("A duplicate detected.", new ApplicationException());

			Assert.AreEqual("A duplicate detected.", ex.Message);
			Assert.IsNotNull(ex.InnerException);
		}

		[TestMethod]
		public void CreatingExceptionWithCustomMessageCreatesOK()
		{
			var ex = new DuplicateException("A duplicate detected.");

			Assert.AreEqual("A duplicate detected.", ex.Message);
		}
	}
}
