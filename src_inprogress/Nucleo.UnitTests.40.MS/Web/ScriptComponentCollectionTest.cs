using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Web
{
	[TestClass]
	public class ScriptComponentCollectionTest
	{
		[TestMethod]
		public void CreatingCollectionWorksOK()
		{
			//Arrange
			var comp = Isolate.Fake.Instance<IScriptComponent>();

			//Act
			var list = new ScriptComponentCollection(new IScriptComponent[] { comp });

			//Assert
			Assert.AreEqual(1, list.Count);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void RegisteringDescriptorsRegistersForChildren()
		{
			//Arrange
			var comp = Isolate.Fake.Instance<IScriptComponent>();
			Isolate.WhenCalled(() => comp.RegisterAjaxDescriptors(null, null)).IgnoreCall();

			var reg = Isolate.Fake.Instance<IContentRegistrar>();
			var desc = Isolate.Fake.Instance<IDescriptor>();
			var list = new ScriptComponentCollection(new IScriptComponent[] { comp });

			//Act
			list.RegisterScriptComponentDescriptors(reg, desc);

			//Assert

			Isolate.Verify.WasCalledWithExactArguments(() => comp.RegisterAjaxDescriptors(reg, desc));

			Isolate.CleanUp();
		}

		[TestMethod]
		public void RegisteringReferencesRegistersForChildren()
		{
			//Arrange
			var comp = Isolate.Fake.Instance<IScriptComponent>();
			Isolate.WhenCalled(() => comp.RegisterAjaxReferences(null)).IgnoreCall();

			var reg = Isolate.Fake.Instance<IContentRegistrar>();
			var list = new ScriptComponentCollection(new IScriptComponent[] { comp });

			//Act
			list.RegisterScriptComponentReferences(reg);

			//Assert

			Isolate.Verify.WasCalledWithExactArguments(() => comp.RegisterAjaxReferences(reg));

			Isolate.CleanUp();
		}

		[TestMethod]
		public void RemovingItemsFromCollectionWorksOK()
		{
			//Arrange
			var comp = Isolate.Fake.Instance<IScriptComponent>();
			var list = new ScriptComponentCollection(new IScriptComponent[] { comp });

			//Act
			list.Remove(comp);

			//Assert
			Assert.AreEqual(0, list.Count);

			Isolate.CleanUp();
		}
	}
}
