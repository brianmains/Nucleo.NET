using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Web.ValidationControls.Items
{
	[TestClass]
	public class BaseValidationDisplayItemTest
	{
		#region " Test Classes "

		protected class TestItem : BaseValidationDisplayItem 
		{
			protected override string GetCssClassName()
			{
				return "Test";
			}

			public override void RenderContent(BaseControlWriter writer)
			{
				
			}
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void GettingDefaultContentWorksOK()
		{
			//Arrange
			var writer = new StringControlWriter();
			var displayItem = new TestItem();

			//Act
			displayItem.RenderUI(writer);
			var output = writer.ToString();

			//Assert
			Assert.AreEqual("<li class='Test'></li>", output);
		}

		#endregion
	}
}
