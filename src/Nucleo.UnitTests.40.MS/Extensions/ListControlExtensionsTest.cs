using System;
using System.Web.UI.WebControls;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Extensions
{
	[TestClass]
	public class ListControlExtensionsTest
	{
		#region " Tests "

		[TestMethod]
		public void BindingDataWithArrayBindsItemsToListAndDefault()
		{
			var ddl = new DropDownList { DataTextField = "Name", DataValueField = "ID" };

			ddl.BindData(new[]
			{
				new { ID = 1, Name = "A" },
				new { ID = 2, Name = "B" }
			}, true);

			Assert.AreEqual(3, ddl.Items.Count);
			Assert.AreEqual("Any", ddl.Items[0].Text);
			Assert.AreEqual("", ddl.Items[0].Value);
		}

		[TestMethod]
		public void BindingDataWithNullBindsNullToListAndDefault()
		{
			var ddl = new DropDownList { DataTextField = "Name", DataValueField = "ID" };

			ddl.BindData(null, true);

			Assert.AreEqual(1, ddl.Items.Count);
			Assert.AreEqual("Any", ddl.Items[0].Text);
			Assert.AreEqual("", ddl.Items[0].Value);
		}

		[TestMethod]
		public void FindingItemsByLambdaWorksOK()
		{
			//Arrange
			var ddl = new DropDownList();
			ddl.Items.Add(new ListItem("1", "A") { Selected = true });
			ddl.Items.Add(new ListItem("2", "B") { Selected = false });
			ddl.Items.Add(new ListItem("3", "C") { Selected = true });
			ddl.Items.Add(new ListItem("4", "D") { Selected = false });

			//Act
			var items = ddl.FindItemsWith(i => i.Selected == true);

			//Assert
			Assert.AreEqual(2, items.Count);
		}

		[TestMethod]
		public void GettingEmptyGuidKeyReturnsEmpty()
		{
			//Arrange
			var ddl = new DropDownList();
			ddl.Items.Add(new ListItem("A", ""));

			//Act
			var output = ddl.GetSelectedGuidValue();

			//Assert
			Assert.AreEqual(output.ToString(), Guid.Empty.ToString());
		}

		[TestMethod]
		public void GettingEmptyNullableGuidKeyReturnsNull()
		{
			//Arrange
			var ddl = new DropDownList();
			ddl.Items.Add(new ListItem("A", ""));

			//Act
			var output = ddl.GetSelectedGuidValueOrNull();

			//Assert
			Assert.AreEqual(null, output);
		}

		[TestMethod]
		public void GettingEmptyIntegerKeyReturnsEmpty()
		{
			//Arrange
			var ddl = new DropDownList();
			ddl.Items.Add(new ListItem("A", ""));

			//Act
			var output = ddl.GetSelectedKeyValue();

			//Assert
			Assert.AreEqual(output, default(int));
		}

		[TestMethod]
		public void GettingEmptyNullableIntegerKeyReturnsNull()
		{
			//Arrange
			var ddl = new DropDownList();
			ddl.Items.Add(new ListItem("A", ""));

			//Act
			var output = ddl.GetSelectedKeyValueOrNull();

			//Assert
			Assert.IsNull(output);
		}

		[TestMethod]
		public void GettingInvalidGuidReturnsEmpty()
		{
			//Arrange
			var guid = Guid.NewGuid();
			var ddl = new DropDownList();
			ddl.Items.Add(new ListItem("A", guid.ToString() + "INVALID"));

			//Act
			var output = ddl.GetSelectedGuidValue();

			//Assert
			Assert.AreEqual(output.ToString(), Guid.Empty.ToString());
		}

		[TestMethod]
		public void GettingInvalidNullableGuidReturnsNull()
		{
			//Arrange
			var guid = Guid.NewGuid();
			var ddl = new DropDownList();
			ddl.Items.Add(new ListItem("A", guid.ToString() + "INVALID"));

			//Act
			var output = ddl.GetSelectedGuidValueOrNull();

			//Assert
			Assert.IsNull(output);
		}

		[TestMethod]
		public void GettingInvalidKeyReturnsEmpty()
		{
			//Arrange
			var key = 0;
			var ddl = new DropDownList();
			ddl.Items.Add(new ListItem("A", "1INVALID"));

			//Act
			var output = ddl.GetSelectedKeyValue();

			//Assert
			Assert.AreEqual(output, default(int));
		}

		[TestMethod]
		public void GettingInvalidNullableKeyReturnsNull()
		{
			//Arrange
			var key = 0;
			var ddl = new DropDownList();
			ddl.Items.Add(new ListItem("A", "1INVALID"));

			//Act
			var output = ddl.GetSelectedKeyValueOrNull();

			//Assert
			Assert.IsNull(output);
		}

		[TestMethod]
		public void GettingValidGuidWorksOK()
		{
			//Arrange
			var guid = Guid.NewGuid();
			var ddl = new DropDownList();
			ddl.Items.Add(new ListItem("A", guid.ToString()));

			//Act
			var output = ddl.GetSelectedGuidValue();

			//Assert
			Assert.AreEqual(output.ToString(), guid.ToString());
		}

		[TestMethod]
		public void GettingValidNullableGuidReturnsValidGuid()
		{
			//Arrange
			var guid = Guid.NewGuid();
			var ddl = new DropDownList();
			ddl.Items.Add(new ListItem("A", guid.ToString()));

			//Act
			var output = ddl.GetSelectedGuidValueOrNull();

			//Assert
			Assert.AreEqual(output.ToString(), guid.ToString());
		}

		[TestMethod]
		public void GettingValidKeyReturnsValidKey()
		{
			//Arrange
			var ddl = new DropDownList();
			ddl.Items.Add(new ListItem("A", "123"));

			//Act
			var output = ddl.GetSelectedKeyValue();

			//Assert
			Assert.AreEqual(123, output);
		}

		[TestMethod]
		public void GettingValidNullableKeyReturnsValidKey()
		{
			//Arrange
			var ddl = new DropDownList();
			ddl.Items.Add(new ListItem("A", "456"));

			//Act
			var output = ddl.GetSelectedKeyValueOrNull();

			//Assert
			Assert.AreEqual(456, output);
		}

		[TestMethod]
		public void SelectingAllOfTheItemsWorksOK()
		{
			//Arrange
			var ddl = new DropDownList();
			ddl.Items.Add(new ListItem("1", "A") { Selected = true });
			ddl.Items.Add(new ListItem("2", "B") { Selected = false });
			ddl.Items.Add(new ListItem("3", "C") { Selected = true });
			ddl.Items.Add(new ListItem("4", "D") { Selected = false });

			//Act
			ddl.SelectAll();

			//Assert
			Assert.AreEqual(true, ddl.Items[0].Selected);
			Assert.AreEqual(true, ddl.Items[1].Selected);
			Assert.AreEqual(true, ddl.Items[2].Selected);
			Assert.AreEqual(true, ddl.Items[3].Selected);
		}

		[TestMethod]
		public void SelectingItemsMatchingBeginningTextWorksOK()
		{
			//Arrange
			var ddl = new DropDownList();
			ddl.Items.Add(new ListItem("T1", "A") { Selected = false });
			ddl.Items.Add(new ListItem("F2", "B") { Selected = false });
			ddl.Items.Add(new ListItem("T3", "C") { Selected = false });
			ddl.Items.Add(new ListItem("F4", "D") { Selected = false });

			//Act
			ddl.SelectItemsWith("T", PartialTextLocation.Beginning);

			//Assert
			Assert.AreEqual(true, ddl.Items[0].Selected);
			Assert.AreEqual(true, ddl.Items[2].Selected);
			Assert.AreEqual(false, ddl.Items[1].Selected);
			Assert.AreEqual(false, ddl.Items[3].Selected);
		}

		[TestMethod]
		public void SelectingItemsMatchingContainingTextWorksOK()
		{
			//Arrange
			var ddl = new DropDownList();
			ddl.Items.Add(new ListItem("1T3", "A") { Selected = false });
			ddl.Items.Add(new ListItem("2F2", "B") { Selected = false });
			ddl.Items.Add(new ListItem("3T1", "C") { Selected = false });
			ddl.Items.Add(new ListItem("4F0", "D") { Selected = false });

			//Act
			ddl.SelectItemsWith("T", PartialTextLocation.Containing);

			//Assert
			Assert.AreEqual(true, ddl.Items[0].Selected);
			Assert.AreEqual(true, ddl.Items[2].Selected);
			Assert.AreEqual(false, ddl.Items[1].Selected);
			Assert.AreEqual(false, ddl.Items[3].Selected);
		}

		[TestMethod]
		public void SelectingItemsMatchingEndingTextWorksOK()
		{
			//Arrange
			var ddl = new DropDownList();
			ddl.Items.Add(new ListItem("1T", "A") { Selected = false });
			ddl.Items.Add(new ListItem("2F", "B") { Selected = false });
			ddl.Items.Add(new ListItem("3T", "C") { Selected = false });
			ddl.Items.Add(new ListItem("4F", "D") { Selected = false });

			//Act
			ddl.SelectItemsWith("T", PartialTextLocation.Ending);

			//Assert
			Assert.AreEqual(true, ddl.Items[0].Selected);
			Assert.AreEqual(true, ddl.Items[2].Selected);
			Assert.AreEqual(false, ddl.Items[1].Selected);
			Assert.AreEqual(false, ddl.Items[3].Selected);
		}

		[TestMethod]
		public void UnselectingAllOfTheItemsWorksOK()
		{
			//Arrange
			var ddl = new DropDownList();
			ddl.Items.Add(new ListItem("1", "A") { Selected = true });
			ddl.Items.Add(new ListItem("2", "B") { Selected = false });
			ddl.Items.Add(new ListItem("3", "C") { Selected = true });
			ddl.Items.Add(new ListItem("4", "D") { Selected = false });

			//Act
			ddl.UnselectAll();

			//Assert
			Assert.AreEqual(false, ddl.Items[0].Selected);
			Assert.AreEqual(false, ddl.Items[1].Selected);
			Assert.AreEqual(false, ddl.Items[2].Selected);
			Assert.AreEqual(false, ddl.Items[3].Selected);
		}

		#endregion
	}
}
