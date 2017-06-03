using System;
using ENC = System.Text.Encoding;


namespace Nucleo.Formatting
{
	public class Utf7TextEncoding : ITextEncoding
	{
		public byte[] ToBytes(string text)
		{
			return ENC.UTF7.GetBytes(text);
		}

		public string ToText(byte[] value)
		{
			return ENC.UTF7.GetString(value);
		}
	}
}
