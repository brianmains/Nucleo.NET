using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Web.NavigationControls
{
	[TestClass]
	public class NavigationBarItemTest
	{
		#region " Tests "

		[TestMethod]
		public void SelectingItemClearsOtherSelections()
		{
			//Arrange
			var barFake = Isolate.Fake.Instance<NavigationBar>(Members.CallOriginal);
			barFake.Items.Add(new NavigationBarItem());
			barFake.Items.Add(new NavigationBarItem());
			
			//Act
			barFake.Items[0].IsSelected = true;
			barFake.Items[1].IsSelected = true;

			//Assert
			Assert.IsFalse(barFake.Items[0].IsSelected);
		}

		#endregion
	}
}
