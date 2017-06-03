using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Providers.Configuration
{
	[TestClass]
	public class ProviderConfigurationSectionBaseTest : ProviderConfigurationSectionBase
	{
		#region " Tests "

		[TestMethod]
		public void DefaultProviderIsNotNull()
		{
			this.DefaultProvider = "Test";
			Assert.IsNotNull(this.DefaultProvider);
			Assert.AreEqual("Test", this.DefaultProvider);
		}

		[TestMethod]
		public void GettingProviderListHasFourEntries()
		{
			this.Providers.Clear();
			this.Providers.Add(new ProviderSettings("MyProvider", "System.MyProvider"));
			this.Providers.Add(new ProviderSettings("Test", "Nucleo.MyProvider"));
			this.Providers.Add(new ProviderSettings("System", "System.Web.MyProvider"));
			this.Providers.Add(new ProviderSettings("Nucleo", "Nucleo.Web.MyProvider"));

			Assert.AreEqual(4, this.Providers.Count);
			Assert.AreEqual("MyProvider", this.Providers[0].Name);
			Assert.AreEqual("System.MyProvider", this.Providers[0].Type);
			Assert.AreEqual("Nucleo", this.Providers[3].Name);
			Assert.AreEqual("Nucleo.Web.MyProvider", this.Providers[3].Type);
		}

		#endregion
	}
}
