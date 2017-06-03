using System;
using System.Web.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Web.Templates
{
	[TestClass]
	public class ControlElementTemplateTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingEmptyTemplateAssignsNull()
		{
			//Arrange
			

			//Act
			var template = new ControlElementTemplate();

			//Assert
			Assert.IsNull(template.Template);
		}

		[TestMethod]
		public void CreatingTemplateAssignsToTemplateProperty()
		{
			//Arrange
			var temp = Isolate.Fake.Instance<ITemplate>();

			//Act
			var template = new ControlElementTemplate(temp);

			//Assert
			Assert.IsNotNull(template.Template);
		}

		[TestMethod]
		public void GettingTemplateReturnsWHenTemplateAssigned()
		{
			//Arrange
			var temp = Isolate.Fake.Instance<ITemplate>();

			//Act
			var template = new ControlElementTemplate();
			template.Template = temp;

			//Assert
			Assert.IsNotNull(template.GetTemplate());
		}

		#endregion
	}
}
