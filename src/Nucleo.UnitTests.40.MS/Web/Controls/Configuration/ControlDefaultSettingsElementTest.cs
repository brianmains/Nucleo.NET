using System;
using System.Configuration;
using Nucleo.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Web.Controls.Configuration
{
	[TestClass]
	public class ControlDefaultSettingsElementTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingAndSettingPropertiesAssignsCorrectly()
		{
			//Arrange
			var element = new ControlDefaultSettingsElement();
			
			//Act
			element.TypeName = "My Type";
			element.Entries.Add(new NameValueElement("UseDefault", false));
			element.Entries.Add(new NameValueElement("UseConfig", true));

			//Assert
			Assert.AreEqual("My Type", element.TypeName);
			Assert.AreEqual(2, element.Entries.Count);

		}

		#endregion
	}
}
