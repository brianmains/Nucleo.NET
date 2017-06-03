using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Web.Searching
{
	[TestClass]
	public class WebControlSearcherTest
	{
		#region " Tests "

		[TestMethod]
		public void FindingControlsByTypeRecursivelySearchingUpWorksOK()
		{
			//Arrange
			var p = new Panel { ID = "panel" };
			p.Controls.Add(new Label { ID = "label" });
			p.Controls.Add(new TextBox { ID = "text" });
			p.Controls.Add(new Label { ID = "label3" });
			p.Controls.Add(new TextBox { ID = "text3" });

			var p2 = new Panel { ID = "panel2" };
			p2.Controls.Add(new Label { ID = "label2" });
			p2.Controls.Add(new TextBox { ID = "text2" });
			p.Controls.Add(p2);

			var search = new WebControlSearcher();

			//Act
			var ctls = search.FindControls<Label>(p2, ControlSearcherDirection.Up);

			//Assert
			Assert.IsNotNull(ctls);
			Assert.AreEqual(3, ctls.Length);
		}

		[TestMethod]
		public void FindingControlsByTypeWorksOK()
		{
			//Arrange
			var p = new Panel { ID = "panel" };
			p.Controls.Add(new Label { ID = "label" });
			p.Controls.Add(new TextBox { ID = "text" });
			p.Controls.Add(new Label { ID = "label3" });
			p.Controls.Add(new TextBox { ID = "text3" });

			var search = new WebControlSearcher();

			//Act
			var ctls = search.FindControls<Label>(p);

			//Assert
			Assert.IsNotNull(ctls);
			Assert.AreEqual(2, ctls.Length);
		}

		[TestMethod]
		public void FindingControlsInlineWorkOK()
		{
			//Arrange
			var p = Isolate.Fake.Instance<Panel>();
			Isolate.WhenCalled(() => p.ID).WillReturn("panel");

			var label = new Label { ID = "label" };
			var text = new TextBox { ID = "text" };
			p.Controls.Add(label);
			p.Controls.Add(text);

			Isolate.WhenCalled(() => p.FindControl("text")).WillReturn(text);

			var search = new WebControlSearcher();

			//Act
			var ctl = search.FindControl(p, "text");

			//Assert
			Assert.IsInstanceOfType(ctl, typeof(TextBox));
			Assert.AreEqual("text", ctl.ID);
		}

		[TestMethod]
		public void FindingControlsRecursivelyUpWorkOK()
		{
			//Arrange
			var targetLabel = new Label { ID = "label" };
			var p = new Panel { ID = "panel" };
			p.Controls.Add(targetLabel);
			p.Controls.Add(new TextBox { ID = "text" });

			var p2 = new Panel() { ID = "panel2" };
			p2.Controls.Add(new Label { ID = "label2" });
			p2.Controls.Add(new TextBox { ID = "text2" });
			p.Controls.Add(p2);

			Isolate.WhenCalled(() => p2.FindControl("label")).WithExactArguments().WillReturn(null);
			Isolate.WhenCalled(() => p.FindControl("label")).WithExactArguments().WillReturn(targetLabel);

			var search = new WebControlSearcher();

			//Act
			var ctl = search.FindControl(p2, "label", ControlSearcherDirection.Up);

			//Assert
			Assert.AreEqual(targetLabel, ctl);
		}

		[TestMethod]
		public void FindingMultipleParentsWorksOK()
		{
			//Arrange
			var p = new Panel { ID = "panel" };
			p.Controls.Add(new Label { ID = "label" });
			p.Controls.Add(new TextBox { ID = "text" });
			p.Controls.Add(new Label { ID = "label3" });
			p.Controls.Add(new TextBox { ID = "text3" });

			var p2 = new Panel { ID = "panel2" };
			p2.Controls.Add(new Label { ID = "label2" });
			p2.Controls.Add(new TextBox { ID = "text2" });
			p.Controls.Add(p2);

			var p3 = new Panel { ID = "panel4" };
			p3.Controls.Add(new Label { ID = "label4" });
			p3.Controls.Add(new TextBox { ID = "text4" });
			p2.Controls.Add(p3);

			var search = new WebControlSearcher();

			//Act
			var ctls = search.FindParents<Panel>(p3);

			//Assert
			Assert.IsNotNull(ctls);
			Assert.AreEqual(2, ctls.Length);
		}

		[TestMethod]
		public void FindingSingleParentWorksOK()
		{
			//Arrange
			var p = new Panel { ID = "panel" };
			p.Controls.Add(new Label { ID = "label" });
			p.Controls.Add(new TextBox { ID = "text" });
			p.Controls.Add(new Label { ID = "label3" });
			p.Controls.Add(new TextBox { ID = "text3" });

			var p2 = new Panel { ID = "panel2" };
			p2.Controls.Add(new Label { ID = "label2" });
			p2.Controls.Add(new TextBox { ID = "text2" });
			p.Controls.Add(p2);

			var search = new WebControlSearcher();

			//Act
			var ctl = search.FindParent<Panel>(p2);

			//Assert
			Assert.IsNotNull(ctl);
			Assert.AreEqual(p.ID, ctl.ID);
		}

		#endregion
	}
}
