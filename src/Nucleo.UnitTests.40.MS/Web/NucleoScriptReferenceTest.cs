using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Web
{
	[TestClass]
	public class NucleoScriptReferenceTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingAndSettingPathReturnsCorrectValue()
		{
			NucleoScriptReference reference = new NucleoScriptReference();
			reference.OriginalPath = "Test";
			Assert.AreEqual("Test", reference.OriginalPath);


			reference = new NucleoScriptReference("TestPath", "OriginalPath", true);
			Assert.AreEqual("OriginalPath", reference.OriginalPath);

			reference = new NucleoScriptReference("TestPath", "OriginalPath", false);
			Assert.IsTrue(string.IsNullOrEmpty(reference.OriginalPath));
		}

		#endregion
	}
}
