using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Web;
using Nucleo.Web.Description;


namespace Nucleo.Extensions
{
	[TestClass]
	public class IAjaxScriptableComponentExtensionsTest
	{
		[TestMethod]
		public void CreatingWithClientTypeReturnsCorrectDescriptor()
		{
			//Arrange
			var component = Isolate.Fake.Instance<IAjaxScriptableComponent>();

			var reg = Isolate.Fake.Instance<ContentRegistrar>();
			Isolate.WhenCalled(() => reg.AddComponentDescriptor(null)).CallOriginal();

			//Act
			var desc = component.CreateComponentDescriptor("Type", reg);

			//Assert
			Assert.IsNotNull(desc);
			Assert.IsNotNull(desc.ClientType);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CreatingWithComponentsTypeReturnsCorrectDescriptor()
		{
			//Arrange
			var component = Isolate.Fake.Instance<IAjaxScriptableComponent>();


			var reg = Isolate.Fake.Instance<IContentRegistrar>();
				
			//Act
			var desc = component.CreateComponentDescriptor(reg);

			//Assert
			Assert.IsNotNull(desc);
			Assert.IsNotNull(desc.ClientType);

			Isolate.CleanUp();
		}
	}
}
