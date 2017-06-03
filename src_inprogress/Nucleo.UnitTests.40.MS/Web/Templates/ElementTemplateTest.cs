using System;
using System.Reflection;
using System.Web.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Web.Templates
{
	[TestClass]
	public class ElementTemplateTest
	{
		#region " Methods "

		[TestMethod]
		public void CreatingElementTemplateAssignsClientSidePropertyName()
		{
			//Arrange
			var template = default(ElementTemplate);
			var nameDetails = Isolate.Fake.Instance<ClientPropertyNamingDetails>();
			Isolate.WhenCalled(() => nameDetails.ClientPropertyName).WillReturn("testProp");

			//Act
			template = new ElementTemplate(nameDetails);

			//Assert
			Assert.AreEqual(nameDetails, template.NameDetails);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingClientTemplateReturnsClientTemplateWhenClientTemplateIsNotNull()
		{
			//Arrange
			var clientTemplateFake = Isolate.Fake.Instance<IElementTemplate>();
			var serverTemplateFake = Isolate.Fake.Instance<IElementTemplate>();

			var templateFake = Isolate.Fake.Instance<ElementTemplate>(Members.CallOriginal);

			//Act
			templateFake.ClientTemplate = clientTemplateFake;
			templateFake.ServerTemplate = serverTemplateFake;
			templateFake.ClientTemplateEvaluator = ClientTemplateEvaluation.Prototype;

			//Assert
			Assert.AreEqual(clientTemplateFake, templateFake.GetClientTemplate(), "Template isnt' client template");

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingClientTemplateReturnsServerTemplateWhenClientTemplateIsNull()
		{
			//Arrange
			var serverTemplateFake = Isolate.Fake.Instance<IElementTemplate>();
			var templateFake = Isolate.Fake.Instance<ElementTemplate>(Members.CallOriginal);

			//Act
			templateFake.ServerTemplate = serverTemplateFake;
			templateFake.ClientTemplate = null;

			//Assert
			Assert.AreEqual(serverTemplateFake, templateFake.GetClientTemplate(), "Client template isn't server template");

			Isolate.CleanUp();
		}

		[TestMethod]
		public void ReadingAndWritingToTemplatesAssignsCorrectly()
		{
			//Arrange
			var clientTemplateFake = Isolate.Fake.Instance<IElementTemplate>();
			var serverTemplateFake = Isolate.Fake.Instance<IElementTemplate>();

			var templateFake = Isolate.Fake.Instance<ElementTemplate>(Members.CallOriginal);

			//Act
			templateFake.ClientTemplate = clientTemplateFake;
			templateFake.ServerTemplate = serverTemplateFake;
			templateFake.ClientTemplateEvaluator = ClientTemplateEvaluation.Prototype;

			//Assert
			Assert.AreEqual(clientTemplateFake, templateFake.ClientTemplate);
			Assert.AreEqual(serverTemplateFake, templateFake.ServerTemplate);
			Assert.AreEqual(ClientTemplateEvaluation.Prototype, templateFake.ClientTemplateEvaluator);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void RegisteringDescriptorAddsPropertyReferenceToTemplate()
		{
			//Arrange
			var templateFake = Isolate.Fake.Instance<ElementTemplate>(Members.CallOriginal);
			Isolate.WhenCalled(() => templateFake.NameDetails).WillReturn(new ClientPropertyNamingDetails("testProp"));
			Isolate.WhenCalled(() => templateFake.ServerTemplate).WillReturn(new FakeElementTemplate("Test", true));

			var registrarFake = Isolate.Fake.Instance<IContentRegistrar>();

			var fakeDescriptor = new FakeDescriptor();

			//Act
			((IScriptComponent)templateFake).RegisterAjaxDescriptors(registrarFake, fakeDescriptor);

			//Assert
			Assert.IsNotNull(fakeDescriptor.References["testProp"]);

			Isolate.CleanUp();
		}

		#endregion
	}
}
