using System;
using System.Collections.Generic;
using System.Linq;


namespace Nucleo.Security
{
	/// <summary>
	/// Represents the provider to authenticate users in the system.
	/// </summary>
	public interface IAuthenticationProvider : ISecurityProvider
	{
		#region " Methods "

		/// <summary>
		/// Authenticates the user against the system, returning the status of the authentication.
		/// </summary>
		/// <param name="userName">The name of the user.</param>
		/// <param name="password">The password (either encrypted, hashed, or plain text).</param>
		/// <returns>The authentication result.</returns>
		AuthenticationResult Authenticate(string userName, string password);

		#endregion
	}
}
