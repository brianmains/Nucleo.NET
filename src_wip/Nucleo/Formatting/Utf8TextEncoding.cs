using System;
using ENC = System.Text.Encoding;


namespace Nucleo.Formatting
{
	public class Utf8TextEncoding : ITextEncoding
	{
		public byte[] ToBytes(string text)
		{
			return ENC.UTF8.GetBytes(text);
		}

		public string ToText(byte[] value)
		{
			return ENC.UTF8.GetString(value);
		}
	}
}
