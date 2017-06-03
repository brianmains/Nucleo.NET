using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Web
{
	[TestClass]
	public class ControlReferenceTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingReferenceWorksOK()
		{
			//Arrange
			var ids = default(ControlReference);

			//Act
			ids = new ControlReference(new Panel());

			//Assert
			Assert.IsInstanceOfType(ids.Reference, typeof(Panel));
		}

		#endregion
	}
}
