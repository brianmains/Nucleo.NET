using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Web.NavigationControls
{
	[TestClass]
	public class NavigationBarTest
	{
		#region " Tests "

		[TestMethod]
		public void AddingItemsChangesSelection()
		{
			//Arrange
			var barFake = Isolate.Fake.Instance<NavigationBar>(Members.CallOriginal);

			//Act
			barFake.Items.Add(new NavigationBarItem { IsSelected = false });
			barFake.Items.Add(new NavigationBarItem { IsSelected = true });
			bool hasSelectedItem = (barFake.SelectedItem != null);

			var item1 = new NavigationBarItem { IsSelected = true };
			barFake.Items.Add(item1);

			object selectedItem1 = barFake.SelectedItem;

			var item2 = new NavigationBarItem { IsSelected = true };
			barFake.Items.Add(item2);

			object selectedItem2 = barFake.SelectedItem;

			//Assert
			Assert.AreEqual(true, hasSelectedItem, "No selected item");
			Assert.AreEqual(item1, selectedItem1, "Item 1 not equal");
			Assert.AreEqual(item2, selectedItem2, "Item 2 not equal");

			Isolate.CleanUp();
		}

		[TestMethod]
		public void AddingItemsRemovesPreviousSelectedItemStatus()
		{
			//Arrange
			var barFake = Isolate.Fake.Instance<NavigationBar>(Members.CallOriginal);

			//Act
			barFake.Items.Add(new NavigationBarItem { IsSelected = true });
			barFake.Items.Add(new NavigationBarItem { IsSelected = true });

			//Assert
			Assert.AreEqual(false, barFake.Items[0].IsSelected);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void ClearingSelectionsWorksCorrectly()
		{
			//Arrange
			var barFake = Isolate.Fake.Instance<NavigationBar>(Members.CallOriginal);
			var itemCollection = new NavigationBarItemCollection(barFake);

			var itemFake = Isolate.Fake.Instance<NavigationBarItem>(Members.CallOriginal);
			Isolate.WhenCalled(() => itemFake.IsSelected).WillReturn(true);
			Isolate.WhenCalled(() => itemFake.IsSelected).CallOriginal();

			itemCollection.Add(new NavigationBarItem());
			itemCollection.Add(itemFake);
			itemCollection.Add(new NavigationBarItem());
			itemCollection.Add(new NavigationBarItem());

			//Act
			barFake.ClearSelections();

			//Assert
			Assert.IsNull(barFake.SelectedItem);

			Isolate.CleanUp();
		}

		#endregion
	}
}
