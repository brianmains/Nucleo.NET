using System;
using System.Collections.Generic;

using Microsoft.Practices.EnterpriseLibrary.Security.Cryptography;


namespace Nucleo.Context.Services
{
	/// <summary>
	/// Represents the encryption service using the enterprise library application block.
	/// </summary>
	public class EnterpriseLibraryEncryptionService : IEncryptionService
	{
		private string _encryptionProvider = null;
		private string _hashProvider = null;



		#region " Constructors "

		public EnterpriseLibraryEncryptionService(string encryptionProvider, string hashProvider)
		{
			_encryptionProvider = encryptionProvider;
			_hashProvider = hashProvider;
		}

		#endregion



		#region " Methods "

		public object Decrypt(object source)
		{
			if (source is string)
				return Cryptographer.DecryptSymmetric(_encryptionProvider, (string)source);
			else if (source is byte[])
				return Cryptographer.DecryptSymmetric(_encryptionProvider, (byte[])source);
			else
				return null;
		}

		public object Encrypt(object source)
		{
			if (source is string)
				return Cryptographer.EncryptSymmetric(_encryptionProvider, (string)source);
			else if (source is byte[])
				return Cryptographer.EncryptSymmetric(_encryptionProvider, (byte[])source);
			else
				return null;
		}

		public object Hash(object source)
		{
			if (source is string)
				return Cryptographer.CreateHash(_hashProvider, (string)source);
			else if (source is byte[])
				return Cryptographer.CreateHash(_hashProvider, (byte[])source);
			else
				return null;
		}

		#endregion
	}
}
