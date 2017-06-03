using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo
{
	/// <summary>
	/// Represents the details of exception testing.
	/// </summary>
	public class ExceptionTestingSource
	{
		private bool _shouldThrowException = true;



		#region " Properties "

		/// <summary>
		/// Gets or sets whether an exception should be thrown in the current condition.
		/// </summary>
		public bool ShouldThrowException
		{
			get { return _shouldThrowException; }
			set { _shouldThrowException = value; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the source.
		/// </summary>
		public ExceptionTestingSource() { }

		/// <summary>
		/// Creates the source, specifying exception checking.
		/// </summary>
		/// <param name="shouldThrowException">Should an exception be thrown?</param>
		public ExceptionTestingSource(bool shouldThrowException)
		{
			_shouldThrowException = shouldThrowException;
		}

		#endregion
	}
}
