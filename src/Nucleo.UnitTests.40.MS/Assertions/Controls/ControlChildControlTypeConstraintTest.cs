using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Nucleo.TestingTools;


namespace Nucleo.Assertions.Controls
{
	[TestClass]
	public class ControlChildControlTypeConstraintTest
	{
		#region " Tests "

		[Test]
		public void MatchingLiteralControlWorksOK()
		{
			//Arrange
			var control = new Panel();
			control.Controls.Add(new LiteralControl("Test"));
			control.Controls.Add(new LiteralControl("That"));
			control.Controls.Add(new LiteralControl("This"));
			control.Controls.Add(new LiteralControl("Works"));

			var constraint = new ControlChildControlTypeConstraint<LiteralControl>();

			//Act
			bool matches = constraint.Matches(control);

			//Assert
			Assert.IsTrue(matches, "Constraint doesn't match");
		}

		[Test]
		public void MatchingNullThrowsException()
		{
			//Arrange
			var constraint = new ControlChildControlTypeConstraint<LiteralControl>();

			//Act/Assert
			NUnitExceptionTester.CheckException(true, (src) => { constraint.Matches((object)null); });
		}

		#endregion
	}
}

