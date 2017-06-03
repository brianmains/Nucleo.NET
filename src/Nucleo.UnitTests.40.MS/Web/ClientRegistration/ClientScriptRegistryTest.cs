using System;
using System.Web.UI;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Web.ClientRegistration
{
	[TestClass]
	public class ClientScriptRegistryTest
	{
		#region " Test Classes "

		protected class TestScriptMetadata : WebScriptMetadata
		{
			public override ScriptReferencingRequestDetailsCollection GetPrimaryScripts()
			{
				var list = new ScriptReferencingRequestDetailsCollection();

#if DEBUG
				list.Add(new ScriptReferencingRequestDetails("metadata.debug.js", ScriptMode.Debug));
#else
				list.Add(new ScriptReferencingRequestDetails("metadata.js", ScriptMode.Release));
#endif

				return list;
			}
		}

		[
		ClientScript("Test1.debug.js", "Nucleo.UnitTests", ScriptModes.Debug),
		ClientScript("Test2.debug.js", "Nucleo.UnitTests", ScriptModes.Debug),
		ClientScript("Test1.js", "Nucleo.UnitTests", ScriptModes.Release),
		ClientScript("Test2.js", "Nucleo.UnitTests", ScriptModes.Release)
		]
		protected class TestScriptControl { }

		[WebScriptMetadata(typeof(TestScriptMetadata))]
		protected class TestScriptMetadataControl { }

		#endregion



		#region " Tests "

		[TestMethod]
		public void GettingScriptsForClassMetadataWorksOK()
		{
			//Arrange
			var cls = new TestScriptMetadataControl();
			var registry = ClientScriptRegistry.CreateFor(cls);

			//Act
			Assert.AreEqual(1, registry.Scripts.Count);

			//Assert
			Assert.AreEqual("metadata", registry.Scripts[0].Path.Substring(0, 8));
		}

		[TestMethod]
		public void GettingScriptsForClassWorksOK()
		{
			//Arrange
			var cls = new TestScriptControl();
			var registry = ClientScriptRegistry.CreateFor(cls);

			//Act
			Assert.AreEqual(2, registry.Scripts.Count);

			//Assert
			var scriptNames = registry.Scripts.Select(i => i.Type.Substring(0, 5));
			Assert.IsTrue(scriptNames.Contains("Test1"));
			Assert.IsTrue(scriptNames.Contains("Test2"));
		}

		#endregion
	}
}
