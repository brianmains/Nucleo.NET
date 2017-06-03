using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Web.Mvc
{
	[TestClass]
	public class BaseMvcComponentBuilderTest
	{
		#region " Test Classes "

		public class TestComponent : BaseMvcComponent
		{
		
		}

		public class TestBuilder : BaseMvcComponentBuilder<TestComponent, TestBuilder>
		{
			public TestBuilder(NucleoControlFactory factory)
				: base(factory) { }
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void CreatingComponentBuilderWorksOK()
		{
			//Arrange
			var component = new TestComponent();
			var factory = Isolate.Fake.Instance<NucleoControlFactory>();

			//Act
			var builder = new TestBuilder(factory);

			//Assert
			Assert.IsNotNull(builder);

			Isolate.CleanUp();
		}

		#endregion
	}
}
