using System;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock;

using Nucleo.Collections;


namespace Nucleo.Web.Repeating
{
	[TestClass]
	public class LayoutStructureTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingRowWithForItemsAddsCorrectly()
		{
			List<LayoutItem> items = new List<LayoutItem>();

			LayoutItem item = new LayoutItem();
			items.Add(item);
			item.Controls.Add(new Label
			                  	{
			                  		ID = "lbl1",
			                  		Text = "First Test"
			                  	});
			item = new LayoutItem();
			items.Add(item);
			item.Controls.Add(new Label
			                  	{
			                  		ID = "lbl2",
			                  		Text = "Second Test"
			                  	});
			item = new LayoutItem();
			items.Add(item);
			item.Controls.Add(new Label
			                  	{
			                  		ID = "lbl3",
			                  		Text = "Third Test"
			                  	});
			item = new LayoutItem();
			items.Add(item);
			item.Controls.Add(new Label
			                  	{
			                  		ID = "lbl4",
			                  		Text = "Fourth Test"
			                  	});

			LayoutStructure structure = new LayoutStructure();
			structure.AppendRow(items.ToArray());
			Assert.AreEqual(1, structure.RowCount);
			Assert.IsNotNull(structure.GetRow(0));
			Assert.AreEqual(4, structure.GetRow(0).Items.Count);
		}

		[TestMethod]
		public void GettingRowsWorksCorrectly()
		{
			SimpleCollection<LayoutRow> rows = new SimpleCollection<LayoutRow>();
			LayoutRow mockRow = new LayoutRow();
			mockRow.Items.Add(new LayoutItem());
			rows.Add(mockRow);

			mockRow = new LayoutRow();
			mockRow.Items.Add(new LayoutItem());
			mockRow.Items.Add(new LayoutItem());
			rows.Add(mockRow);

			mockRow = new LayoutRow();
			mockRow.Items.Add(new LayoutItem());
			mockRow.Items.Add(new LayoutItem());
			mockRow.Items.Add(new LayoutItem());
			rows.Add(mockRow);

			mockRow = new LayoutRow();
			mockRow.Items.Add(new LayoutItem());
			mockRow.Items.Add(new LayoutItem());
			mockRow.Items.Add(new LayoutItem());
			mockRow.Items.Add(new LayoutItem());
			rows.Add(mockRow);

			Mock mock = MockManager.Mock(typeof (LayoutStructure));
			mock.ExpectUnmockedConstructor();
			mock.ExpectGetAlways("Rows", rows);

			LayoutStructure structure = new LayoutStructure();
			LayoutRow row = structure.GetRow(0);
			Assert.IsNotNull(row);
			Assert.AreEqual(1, row.Items.Count);

			row = structure.GetRow(1);
			Assert.IsNotNull(row);
			Assert.AreEqual(2, row.Items.Count);

			row = structure.GetRow(2);
			Assert.IsNotNull(row);
			Assert.AreEqual(3, row.Items.Count);

			row = structure.GetRow(3);
			Assert.IsNotNull(row);
			Assert.AreEqual(4, row.Items.Count);

			mock.Verify();
		}

		#endregion
	}
}