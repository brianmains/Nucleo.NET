using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Presentation
{
	[TestClass]
	public class PresenterBindingAttributeTest
	{
		#region " Test Classes "

		public class TestClassPresenter { }

		#endregion



		#region " Tests "

		[TestMethod]
		public void CreatingTheBindingWithTypeNameWorksOK()
		{
			//Arrange
			string typeName = typeof(TestClassPresenter).AssemblyQualifiedName;

			//Act
			var binding = new PresenterBindingAttribute(typeName);

			//Assert
			Assert.AreEqual(typeName, binding.PresenterTypeName);
		}

		[TestMethod]
		public void CreatingTheBindingWithTypeWorksOK()
		{
			//Arrange
			

			//Act
			var binding = new PresenterBindingAttribute(typeof(TestClassPresenter));

			//Assert
			Assert.AreEqual(typeof(TestClassPresenter), binding.PresenterType);
		}

		[TestMethod]
		public void GettingPresenterTypeWithTypeNamePassedInReturns()
		{
			//Arrange
			string typeName = typeof(TestClassPresenter).AssemblyQualifiedName;
			var binding = new PresenterBindingAttribute(typeName);

			//Act
			var type = binding.GetPresenterType();

			//Assert
			Assert.AreEqual(typeof(TestClassPresenter), type);
		}

		[TestMethod]
		public void GettingPresenterTypeWithTypePassedInReturns()
		{
			//Arrange
			var binding = new PresenterBindingAttribute(typeof(TestClassPresenter));

			//Act
			var type = binding.GetPresenterType();

			//Assert
			Assert.AreEqual(typeof(TestClassPresenter), type);
		}

		#endregion
	}
}
