using System;
using System.Collections.Generic;
using System.Web.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Web.ClientState;
using Nucleo.Web.Templates;


namespace Nucleo.Web.AccordionControls
{
	[TestClass]
	public class AccordionItemTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingItemWithParametersWorksOK()
		{
			//Arrange
			var content = Isolate.Fake.Instance<ITemplate>();

			//Act
			var item = new AccordionItem("My Title", content);

			//Assert
			Assert.AreEqual("My Title", item.Title);
			Assert.AreEqual(content, item.Content);
		}

		[TestMethod]
		public void GettingTemplateContentReturnsCorrectValue()
		{
			//Arrange
			var item = new AccordionItem();
			item.Content = new FakeTemplate("This is my fake content");

			//Act
			string content = item.GetTemplateContent();

			//Assert
			StringAssert.Contains(content, "This is my fake content", "Template content doesn't have message");
		}

		[TestMethod]
		public void LoadingClientStateBringsInValues()
		{
			//Arrange
			var data = new ClientStateData();
			data.Values.Add("isSelected", true);

			//Act
			var item = new AccordionItem();
			((IClientStateControl)item).LoadClientState(data);

			//Assert
			Assert.AreEqual(true, item.IsSelected);
		}

		[TestMethod]
		public void SettingSelectedToTrueFiresEvent()
		{
			//Arrange
			var item = new AccordionItem();
			var hasFired = false;

			item.Selected += delegate(object sender, EventArgs e)
			{
				hasFired = true;
			};

			//Act
			item.IsSelected = true;

			//Assert
			Assert.AreEqual(true, hasFired, "Selected event not fired");
		}

		#endregion
	}
}
