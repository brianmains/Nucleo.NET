using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Web.StandardizationControls
{
	[TestClass]
	public class BaseHeaderTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingAndSettingPropsWorksOK()
		{
			var header = Isolate.Fake.Instance<BaseHeader>(Members.CallOriginal, ConstructorWillBe.Ignored);

			header.ImageUrl = "X";
			header.Text = "Y";

			Assert.AreEqual("X", header.ImageUrl);
			Assert.AreEqual("Y", header.Text);
		}

		#endregion
	}
}
