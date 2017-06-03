using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Formatting
{
	public class Base64TextEncoding : ITextEncoding
	{
		public byte[] ToBytes(string text)
		{
			return Convert.FromBase64String(text);
		}

		public string ToText(byte[] value)
		{
			return Convert.ToBase64String(value);
		}
	}
}
