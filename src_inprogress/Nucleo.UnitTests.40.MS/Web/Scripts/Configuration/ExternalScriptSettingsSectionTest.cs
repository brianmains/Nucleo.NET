using System;
using System.Configuration;
using System.Web.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Web.Scripts.Configuration
{
	[TestClass]
	public class ExternalScriptSettingsSectionTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingAndSettingExternalScriptsWorksWithListCorrectly()
		{
			//Arrange
			ExternalScriptSettingsSection section = new ExternalScriptSettingsSection();
			
			//Act
			section.ExternalScripts.Add(new ExternalScriptElement("Key", "Mypath", "Mypathrelease"));
			section.ExternalScripts.Add(new ExternalScriptElement("Key2", "Mypath2", "Mypathrelease2"));
			section.ExternalScripts.Add(new ExternalScriptElement("Key3", "Mypath3", "Mypathrelease3"));

			//Assert
			Assert.AreEqual(3, section.ExternalScripts.Count);
		}

		#endregion
	}
}
