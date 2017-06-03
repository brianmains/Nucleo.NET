using System;


namespace Nucleo.Encryption
{
	/// <summary>
	/// Represents the provider for encrypting, decrypting, or hashing data.
	/// </summary>
	public interface IEncryptionProvider
	{
		#region " Methods "

		/// <summary>
		/// Decrypts the data into the underlying object.
		/// </summary>
		/// <param name="data">The data to decrypt.</param>
		/// <returns>The final data.</returns>
		byte[] Decrypt(byte[] data);

		/// <summary>
		/// Encrypts the data into the underlying object.
		/// </summary>
		/// <param name="data">The data to encrypt.</param>
		/// <returns>The final data.</returns>
		byte[] Encrypt(byte[] data);

		#endregion
	}
}
