using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Nucleo.Web.ClientRegistration;


namespace Nucleo.Web.ControlStorage
{
	[TestClass]
	public class ControlPropertyOptionsTest
	{
		[TestMethod]
		public void GettingAndSettingPropertiesWorksOK()
		{
			//Arrange
			var options = new ControlPropertyOptions();

			//Act
			options.ContentType = ClientPropertyContentType.AjaxComponent;
			options.Storage = ControlPropertyStorage.Persist;

			//Assert
			Assert.AreEqual(ClientPropertyContentType.AjaxComponent, options.ContentType);
			Assert.AreEqual(ControlPropertyStorage.Persist, options.Storage);
		}
	}
}
