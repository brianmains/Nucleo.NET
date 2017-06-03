using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Extensions
{
	[TestClass]
	public class TypeExtensionsTest
	{
		#region " Tests "

		[TestMethod]
		public void InstantiatingATypeWithGenericsWorksOK()
		{
			//Arrange
			var type = typeof(TypeExtensionsTest);

			//Act
			var instance = type.Instantiate<TypeExtensionsTest>();

			//Assert
			Assert.IsNotNull(instance);
		}

		[TestMethod]
		public void InstantiatingATypeWorksOK()
		{
			//Arrange
			var type = typeof(TypeExtensionsTest);

			//Act
			var instance = type.Instantiate();

			//Assert
			Assert.IsInstanceOfType(instance, typeof(TypeExtensionsTest));
		}

		#endregion
	}
}
