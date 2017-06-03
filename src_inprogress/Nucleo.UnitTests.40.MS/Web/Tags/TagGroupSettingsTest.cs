using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Web.Tags
{
	[TestClass]
	public class TagGroupSettingsTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingGroupSettingsWorksCorrectly()
		{
			//Arrange
			var ruleFake = Isolate.Fake.Instance<TagGroupRule>();

			//Act
			var groupSettings = new TagGroupSettings(ruleFake);

			//Assert
			Assert.AreEqual(ruleFake, groupSettings.Rule);
		}

		#endregion
	}
}
