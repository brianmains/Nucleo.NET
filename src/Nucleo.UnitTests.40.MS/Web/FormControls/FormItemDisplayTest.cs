using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Web.Templates;


namespace Nucleo.Web.FormControls
{
	[TestClass]
	public class FormItemDisplayTest
	{
		#region " Tests "

		[TestMethod]
		public void ChangingToEditTemplateWorksOK()
		{
			//Arrange
			var ctl = new FormItemDisplay();

			ctl.ReadOnlyTemplate = new ControlElementTemplate(new FakeTemplate("RO"));
			ctl.EditTemplate = new ControlElementTemplate(new FakeTemplate("E"));
			ctl.InsertTemplate = new ControlElementTemplate(new FakeTemplate("I"));

			//Act
			ctl.ChangeView(FormCurrentView.Edit);

			//Assert
			Assert.AreEqual(ctl.CurrentTemplate, ctl.EditTemplate);
		}

		[TestMethod]
		public void ChangingToInsertTemplateWorksOK()
		{
			//Arrange
			var ctl = new FormItemDisplay();

			ctl.ReadOnlyTemplate = new ControlElementTemplate(new FakeTemplate("RO"));
			ctl.EditTemplate = new ControlElementTemplate(new FakeTemplate("E"));
			ctl.InsertTemplate = new ControlElementTemplate(new FakeTemplate("I"));

			//Act
			ctl.ChangeView(FormCurrentView.Insert);

			//Assert
			Assert.AreEqual(ctl.CurrentTemplate, ctl.InsertTemplate);
		}

		[TestMethod]
		public void ChangingToReadOnlyTemplateWorksOK()
		{
			//Arrange
			var ctl = new FormItemDisplay();

			ctl.ReadOnlyTemplate = new ControlElementTemplate(new FakeTemplate("RO"));
			ctl.EditTemplate = new ControlElementTemplate(new FakeTemplate("E"));
			ctl.InsertTemplate = new ControlElementTemplate(new FakeTemplate("I"));

			//Act
			ctl.ChangeView(FormCurrentView.ReadOnly);

			//Assert
			Assert.AreEqual(ctl.CurrentTemplate, ctl.ReadOnlyTemplate);
		}

		[TestMethod]
		public void CurrentEditTemplateMatchesCurrentEditView()
		{
			//Arrange
			var ctl = Isolate.Fake.Instance<FormItemDisplay>(Members.CallOriginal);
			ctl.EditTemplate = new ControlElementTemplate();
			Isolate.WhenCalled(() => ctl.CurrentView).WillReturn(FormCurrentView.Edit);

			//Act
			var template = ctl.CurrentTemplate;

			//Assert
			Assert.AreEqual(ctl.EditTemplate, template);
		}

		[TestMethod]
		public void CurrentInsertTemplateMatchesCurrentInsertView()
		{
			//Arrange
			var ctl = Isolate.Fake.Instance<FormItemDisplay>(Members.CallOriginal);
			ctl.InsertTemplate = new ControlElementTemplate();
			Isolate.WhenCalled(() => ctl.CurrentView).WillReturn(FormCurrentView.Insert);

			//Act
			var template = ctl.CurrentTemplate;

			//Assert
			Assert.AreEqual(ctl.InsertTemplate, template);
		}

		[TestMethod]
		public void GettingAndSettingTemplatesWorksOK()
		{
			//Arrange
			var ctl = new FormItemDisplay();

			//Act
			ctl.ReadOnlyTemplate = new ControlElementTemplate(new FakeTemplate("RO"));
			ctl.EditTemplate = new ControlElementTemplate(new FakeTemplate("E"));
			ctl.InsertTemplate = new ControlElementTemplate(new FakeTemplate("I"));

			//Assert
			Assert.IsNotNull(ctl.ReadOnlyTemplate);
			Assert.IsNotNull(ctl.EditTemplate);
			Assert.IsNotNull(ctl.InsertTemplate);
		}

		#endregion
	}
}
