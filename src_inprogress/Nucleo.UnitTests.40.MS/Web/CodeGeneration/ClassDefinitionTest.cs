using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Web.CodeGeneration
{
	[TestClass]
	public class ClassDefinitionTest
	{
		[TestMethod]
		public void CheckingForEmptyMembersReturnsTrue()
		{
			//Arrange
			

			//Act
			var def = new ClassDefinition();

			//Assert
			Assert.IsFalse(def.HasMembers());
		}

		[TestMethod]
		public void CheckingForSomeMembersReturnsTrue()
		{
			//Arrange
			var def = new ClassDefinition();

			//Act
			def.Methods.Add(new ClassMethodMember());

			//Assert
			Assert.IsTrue(def.HasMembers());
		}
	}
}
