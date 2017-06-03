using System;
using System.Web.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Web.Pages;


namespace Nucleo.Web.AccordionControls
{
	[TestClass]
	public class AccordionTest
	{
		#region " Tests "

		[TestMethod]
		public void AddingItemThatsSelectedUpdatesSelectedItem()
		{
			//Arrange
			var item1 = new AccordionItem();
			var item2 = new AccordionItem { IsSelected = true };
			var item3 = new AccordionItem();

			var accordion = new Accordion();
			accordion.Items.Add(item1);
			accordion.Items.Add(item2);
			accordion.Items.Add(item3);

			var newItem = new AccordionItem { IsSelected = true };

			//Act
			accordion.Items.Add(newItem);

			//Assert
			Assert.AreEqual(newItem, accordion.SelectedItem);
			Assert.AreEqual(false, item2.IsSelected);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void PreRenderDoesntSelectFirstItemIfNoItemsInList()
		{
			//Arrange
			var accordion = new Accordion { RegisterWithScriptManager = false };
			var page = new FakePage(accordion);

			//Act
			var oldSelection = accordion.SelectedItem;
			page.FireEvent(PageEvent.PreRender);

			//Assert
			Assert.IsNull(oldSelection, "Had a selection before event");
			Assert.AreEqual(null, accordion.SelectedItem, "PreRender didn't select an item");

			Isolate.CleanUp();
		}

		[TestMethod]
		public void PreRenderSelectsFirstItemIfItemsInList()
		{
			//Arrange
			var item1 = new AccordionItem();
			var item2 = new AccordionItem();
			var item3 = new AccordionItem();

			var accordion = new Accordion { RegisterWithScriptManager = false };
			accordion.Items.Add(item1);
			accordion.Items.Add(item2);
			accordion.Items.Add(item3);
			var page = new FakePage(accordion);
			
			//Act
			var oldSelection = accordion.SelectedItem;
			page.FireEvent(PageEvent.PreRender);

			//Assert
			Assert.IsNull(oldSelection, "Had a selection before event");
			Assert.AreEqual(item1, accordion.SelectedItem, "PreRender didn't select an item");

			Isolate.CleanUp();
		}

		[TestMethod]
		public void RemovingSelectedItemSelectsFirstItemInList()
		{
			//Arrange
			var item1 = new AccordionItem { IsSelected = true };
			var item2 = new AccordionItem();
			var item3 = new AccordionItem();
			
			var accordion = new Accordion();
			accordion.Items.Add(item1);
			accordion.Items.Add(item2);
			accordion.Items.Add(item3);

			//Act
			accordion.Items.RemoveAt(0);

			//Assert
			Assert.AreEqual(item2, accordion.SelectedItem, "Selected item didn't swap to new first item");

			Isolate.CleanUp();
		}

		[TestMethod]
		public void SelectingAnItemUpdatesSelectedItemProperty()
		{
			//Arrange
			var item1 = new AccordionItem();
			var item2 = new AccordionItem();
			var item3 = new AccordionItem();

			var accordion = new Accordion();
			accordion.Items.Add(item1);
			accordion.Items.Add(item2);
			accordion.Items.Add(item3);

			//Act
			item2.IsSelected = true;

			//Assert
			Assert.AreEqual(item2, accordion.SelectedItem);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void SettingItemSelectionUpdatesAccordingly()
		{
			//Arrange
			var item1 = new AccordionItem();
			var item2 = new AccordionItem();
			var item3 = new AccordionItem();

			var accordion = new Accordion();
			accordion.Items.Add(item1);
			accordion.Items.Add(item2);
			accordion.Items.Add(item3);

			//Act
			accordion.SelectedItem = item2;

			//Assert
			Assert.AreEqual(item2, accordion.SelectedItem, "incorrect selected item");
			Assert.IsFalse(item1.IsSelected, "item1 selected");
			Assert.IsFalse(item3.IsSelected, "item3 selected");
			Assert.IsTrue(item2.IsSelected, "item2 not selected");

			Isolate.CleanUp();
		}

		#endregion
	}
}
