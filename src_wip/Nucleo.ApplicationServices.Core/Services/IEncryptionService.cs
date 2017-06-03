using System;


namespace Nucleo.Services
{
	/// <summary>
	/// Represents a service to handle encryption capabilities.
	/// </summary>
	public interface IEncryptionService : IService
	{
		#region " Methods "

		/// <summary>
		/// Decrypts the value to the final value.
		/// </summary>
		/// <param name="source">The encrypted value to decrypt.</param>
		/// <returns>The decrypted value.</returns>
		object Decrypt(object source);

		/// <summary>
		/// Encrypts the value to the final value.
		/// </summary>
		/// <param name="source">The decrypted value to encrypt.</param>
		/// <returns>The encrypted value.</returns>
		object Encrypt(object source);

		/// <summary>
		/// Hashes the value to the final value.
		/// </summary>
		/// <param name="source">The value to hash.</param>
		/// <returns>The hashed value.</returns>
		object Hash(object source);

		#endregion
	}
}
