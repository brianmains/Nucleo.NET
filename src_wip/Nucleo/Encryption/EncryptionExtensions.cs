using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Formatting;


namespace Nucleo.Encryption
{
	public static class EncryptionExtensions
	{
		public static string Decrypt(this IEncryptionProvider provider, string data, ITextEncoding encoder)
		{
			if (data == null)
				throw new ArgumentNullException("data");
			if (encoder == null)
				encoder = new UnicodeTextEncoding();

			var output = provider.Decrypt(encoder.ToBytes(data));
			return encoder.ToText(output);
		}

		public static string Decrypt(this IEncryptionProvider provider, byte[] data, ITextEncoding encoder)
		{
			if (data == null)
				throw new ArgumentNullException("data");
			if (encoder == null)
				encoder = new UnicodeTextEncoding();

			var output = provider.Decrypt(data);
			return encoder.ToText(output);
		}

		public static string Encrypt(this IEncryptionProvider provider, string data, ITextEncoding encoder)
		{
			if (data == null)
				throw new ArgumentNullException("data");
			if (encoder == null)
				encoder = new UnicodeTextEncoding();

			var output = provider.Encrypt(encoder.ToBytes(data));
			return encoder.ToText(output);
		}

		public static string Encrypt(this IEncryptionProvider provider, byte[] data, ITextEncoding encoder)
		{
			if (data == null)
				throw new ArgumentNullException("data");
			if (encoder == null)
				encoder = new UnicodeTextEncoding();

			var output = provider.Encrypt(data);
			return encoder.ToText(output);
		}
	}
}
