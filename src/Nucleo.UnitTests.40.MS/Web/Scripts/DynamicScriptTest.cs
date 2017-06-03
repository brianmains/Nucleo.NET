using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Web.Scripts
{
	[TestClass]
	public class DynamicScriptTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingAndSettingPropertiesWorksOKs()
		{
			//Act
			var script = new DynamicScript
			{
				Name = "A",
				Path = "test.js"
			};

			//Assert
			Assert.AreEqual("A", script.Name);
			Assert.AreEqual("test.js", script.Path);
		}

		#endregion
	}
}
