using System;
using ENC = System.Text.Encoding;


namespace Nucleo.Formatting
{
	public class AsciiTextEncoding : ITextEncoding
	{
		public byte[] ToBytes(string text)
		{
			return ENC.ASCII.GetBytes(text);
		}

		public string ToText(byte[] value)
		{
			return ENC.ASCII.GetString(value);
		}
	}
}
