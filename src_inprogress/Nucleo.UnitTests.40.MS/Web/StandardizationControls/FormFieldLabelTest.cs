using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Web.StandardizationControls
{
	[TestClass]
	public class FormFieldLabelTest
	{
		[TestMethod]
		public void GettingAndSettingPropsWorksOK()
		{
			var label = new FormFieldLabel();

			label.AssociatedControlID = "X";
			label.ImageUrl = "Y";
			label.IncludeColonAtEnd = true;
			label.Text = "Z";

			Assert.AreEqual("X", label.AssociatedControlID);
			Assert.AreEqual("Y", label.ImageUrl);
			Assert.AreEqual("Z", label.Text);
			Assert.AreEqual(true, label.IncludeColonAtEnd);
		}

		[TestMethod]
		public void GettingEmptyTextReturnsNull()
		{
			var label = new FormFieldLabel();

			label.Text = string.Empty;

			Assert.AreEqual(null, label.GetText());
		}

		[TestMethod]
		public void GettingNullTextReturnsNull()
		{
			var label = new FormFieldLabel();

			label.Text = null;

			Assert.AreEqual(null, label.GetText());
		}

		[TestMethod]
		public void GettingValidTextReturnsNull()
		{
			var label = new FormFieldLabel();

			label.Text = "XY";

			Assert.AreEqual("XY", label.GetText());
		}

		[TestMethod]
		public void IncludingColonWithExistingColonTextDoesntAddAnything()
		{
			var label = new FormFieldLabel { IncludeColonAtEnd = true };

			label.Text = "XY:";

			Assert.AreEqual("XY:", label.GetText());
		}

		[TestMethod]
		public void IncludingColonWithMissingColonTextAddsToIt()
		{
			var label = new FormFieldLabel { IncludeColonAtEnd = true };

			label.Text = "XY";

			Assert.AreEqual("XY:", label.GetText());
		}
	}
}
