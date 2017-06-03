using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Email;


namespace Nucleo.Email.Configuration
{
	[TestClass]
	public class EmailSectionTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingAndSettingValuesWorksCorrectly()
		{
			EmailSection section = new EmailSection();
			section.DefaultProviderType = "My Test";
			Assert.AreEqual("My Test", section.DefaultProviderType);
		}

		#endregion
	}
}
