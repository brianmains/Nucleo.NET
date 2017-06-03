using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;


namespace Nucleo.Encryption
{
	public class AESEncryptionProvider : IEncryptionProvider
	{
		private byte[] _key;
		private byte[] _salt;



		#region " Constructors "

		public AESEncryptionProvider(byte[] salt, byte[] key)
		{
			if (salt == null)
				throw new ArgumentNullException("salt");
			if (key == null)
				key = salt;

			_salt = salt;
			_key = key;
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Decrypts the data into the underlying object.
		/// </summary>
		/// <param name="data">The data to decrypt.</param>
		/// <returns>The final data.</returns>
		public byte[] Decrypt(byte[] data)
		{
			if (data == null)
				throw new ArgumentNullException("data");

			// Initialise
			AesManaged decryptor = new AesManaged();
			var derivedBytes = new Rfc2898DeriveBytes(_key, _salt, 1);

			// Set the key
			decryptor.Key = derivedBytes.GetBytes(32);
			decryptor.IV = derivedBytes.GetBytes(16);

			// create a memory stream
			using (MemoryStream decryptionStream = new MemoryStream())
			{
				// Create the crypto stream
				using (CryptoStream decrypt = new CryptoStream(decryptionStream, 
					decryptor.CreateDecryptor(), CryptoStreamMode.Write))
				{
					// Encrypt
					decrypt.Write(data, 0, data.Length);
					decrypt.Flush();
					decrypt.Close();

					// Return the unencrypted data
					return decryptionStream.ToArray();
				}
			}
		}

		/// <summary>
		/// Encrypts the data into the underlying object.
		/// </summary>
		/// <param name="data">The data to encrypt.</param>
		/// <returns>The final data.</returns>
		public byte[] Encrypt(byte[] data)
		{
			if (data == null)
				throw new ArgumentNullException("data");

			// Initialise
			AesManaged encryptor = new AesManaged();
			var derivedBytes = new Rfc2898DeriveBytes(_key, _salt, 1);

			// Set the key
			encryptor.Key = derivedBytes.GetBytes(32);
			encryptor.IV = derivedBytes.GetBytes(16);

			// create a memory stream
			using (MemoryStream encryptionStream = new MemoryStream())
			{
				// Create the crypto stream
				using (CryptoStream encrypt = new CryptoStream(encryptionStream, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
				{
					// Encrypt
					encrypt.Write(data, 0, data.Length);
					//encrypt.FlushFinalBlock();
					encrypt.Close();

					// Return the encrypted data
					return encryptionStream.ToArray();
				}
			}
		}

		#endregion
	}
}
