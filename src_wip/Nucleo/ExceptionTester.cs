using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Exceptions;


namespace Nucleo
{
	public static class ExceptionTester
	{
		#region " Methods "

		public static bool CheckException(bool shouldThrow, Action<ExceptionTestingSource> action)
		{
			string message = shouldThrow
				? "An exception should have been thrown, but no exception occurred."
				: "An exception should not have been thrown, but one did occur.";

			return CheckException(shouldThrow, action, message);
		}

		public static bool CheckException(bool shouldThrow, Action<ExceptionTestingSource> action, string message)
		{
			try
			{
				action(new ExceptionTestingSource(shouldThrow));
				if (shouldThrow)
					throw new AssertionFailedException(message);
			}
			catch (AssertionFailedException aex)
			{
				throw;
			}
			catch (Exception ex)
			{
				if (!shouldThrow)
					throw new AssertionFailedException(message, ex);
			}

			return true;
		}

		#endregion
	}
}
