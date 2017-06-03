using System;
using System.Collections;
using System.Collections.Specialized;
using System.Web.UI.WebControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Extensions
{
	[TestClass]
	public class GridViewExtensionsTest
	{
		#region " Tests "

		[TestMethod]
		public void BindingDataWorksOK()
		{
			var grid = new GridView();
			grid.Columns.Add(new BoundField { HeaderText = "ID", DataField = "ID" });

			grid.BindData(new[]
				{
					new { ID = 1 },
					new { ID = 2 }
				});

			Assert.AreEqual(2, grid.Rows.Count);
		}

		[TestMethod]
		public void GettingDataKeyValuesWorksOK()
		{
			//Arrange
			var grid = Isolate.Fake.Instance<GridView>(Members.CallOriginal);
			Isolate.WhenCalled(() => grid.DataKeys[0]).WillReturn(new DataKey(new OrderedDictionary { { "A", 1 } }));

			var row = Isolate.Fake.Instance<GridViewRow>();
			Isolate.WhenCalled(() => row.DataItemIndex).WillReturn(0);
			Isolate.WhenCalled(() => row.Parent).WillReturn(grid);

			//Act
			var key0 = row.GetDataKeyValues();

			//Assert
			Assert.AreEqual(1, key0.Count);
			Assert.AreEqual(1, key0[0]);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingDataKeyValueWorksOK()
		{
			//Arrange
			var list = new ArrayList();
			list.Add(1);

			var grid = Isolate.Fake.Instance<GridView>(Members.CallOriginal);
			Isolate.WhenCalled(() => grid.DataKeys[0]).WillReturn(new DataKey(new OrderedDictionary { { "A", 1 } }));

			var row = Isolate.Fake.Instance<GridViewRow>();
			Isolate.WhenCalled(() => row.DataItemIndex).WillReturn(0);
			Isolate.WhenCalled(() => row.Parent).WillReturn(grid);
			
			//Act
			var key0 = row.GetDataKeyValue();

			//Assert
			Assert.AreEqual(1, key0);

			Isolate.CleanUp();
		}

		public void GettingFieldWithGenericReturnsCorrectValue()
		{
			//Arrange
			var view = new GridView();
			view.Columns.Add(new BoundField { HeaderText = "1" });
			view.Columns.Add(new BoundField { HeaderText = "2" });
			view.Columns.Add(new BoundField { HeaderText = "3" });
			view.Columns.Add(new CommandField { HeaderText = "4" });

			//Act
			var field1 = view.GetColumn<BoundField>("1");
			var field2 = view.GetColumn<BoundField>("3");
			var field4 = view.GetColumn<CommandField>("4");

			//Assert
			Assert.IsNotNull(field1);
			Assert.IsNotNull(field2);
			Assert.IsNotNull(field4);
		}

		public void GettingFieldWithoutGenericReturnsCorrectValue()
		{
			//Arrange
			var view = new GridView();
			view.Columns.Add(new BoundField { HeaderText = "1" });
			view.Columns.Add(new BoundField { HeaderText = "2" });
			view.Columns.Add(new BoundField { HeaderText = "3" });
			view.Columns.Add(new CommandField { HeaderText = "4" });

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
			Assert.IsInstanceOfType(field4, typeof(BoundField));
		}

		public void GettingMissingFieldWithGenericReturnsCorrectValue()
		{
			//Arrange
			var view = new GridView();
			view.Columns.Add(new BoundField { HeaderText = "1" });
			view.Columns.Add(new BoundField { HeaderText = "2" });

			//Act
			var field = view.GetColumn<BoundField>("5");

			//Assert
			Assert.IsNull(field);
		}

		public void GettingMissingFieldWithoutGenericReturnsCorrectValue()
		{
			//Arrange
			var view = new GridView();
			view.Columns.Add(new BoundField { HeaderText = "1" });
			view.Columns.Add(new BoundField { HeaderText = "2" });

			//Act
			var field = view.GetColumn("5");

			//Assert
			Assert.IsNull(field);
		}

		#endregion
	}
}
