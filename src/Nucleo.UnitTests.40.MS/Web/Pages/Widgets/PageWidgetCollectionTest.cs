using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Web.Pages.Widgets
{
	[TestClass]
	public class PageWidgetCollectionTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingCollectionWithEmptyCtorWorksOK()
		{
			//Arrange
			

			//Act
			var coll = new PageWidgetCollection();

			//Assert
			Assert.AreEqual(0, coll.Count);
		}

		[TestMethod]
		public void CreatingCollectionWithEnumerableCtorWorksOK()
		{
			//Arrange
			var widgets = new List<PageWidget>
			{
				Isolate.Fake.Instance<PageWidget>(),
				Isolate.Fake.Instance<PageWidget>()
			};

			//Act
			var coll = new PageWidgetCollection(widgets);

			//Assert
			Assert.AreEqual(2, coll.Count);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CreatingCollectionWithSingleCtorWorksOK()
		{
			//Arrange
			var widget = Isolate.Fake.Instance<PageWidget>();

			//Act
			var coll = new PageWidgetCollection(widget);

			//Assert
			Assert.AreEqual(1, coll.Count);

			Isolate.CleanUp();
		}

		#endregion
	}
}
