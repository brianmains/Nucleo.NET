using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Web.Scripts
{
	[TestClass]
	public class DynamicScriptCollectionTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingScriptReturnsNull()
		{
			//Arrange
			var scripts = new DynamicScriptCollection
			{
				new DynamicScript { Name = "A", Path = "test.js" },
				new DynamicScript { Name = "B", Path = "test2.js" }
			};

			//Act
			var script = scripts.GetByName("C");

			//Assert
			Assert.IsNull(script);
		}

		[TestMethod]
		public void GettingScriptWorksOK()
		{
			//Arrange
			var scripts = new DynamicScriptCollection
			{
				new DynamicScript { Name = "A", Path = "test.js" },
				new DynamicScript { Name = "B", Path = "test2.js" }
			};

			//Act
			var script = scripts.GetByName("A");

			//Assert
			Assert.AreEqual("test.js", script.Path);
		}

		#endregion
	}
}
