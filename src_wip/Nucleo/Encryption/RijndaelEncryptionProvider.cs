using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;


namespace Nucleo.Encryption
{
	public class RijndaelEncryptionProvider : IEncryptionProvider
	{
		private byte[] _key;
		private byte[] _salt;



		#region " Constructors "

		public RijndaelEncryptionProvider(byte[] salt, byte[] key)
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

			var passwordBytes = new PasswordDeriveBytes(_key, _salt);
			MemoryStream ms = new MemoryStream();

			Rijndael alg = Rijndael.Create();

			alg.Key = passwordBytes.GetBytes(32);
			alg.IV = passwordBytes.GetBytes(16);

			CryptoStream cs = new CryptoStream(ms,
				alg.CreateDecryptor(), CryptoStreamMode.Write);

			cs.Write(data, 0, data.Length);
			cs.FlushFinalBlock();
			cs.Close(); 

			byte[] decryptedData = ms.ToArray();
			return decryptedData; 
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

			var passwordBytes = new PasswordDeriveBytes(_key, _salt);

			MemoryStream ms = new MemoryStream();
			Rijndael alg = Rijndael.Create();

			alg.Key = passwordBytes.GetBytes(32);
			alg.IV = passwordBytes.GetBytes(16);

			CryptoStream cs = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write);

			cs.Write(data, 0, data.Length);
			cs.Close();

			byte[] encryptedData = ms.ToArray();
			return encryptedData;
		}

		#endregion
	}
}
