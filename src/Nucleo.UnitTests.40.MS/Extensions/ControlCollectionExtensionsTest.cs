using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Nucleo.Collections;
using Nucleo.TestingTools;


namespace Nucleo.Extensions
{
	[TestClass]
	public class ControlCollectionExtensionsTest
	{
		#region " Tests "

		[TestMethod]
		public void AddingControlsInBulkInArrayListWorksOK()
		{
			//Arrange
			var root = new Panel();
			var ctl = new ControlCollection(root);

			//Act
			var t1 = new TextBox();
			var t2 = new TextBox();
			var l1 = new Label();
			var l2 = new Label();
			ctl.AddRange(t1, t2, l1, l2);

			//Assert
			Assert.AreEqual(4, ctl.Count);
			Assert.AreEqual(t1, ctl[0]);
			Assert.AreEqual(l2, ctl[3]);
		}

		[TestMethod]
		public void AddingControlsInBulkWorksOK()
		{
			//Arrange
			var root = new Panel();
			var ctl = new ControlCollection(root);

			//Act
			var t1 = new TextBox();
			var t2 = new TextBox();
			var l1 = new Label();
			var l2 = new Label();

			var list = (new Control[] { t1, t2, l1, l2 }).AsEnumerable();
			ctl.AddRange(list);

			//Assert
			Assert.AreEqual(4, ctl.Count);
			Assert.AreEqual(t1, ctl[0]);
			Assert.AreEqual(l2, ctl[3]);
		}

		[TestMethod]
		public void HidingAllControlsWorksOK()
		{
			//Arrange
			var root = new Panel();
			root.Controls.Add(new TextBox());
			root.Controls.Add(new TextBox());
			root.Controls.Add(new TextBox());
			root.Controls.Add(new TextBox());

			//Act
			root.Controls.HideAll();

			//Assert
			Assert.AreEqual(true, root.Controls.Cast<Control>().IsAllTrue(i => i.Visible == false));
		}

		[TestMethod]
		public void SettingVisibilityToFalseWorksOK()
		{
			//Arrange
			var root = new Panel();
			root.Controls.Add(new TextBox());
			root.Controls.Add(new TextBox());
			root.Controls.Add(new TextBox());
			root.Controls.Add(new TextBox());

			//Act
			root.Controls.SetAllVisibility(false);

			//Assert
			Assert.AreEqual(true, root.Controls.Cast<Control>().IsAllTrue(i => i.Visible == false));
		}

		[TestMethod]
		public void SettingVisibilityToTrueWorksOK()
		{
			//Arrange
			var root = new Panel();
			root.Controls.Add(new TextBox());
			root.Controls.Add(new TextBox());
			root.Controls.Add(new TextBox());
			root.Controls.Add(new TextBox());

			//Act
			root.Controls.SetAllVisibility(true);

			//Assert
			Assert.AreEqual(true, root.Controls.Cast<Control>().IsAllTrue(i => i.Visible == true));
		}

		[TestMethod]
		public void ShowingAllControlsWorksOK()
		{
			//Arrange
			var root = new Panel();
			root.Controls.Add(new TextBox());
			root.Controls.Add(new TextBox());
			root.Controls.Add(new TextBox());
			root.Controls.Add(new TextBox());

			//Act
			root.Controls.ShowAll();

			//Assert
			Assert.AreEqual(true, root.Controls.Cast<Control>().IsAllTrue(i => i.Visible == true));
		}

		[TestMethod]
		public void TogglingVisibilityWorksOK()
		{
			//Arrange
			var root = new Panel();
			root.Controls.Add(new TextBox { Visible = false });
			root.Controls.Add(new TextBox { Visible = true });
			root.Controls.Add(new TextBox { Visible = false });
			root.Controls.Add(new TextBox { Visible = true });

			//Act
			root.Controls.ToggleAllVisibility();

			//Assert
			Assert.AreEqual(true, root.Controls[0].Visible);
			Assert.AreEqual(false, root.Controls[1].Visible);
			Assert.AreEqual(true, root.Controls[2].Visible);
			Assert.AreEqual(false, root.Controls[3].Visible);
		}

		#endregion
	}
}

