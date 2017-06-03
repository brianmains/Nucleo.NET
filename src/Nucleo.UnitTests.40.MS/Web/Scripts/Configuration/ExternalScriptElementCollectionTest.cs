using System;
using System.Web.UI;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Web.Scripts.Configuration
{
	[TestClass]
	public class ExternalScriptElementCollectionTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingScriptByKeyReturnsFirstInstance()
		{
			//Arrange
			var collectionFake = Isolate.Fake.Instance<ExternalScriptElementCollection>(Members.CallOriginal);
			collectionFake.AddRange(new []
				{
					new ExternalScriptElement("First", "PathDebug", "PathRelease"),
					new ExternalScriptElement("Second", "Assem", "TypeDebug", "TypeRelease")
				});

			//Act
			var result = collectionFake.GetScript("First");

			//Assert
			Assert.IsNotNull(result, "Result is null");
			Assert.AreEqual("PathDebug", result.DebugPath);
			Assert.AreEqual("PathRelease", result.ReleasePath);

			Isolate.CleanUp();
		}

		#endregion
	}
}
