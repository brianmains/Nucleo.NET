using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Encryption
{
	[TestClass]
	public class Sha1HashProviderTest
	{
		[TestMethod]
		public void CreatingProviderWithEmptyConstructorWorksOK()
		{
			new Sha1HashProvider();
		}
	}
}
