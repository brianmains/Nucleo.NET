using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Exceptions;
using Nucleo.TestingTools;


namespace Nucleo.Web
{
	[TestClass]
	public class ScriptComponentTest
	{
		#region " Test Class "

		protected class TestClass : IScriptComponent
		{
			#region IScriptComponent Members

			public void RegisterAjaxDescriptors(IContentRegistrar registrar, IDescriptor currentDescriptor)
			{
				
			}

			public void RegisterAjaxReferences(IContentRegistrar registrar)
			{
				
			}

			#endregion
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void CreatingScriptComponentAssignsReferencesCorrectly()
		{
			var cls = new TestClass();
			var prop = "Property";

			var component = new ScriptComponent(cls, prop);
			Assert.AreEqual(cls, component.ComponentInstance, "Component instances don't match");
			Assert.AreEqual(prop, component.ClientPropertyName, "Client property name doesn't match");
		}

		[TestMethod]
		public void CreatingScriptComponentWithNullComponentValueThrowsException()
		{
			ExceptionTester.CheckException(true, (src) => { new ScriptComponent(null, "Test"); });
		}

		#endregion
	}
}
