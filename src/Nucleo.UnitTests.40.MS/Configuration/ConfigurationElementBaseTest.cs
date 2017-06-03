using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Configuration
{
	[TestClass]
	public class ConfigurationElementBaseTest : ConfigurationElementBase
	{
		private string _uniqueKey = null;



		#region " Properties "

		protected override string UniqueKey
		{
			get { return _uniqueKey; }
		}

		#endregion



		#region " Test "

		[TestMethod]
		public void GettingAndSettingUniqueKeyWorks()
		{
			_uniqueKey = "Value";
			Assert.AreEqual("Value", this.UniqueKey);
		}

		#endregion
	}
}
