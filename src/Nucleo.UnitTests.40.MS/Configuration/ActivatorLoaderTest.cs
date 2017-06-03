using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Configuration
{
	[TestClass]
	public class ActivatorLoaderTest
	{
		[TestMethod]
		public void LoadTypeWorksOK()
		{
			//Arrange
			var element = new NameTypeElement
			{
				Name = "Test",
				Type = "Nucleo.Configuration.ActivatorLoaderTest," + typeof(ActivatorLoaderTest).Assembly.FullName
			};

			//Act
			var test = ActivatorLoader.LoadType<ActivatorLoaderTest>(element);

			//Assert
			Assert.IsNotNull(test);
		}
	}
}
