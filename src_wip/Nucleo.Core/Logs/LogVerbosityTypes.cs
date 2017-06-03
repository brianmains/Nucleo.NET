using System;
using System.Collections.Generic;


namespace Nucleo.Logs
{
	/// <summary>
	/// Represents the log verbosity types.
	/// </summary>
	public static class LogVerbosityTypes
	{
		/// <summary>
		/// Gets the default collection of verbosity types.
		/// </summary>
		public static LogVerbosityTypeCollection Default
		{
			get
			{
				LogVerbosityTypeCollection verbosityTypes = new LogVerbosityTypeCollection();
				verbosityTypes.Add(new LogVerbosityType("Minimal", 0));
				verbosityTypes.Add(new LogVerbosityType("Normal", 127));
				verbosityTypes.Add(new LogVerbosityType("Verbose", 255));

				return verbosityTypes;
			}
		}
	}
}
