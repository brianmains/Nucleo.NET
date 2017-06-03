using System;
using ENC = System.Text.Encoding;


namespace Nucleo.Formatting
{
	public class UnicodeTextEncoding : ITextEncoding
	{
		public byte[] ToBytes(string text)
		{
			return ENC.Unicode.GetBytes(text);
		}		

		public string ToText(byte[] value)
		{
			return ENC.Unicode.GetString(value);
		}
	}
}
