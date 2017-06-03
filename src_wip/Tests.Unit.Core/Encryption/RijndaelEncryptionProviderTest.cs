using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Nucleo.Formatting;


namespace Nucleo.Encryption
{
	[TestClass]
	public class RijndaelEncryptionProviderTest
	{
		[TestMethod]
		public void EncryptingAndDecryptingDataWorksOK()
		{
			var provider = new RijndaelEncryptionProvider(new byte[] { 1, 2, 3, 4, 6, 7, 8, 9, 10, 11 },
				new byte[] { 12, 22, 32, 42, 26, 27, 28, 29, 20, 12 });
			var data = provider.Encrypt("My data", new UnicodeTextEncoding());

			var output = provider.Decrypt(data, new UnicodeTextEncoding());

			Assert.AreEqual("My data", output);
		}
	}
}
