using System;
using System.Web.UI;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Web.Images
{
	[TestClass]
	public class ImageItemCollectionTest
	{
		#region " Tests "

		[TestMethod]
		public void LoadingItemsFromStateWorksOK()
		{
			//Arrange
			string[] items = new string[] { "a.png", "b.png", "c.png" };

			//Act
			var coll = new ImageItemCollection();
			((IStateManager)coll).LoadViewState(items);

			//Assert
			Assert.AreEqual(3, coll.Count);
			Assert.AreEqual("a.png", coll[0].ImageUrl);
			Assert.AreEqual("c.png", coll[2].ImageUrl);
		}

		[TestMethod]
		public void SavingItemsToStateWorksOK()
		{
			//Arrange
			var coll = new ImageItemCollection();
			coll.Add(new ImageItem("a.gif"));
			coll.Add(new ImageItem("b.gif"));
			coll.Add(new ImageItem("c.gif"));

			//Act
			string[] state = ((IStateManager)coll).SaveViewState() as string[];

			//Assert
			Assert.IsNotNull(state);
			Assert.AreEqual(3, state.Length);
			Assert.AreEqual("a.gif", state[0]);
			Assert.AreEqual("c.gif", state[2]);
		}

		[TestMethod]
		public void TrackingChangesWorksOK()
		{
			//Arrange
			var coll = new ImageItemCollection();

			//Act
			((IStateManager)coll).TrackViewState();

			//Assert
			Assert.AreEqual(true, ((IStateManager)coll).IsTrackingViewState);
		}

		#endregion
	}
}
