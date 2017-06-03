using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Nucleo.Web.Controls;
using Nucleo.TestingTools;

namespace Nucleo.Web
{
	[TestClass]
	public class ScriptReferencingRequestDetailsTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingScriptReferencingCreatesReferenceByAssemblyAndType()
		{
			var details = new ScriptReferencingRequestDetails("assembly", "type", ScriptMode.Debug);
			Assert.AreEqual("assembly", details.Assembly);
			Assert.AreEqual("type.js", details.Type);
			Assert.AreEqual(ScriptMode.Debug, details.Mode);
		}

		[TestMethod]
		public void CreatingScriptReferencingCreatesReferenceByPath()
		{
			var details = new ScriptReferencingRequestDetails("path", ScriptMode.Release);
			Assert.AreEqual("path.js", details.Path);
			Assert.AreEqual(ScriptMode.Release, details.Mode);
		}

		[TestMethod]
		public void CreatingScriptReferencingFromTypeCreatesProperReferences()
		{
			var details = new ScriptReferencingRequestDetails(typeof(Link), ScriptMode.Debug);
			StringAssert.StartsWith(details.Assembly, "Nucleo.Web");
			Assert.AreEqual(typeof(Link).FullName + ".js", details.Type);
			
		}

		[TestMethod]
		public void MergingTypeInformationMergesTypesCorrectly()
		{
			//Arrange
			var type = typeof(EditorControls.BaseEditorControl);
			var fileName = "Editors";
			var mode = ScriptMode.Debug;

			//Act
			var output = ScriptReferencingRequestDetails.MergeTypeInformation(type, fileName, mode);

			//Assert
			Assert.AreEqual("Nucleo.Web.EditorControls.Editors.debug.js", output);
		}

		[TestMethod]
		public void MergingTypeInformationWithNullFileNameThrowsException()
		{
			ExceptionTester.CheckException(true, (src) =>
			{
				ScriptReferencingRequestDetails.MergeTypeInformation(typeof(EditorControls.BaseEditorControl), null, ScriptMode.Debug);
			});

			ExceptionTester.CheckException(true, (src) =>
			{
				ScriptReferencingRequestDetails.MergeTypeInformation(typeof(EditorControls.BaseEditorControl), "", ScriptMode.Debug);
			});
		}

		[TestMethod]
		public void MergingTypeInformationWithNullTypeThrowsException()
		{
			ExceptionTester.CheckException(true, (src) =>
			{
				ScriptReferencingRequestDetails.MergeTypeInformation(null, "Test", ScriptMode.Debug); 
			});
		}

		#endregion
	}
}
