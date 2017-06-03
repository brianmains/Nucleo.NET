using System;
using System.Web.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Web.Scripts
{
	[TestClass]
	public class DynamicScriptLoaderTest
	{
		#region " Test Classes "

		protected class FakeDynamicScriptLoader : DynamicScriptLoader
		{
			protected override string GetScriptRegistration(DynamicScript script)
			{
				return script.Name + ":" + script.Path;
			}
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void RegisteringScriptsWorksOK()
		{
			//Arrange
			var control = new FakeDynamicScriptLoader
			{
				Scripts = new DynamicScriptCollection
				{
					new DynamicScript { Name = "A", Path = "test.js" },
					new DynamicScript { Name = "B", Path = "test2.js" }
				}
			};

			var writer = new StringControlWriter();

			//Act
			((IRenderableControl)control).RenderUI(writer);

			//Assert
			var content = writer.ToString();
			StringAssert.Contains(content, "<script type='text/javascript'");

			foreach (var script in control.Scripts)
				StringAssert.Contains(content, script.Name + ":" + script.Path);
		}

		#endregion
	}
}
