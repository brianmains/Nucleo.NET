using System;
using System.Web.UI;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Web.Scripts.Configuration
{
	[TestClass]
	public class ExternalScriptElementTest
	{
		#region " Tests "

		[TestMethod]
		public void AssigningValuesAssignsCorrectly()
		{
			var element = new ExternalScriptElement();
			element.Name = "nm";
			element.DebugType = "dty";
			element.ReleaseType = "rty";
			element.Assembly = "as";
			element.DebugPath = "dpa";
			element.ReleasePath = "rpa";

			Assert.AreEqual("nm", element.Name);
			Assert.AreEqual("dty", element.DebugType);
			Assert.AreEqual("rty", element.ReleaseType);
			Assert.AreEqual("as", element.Assembly);
			Assert.AreEqual("dpa", element.DebugPath);
			Assert.AreEqual("rpa", element.ReleasePath);
		}

		[TestMethod]
		public void CreatingAssemblyAndTypeConstructorAssignsOK()
		{
			//Arrange
			var element = default(ExternalScriptElement);
			
			//Act
			element = new ExternalScriptElement("Test", "Nucleo.dll", "TestScriptDebug", "TestScriptRelease");
			
			//Assert
			Assert.AreEqual("Test", element.Name, "Name doesn't match");
			Assert.AreEqual("TestScriptDebug", element.DebugType, "Debug Type doesn't match");
			Assert.AreEqual("TestScriptRelease", element.ReleaseType, "Release Type doesn't match");
			Assert.AreEqual("Nucleo.dll", element.Assembly, "Assembly doesn't match");
		}

		[TestMethod]
		public void CreatingEmptyConstructorAssignsNull()
		{
			var element = new ExternalScriptElement();
			Assert.IsTrue(string.IsNullOrEmpty(element.Name), "Name isn't null");
			Assert.IsTrue(string.IsNullOrEmpty(element.DebugType), "Type isn't null");
			Assert.IsTrue(string.IsNullOrEmpty(element.ReleaseType), "Type isn't null");
			Assert.IsTrue(string.IsNullOrEmpty(element.DebugPath), "Path isn't null");
			Assert.IsTrue(string.IsNullOrEmpty(element.ReleasePath), "Path isn't null");
			Assert.IsTrue(string.IsNullOrEmpty(element.Assembly), "Assembly isn't null");
		}

		[TestMethod]
		public void CreatingPathConstructorAssignsOK()
		{
			var element = new ExternalScriptElement("Test", "TestScriptDebug.js", "TestScriptRelease.js");
			Assert.AreEqual("Test", element.Name, "Name doesn't match");
			Assert.AreEqual("TestScriptDebug.js", element.DebugPath, "Debug Path doesn't match");
			Assert.AreEqual("TestScriptRelease.js", element.ReleasePath, "Debug Path doesn't match");
		}

		#endregion
	}
}
