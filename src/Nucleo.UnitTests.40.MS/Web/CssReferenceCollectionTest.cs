using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Web
{
	[TestClass]
	public class CssReferenceCollectionTest : CssReferenceCollection
	{
		#region " Tests "

		[TestMethod]
		public void GettingCssByDetails()
		{
			//Arrange
			var list = new CssReferenceCollectionTest();
			list.Add(new CssReference("scripts.css"));
			list.Add(new CssReference("files.css"));

			//Act
			var css1 = list.GetByDetails(new CssReferenceRequestDetails("files.css"));
			var css2 = list.GetByDetails(new CssReferenceRequestDetails("files2.css"));

			//Assert
			Assert.IsNotNull(css1);
			Assert.IsNull(css2);
		}

		#endregion
	}
}
