using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Reflection;


namespace Nucleo.Web.Mvc
{
	[TestClass]
	public class BaseMvcControlBuilderTest : BaseMvcControlBuilder<BaseMvcControlBuilderTest.TestControl, BaseMvcControlBuilderTest>
	{
		#region " Test Classes "

		public class TestControl : BaseAjaxControl
		{

		}

		#endregion



		#region " Constructors "

		public BaseMvcControlBuilderTest() 
			: base(null) { }

		public BaseMvcControlBuilderTest(NucleoControlFactory cf)
			: base(cf) { }

		#endregion



		#region " Methods "

		protected override string RenderCssFiles(CssReferenceCollection cssFiles)
		{
			return base.RenderCssFiles(cssFiles);
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void ChangingRenderingMode()
		{
			//Arrange
			var factoryFake = Isolate.Fake.Instance<NucleoControlFactory>();
			var builder = new BaseMvcControlBuilderTest(factoryFake);

			//Act
			builder.RenderingMode(RenderMode.ServerOnly);

			//Assert
			Assert.AreEqual(RenderMode.ServerOnly, builder.GetControl().RenderingMode);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CreatingControlBuilderAssignsLocally()
		{
			//Arrange
			var factoryFake = Isolate.Fake.Instance<NucleoControlFactory>();
			var builder = new BaseMvcControlBuilderTest(factoryFake);

			//Act
			bool controlIsNull = (typeof(BaseMvcControlBuilder<BaseMvcControlBuilderTest.TestControl, BaseMvcControlBuilderTest>).GetProperty("Control", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(builder, null) == null);
			builder.GetControl();

			//Assert
			Assert.AreEqual(true, controlIsNull);
			Assert.AreEqual(true, (typeof(BaseMvcControlBuilder<BaseMvcControlBuilderTest.TestControl, BaseMvcControlBuilderTest>).GetProperty("Control", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(builder, null) != null));

			Isolate.CleanUp();
		}

		[TestMethod]
		public void DisablingControlsChangesEnabledProperty()
		{
			//Arrange
			var factoryFake = Isolate.Fake.Instance<NucleoControlFactory>();
			var builder = new BaseMvcControlBuilderTest(factoryFake);

			//Act
			builder.Disable();

			//Assert
			Assert.AreEqual(false, builder.GetControl().Enabled);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void EnablingControlsChangesEnabledProperty()
		{
			//Arrange
			var factoryFake = Isolate.Fake.Instance<NucleoControlFactory>();
			var builder = new BaseMvcControlBuilderTest(factoryFake);

			//Act
			builder.Enable();

			//Assert
			Assert.AreEqual(true, builder.GetControl().Enabled);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void RenderingCssReturnsCorrectText()
		{
			//Arrange
			var factoryFake = Isolate.Fake.Instance<NucleoControlFactory>();
			var builder = new BaseMvcControlBuilderTest(factoryFake);

			//Act
			builder.RenderCss();

			//Assert

			Isolate.CleanUp();
		}

		#endregion
	}
}
