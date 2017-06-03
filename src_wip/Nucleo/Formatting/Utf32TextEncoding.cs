using System;
using ENC = System.Text.Encoding;


namespace Nucleo.Formatting
{
	public class Utf32TextEncoding : ITextEncoding
	{
		public byte[] ToBytes(string text)
		{
			return ENC.UTF32.GetBytes(text);
		}

		public string ToText(byte[] value)
		{
			return ENC.UTF32.GetString(value);
		}
	}
}
