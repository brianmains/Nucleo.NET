using System;



namespace Nucleo.Services
{
	/// <summary>
	/// Represents the service used to interact with the session state of the current browsing session.
	/// </summary>
	/// <example>
	/// var context = ApplicationContext.GetCurrent();
	/// var obj = context.GetService&lt;ISessionStateService>();
	/// //Use object
	/// </example
	public interface ISessionStateService : ICollectionService
	{
		#region " Properties "

		/// <summary>
		/// Gets the unique key for the session.
		/// </summary>
		string UniqueKey { get; }

		#endregion



		#region " Methods "

		/// <summary>
		/// Clears the current session.
		/// </summary>
		void Clear();

		#endregion
	}
}
