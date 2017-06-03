using System;
using Nucleo.Logs;


namespace Nucleo.Context.Services
{
	/// <summary>
	/// Represents the user interface for logging emails.  The <see cref="ILogManager">ILogManager interface</see> defines some of the core methods; this method extends the service.
	/// </summary>
	/// <example>
	/// var context = ApplicationContext.GetCurrent();
	/// var obj = context.GetService&lt;ILoggerService>();
	/// //Use object
	/// </example>
	public interface ILoggerService : ILogManager, IService
	{
		/// <summary>
		/// Gets the message types registered with the logger.
		/// </summary>
		/// <returns>The collection of message types.</returns>
		LogMessageTypeCollection GetMessageTypes();

		/// <summary>
		/// Gets the verbosity types registered with the logger.
		/// </summary>
		/// <returns>The collection of verbosity types.</returns>
		LogVerbosityTypeCollection GetVerbosityTypes();
	}
}
