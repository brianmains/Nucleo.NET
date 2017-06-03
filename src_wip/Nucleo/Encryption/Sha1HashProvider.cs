using System;
using System.Security.Cryptography;


namespace Nucleo.Encryption
{
	/// <summary>
	/// Represents the hash provider using the SHA1 hash algorithm.
	/// </summary>
	public class Sha1HashProvider : IHashProvider
	{
		#region " Constructors "

		/// <summary>
		/// Creating the provider.
		/// </summary>
		public Sha1HashProvider() { }

		#endregion



		#region " Methods "

		private SHA1 GetHash()
		{
			return SHA1.Create();
		}

		public object Hash(object data)
		{
			var hash = this.GetHash();

			if (data is byte[])
				return hash.ComputeHash((byte[])data);
			else if (data is string)
				return hash.ComputeHash(System.Text.Encoding.Unicode.GetBytes((string)data));
			else
				return null;
		}

		#endregion
	}
}
