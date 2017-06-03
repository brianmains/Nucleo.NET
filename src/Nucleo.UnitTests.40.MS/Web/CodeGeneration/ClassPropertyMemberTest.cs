using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Web.CodeGeneration
{
	[TestClass]
	public class ClassPropertyMemberTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingAndSettingPropertiesWorksOK()
		{
			//Arrange

			//Act
			var member = new ClassPropertyMember
			{
				Name = "Name"
			};

			//Assert
			Assert.AreEqual("Name", member.Name);
		}

		[TestMethod]
		public void TypeReturnsCorrectly()
		{
			//Arrange
			var member = new ClassPropertyMember();

			//Act

			//Assert
			Assert.AreEqual(ClassMemberType.Property, member.Type);
		}

		#endregion
	}
}
