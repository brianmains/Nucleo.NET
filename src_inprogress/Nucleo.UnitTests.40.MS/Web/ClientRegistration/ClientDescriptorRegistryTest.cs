using System;
using System.Web.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Nucleo.TestingTools;


namespace Nucleo.Web.ClientRegistration
{
	[TestClass]
	public class ClientDescriptorRegistryTest
	{
		#region " Test Classes "

		[ClientDescriptionRegistration]
		protected class TestClass
		{
			public string A
			{
				get;
				set;
			}

			public int Key
			{
				get;
				set;
			}

			[ClientProperty("name", ClientMemberType.Property)]
			public string Name
			{
				get;
				set;
			}

			[ClientEvent("valueChanged")]
			public string OnClientValueChanged
			{
				get;
				set;
			}
			
			[ClientProperty("value", ClientMemberType.Property)]
			public string Value
			{
				get;
				set;
			}
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void CreatingRegistryForNullValueThrowsException()
		{
			//Arrange

			//Act

			//Assert
			ExceptionTester.CheckException(true, (src) => { ClientDescriptorRegistry.CreateFor(null); });
		}

		[TestMethod]
		public void CreatingRegistryWorksOK()
		{
			//Arrange
			var registry = default(ClientDescriptorRegistry);
			var obj = new TestClass { Name = "DSF", OnClientValueChanged = "fn", Value = "45" };

			//Act
			registry = ClientDescriptorRegistry.CreateFor(obj);

			//Assert
			Assert.IsNotNull(registry);
			Assert.AreEqual(2, registry.Properties.Count);
			Assert.AreEqual(1, registry.Events.Count);
		}

		#endregion
	}
}
