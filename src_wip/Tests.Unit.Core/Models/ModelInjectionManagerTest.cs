using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Models
{
	[TestClass]
	public class ModelInjectionManagerTest
	{
		#region " Test Classes "

		protected class TestBinder : IModelInjection { }

		#endregion


		#region " Tests "

		[TestMethod]
		public void AddingBindingsWorksOK()
		{
			//Arrange
			var test = new TestBinder();
			var binder = new ModelInjectionManager();
			var loader = Isolate.Fake.Instance<IModelDataLoader>();
			Isolate.WhenCalled(() => loader.SupportsInjection(null)).WillReturn(true);

			//Act
			binder.RegisterBinding(loader);

			//Assert
			Assert.AreEqual(loader, binder.GetBinding(test));
		}

		[TestMethod]
		public void GettingAndSettingPropsWorksOK()
		{
			//Arrange
			var binder = new ModelInjectionManager();
			var inspector = Isolate.Fake.Instance<IModelInspector>();

			//Act
			binder.Inspector = inspector;

			//Assert
			Assert.AreEqual(inspector, binder.Inspector);
		}

		#endregion
	}
}