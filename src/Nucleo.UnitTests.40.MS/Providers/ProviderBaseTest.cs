using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Providers
{
	[TestClass]
	public class ProviderBaseTest : ProviderBase
	{
		private string _name = null;



		#region " Properties "

		public string FriendlyName
		{
			get { return _name; }
			set { _name = value; }
		}

		public override string Name
		{
			get { return _name; }
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void GettingAndSettingApplicationNameWorksOK()
		{
			//Arrange
			var provider = new ProviderBaseTest();

			//Act
			provider.ApplicationName = "Test";

			//Assert
			Assert.AreEqual("Test", provider.ApplicationName);
		}

		#endregion
	}
}
