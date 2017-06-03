using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Web.Tags.Custom
{
	[TestClass]
	public class TableTagBuilderTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingEmptyTableCreatesCorrectHtml()
		{
			//Arrange
			TableTagBuilder builder = null;

			//Act
			builder = TableTagBuilder.Create();
			var element = builder.ToElement();

			//Assert
			Assert.AreEqual("<TABLE><THEAD></THEAD><TBODY></TBODY></TABLE>", element.ToHtmlString());
		}

		[TestMethod]
		public void CreatingTableWithOneColumnAndOneRowWithHeaderCreatesCorrectHtml()
		{
			//Arrange
			TableTagBuilder builder = null;

			//Act
			builder = TableTagBuilder.Create(1, 1, true);
			var element = builder.ToElement();

			//Assert
			Assert.AreEqual("<TABLE><THEAD><TR><TH></TH></TR></THEAD><TBODY><TR><TD></TD></TR></TBODY></TABLE>", element.ToHtmlString());
		}

		[TestMethod]
		public void CreatingTableWithOneColumnAndOneRowWithoutHeaderCreatesCorrectHtml()
		{
			//Arrange
			TableTagBuilder builder = null;

			//Act
			builder = TableTagBuilder.Create(1, 1, false);
			var element = builder.ToElement();

			//Assert
			Assert.AreEqual("<TABLE><THEAD></THEAD><TBODY><TR><TD></TD></TR></TBODY></TABLE>", element.ToHtmlString());
		}

		#endregion
	}
}
