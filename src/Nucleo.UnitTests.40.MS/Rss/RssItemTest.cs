using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Rss
{
	[TestClass]
	public class RssItemTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingItemWithComplexConstructorWorksOK()
		{
			//Arrange
			var item = default(RssItem);

			//Act
			item = new RssItem("Author", "Title", "Link", "Description", DateTime.Today, "Category", "Source", "Comments");

			//Assert
			Assert.AreEqual("Author", item.Author);
			Assert.AreEqual("Title", item.Title);
			Assert.AreEqual("Link", item.Link);
			Assert.AreEqual("Description", item.Description);
			Assert.AreEqual(DateTime.Today, item.PublishedDate);
			Assert.AreEqual("Category", item.Category);
			Assert.AreEqual("Comments", item.Comments);
			Assert.AreEqual("Source", item.Source);
		}

		[TestMethod]
		public void CreatingItemWithSimpleConstructorWorksOK()
		{
			//Arrange
			var item = default(RssItem);

			//Act
			item = new RssItem("Author", "Title", "Link", "Description", DateTime.Today);

			//Assert
			Assert.AreEqual("Author", item.Author);
			Assert.AreEqual("Title", item.Title);
			Assert.AreEqual("Link", item.Link);
			Assert.AreEqual("Description", item.Description);
			Assert.AreEqual(DateTime.Today, item.PublishedDate);
		}

		#endregion
	}
}
