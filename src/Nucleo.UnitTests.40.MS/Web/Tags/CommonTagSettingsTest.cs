using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Web.Tags
{
	[TestClass]
	public class CommonTagSettingsTest
	{
		#region " Tests "

		[TestMethod]
		public void SettingIDAndNameAddsAttributesCorrectly()
		{
			//Arrange
			var controlFake = Isolate.Fake.Instance<Panel>();
			Isolate.WhenCalled(() => controlFake.ClientID).WillReturn("ctl100_label");
			Isolate.WhenCalled(() => controlFake.UniqueID).WillReturn("ctl100$label");

			TagElement tag = new TagElement("DIV");

			//Act
			CommonTagSettings.SetIdentifiers(tag, controlFake);

			//Assert
			Assert.AreEqual(2, tag.Attributes.AttributeCount);
			Assert.AreEqual("ctl100_label", tag.Attributes.GetAttribute("id").Value);
			Assert.AreEqual("ctl100$label", tag.Attributes.GetAttribute("name").Value);
		}

		#endregion
	}
}
