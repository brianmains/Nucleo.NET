using System;
using System.Text;


namespace Nucleo.Formatting
{
	public interface ITextEncoding
	{
		byte[] ToBytes(string text);

		string ToText(byte[] value);
	}
}
