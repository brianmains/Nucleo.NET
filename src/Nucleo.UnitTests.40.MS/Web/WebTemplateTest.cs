using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Web
{
	[TestClass]
	public class WebTemplateTest : WebTemplate
	{
		#region " Properties "

		public override WebTemplateFormat Format
		{
			get { return WebTemplateFormat.Prototype; }
		}

		#endregion



		#region " Constructors "

		public WebTemplateTest() : base() { }

		public WebTemplateTest(string template) : base(template) { }

		#endregion



		#region " Methods "

		public override string Evaluate(Dictionary<string, object> parameters)
		{
			throw new NotImplementedException();
		}

		protected override void RegisterAjaxDescriptors(IContentRegistrar registrar, IDescriptor currentDescriptor)
		{
			throw new NotImplementedException();
		}

		protected override void RegisterAjaxReferences(IContentRegistrar registrar)
		{
			throw new NotImplementedException();
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void CreatingEmptyTemplateAssignsValues()
		{
			//Arrange/Act
			WebTemplateTest test = new WebTemplateTest();

			//Assert
			Assert.AreEqual(WebTemplateFormat.Prototype, test.Format);
			Assert.IsNull(test.Template);
		}

		[TestMethod]
		public void CreatingTemplateAssignsValues()
		{
			//Arrange/Act
			WebTemplateTest test = new WebTemplateTest("This is my template");

			//Assert
			Assert.AreEqual(WebTemplateFormat.Prototype, test.Format);
			Assert.AreEqual("This is my template", test.Template);
		}

		#endregion
	}
}
