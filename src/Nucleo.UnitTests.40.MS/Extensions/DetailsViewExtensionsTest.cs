using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;
using System.Web.UI.WebControls;


namespace Nucleo.Extensions
{
	[TestClass]
	public class DetailsViewExtensionsTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingFieldWithGenericReturnsCorrectValue()
		{
			//Arrange
			var view = new DetailsView();
			view.Fields.Add(new BoundField { HeaderText = "1" });
			view.Fields.Add(new BoundField { HeaderText = "2" });
			view.Fields.Add(new BoundField { HeaderText = "3" });
			view.Fields.Add(new CommandField { HeaderText = "4" });

			//Act
			var field1 = view.GetColumn<BoundField>("1");
			var field2 = view.GetColumn<BoundField>("3");
			var field4 = view.GetColumn<CommandField>("4");

			//Assert
			Assert.IsNotNull(field1);
			Assert.IsNotNull(field2);
			Assert.IsNotNull(field4);
		}

		[TestMethod]
		public void GettingFieldWithoutGenericReturnsCorrectValue()
		{
			//Arrange
			var view = new DetailsView();
			view.Fields.Add(new BoundField { HeaderText = "1" });
			view.Fields.Add(new BoundField { HeaderText = "2" });
			view.Fields.Add(new BoundField { HeaderText = "3" });
			view.Fields.Add(new CommandField { HeaderText = "4" });

			//Act
			var field1 = view.GetColumn("1");
			var field2 = view.GetColumn("3");
			var field4 = view.GetColumn("4");

			//Assert
			Assert.IsNotNull(field1);
			Assert.IsInstanceOfType(field1, typeof(BoundField));

			Assert.IsNotNull(field2);
			Assert.IsInstanceOfType(field2, typeof(BoundField));

			Assert.IsNotNull(field4);
			Assert.IsInstanceOfType(field4, typeof(CommandField));
		}

		[TestMethod]
		public void GettingMissingFieldWithGenericReturnsCorrectValue()
		{
			//Arrange
			var view = new DetailsView();
			view.Fields.Add(new BoundField { HeaderText = "1" });
			view.Fields.Add(new BoundField { HeaderText = "2" });

			//Act
			var field = view.GetColumn<BoundField>("5");

			//Assert
			Assert.IsNull(field);
		}

		[TestMethod]
		public void GettingMissingFieldWithoutGenericReturnsCorrectValue()
		{
			//Arrange
			var view = new DetailsView();
			view.Fields.Add(new BoundField { HeaderText = "1" });
			view.Fields.Add(new BoundField { HeaderText = "2" });

			//Act
			var field = view.GetColumn("5");

			//Assert
			Assert.IsNull(field);
		}

		#endregion
	}
}

