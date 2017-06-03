using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Web.Templates
{
	[TestClass]
	public class ActionElementTemplateTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingEmptyTemplateAssignsOK()
		{
			//Arrange

			//Act
			var template = new ActionElementTemplate();

			//Assert
			Assert.IsNull(template.Content);
		}

		[TestMethod]
		public void CreatingTemplateAssignsOK()
		{
			//Arrange

			//Act
			var template = new ActionElementTemplate(() => { });

			//Assert
			Assert.IsNotNull(template.Content);
		}

		[TestMethod]
		public void GettingTemplateReturnsNull()
		{
			//Arrange

			//Act
			var template = new ActionElementTemplate(() => {  });

			//Assert
			Assert.IsNull(template.GetTemplate());
		}

		[TestMethod]
		public void InvokingTemplateWorksOK()
		{
			//Arrange
			bool fired = false;

			//Act
			new ActionElementTemplate(() => { fired = true; }).InvokeTemplate();

			//Assert
			Assert.IsTrue(fired);
		}

		#endregion
	}
}
