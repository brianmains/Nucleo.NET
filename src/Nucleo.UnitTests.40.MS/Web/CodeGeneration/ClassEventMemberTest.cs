using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Web.CodeGeneration
{
	[TestClass]
	public class ClassEventMemberTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingAndSettingPropertiesWorksOK()
		{
			//Arrange

			//Act
			var member = new ClassEventMember
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
			var member = new ClassEventMember();

			//Act

			//Assert
			Assert.AreEqual(ClassMemberType.Event, member.Type);
		}

		#endregion
	}
}
