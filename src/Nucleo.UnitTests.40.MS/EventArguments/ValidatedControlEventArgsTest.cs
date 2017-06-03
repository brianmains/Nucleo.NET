using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.EventArguments
{
	[TestClass]
	public class ValidatedControlEventArgsTest
	{
		[TestMethod]
		public void CreatingWithControlAssignsOK()
		{
			//Arrange
			var ctl = Isolate.Fake.Instance<Control>();

			//Act
			var args = new ValidatedControlEventArgs(ctl);

			//Assert
			Assert.AreEqual(ctl, args.Control);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingAndSettingPropertiesWorksOK()
		{
			//Arrange
			var args = Isolate.Fake.Instance<ValidatedControlEventArgs>(Members.CallOriginal, ConstructorWillBe.Ignored);

			//Act
			args.Value = 123;

			//Assert
			Assert.AreEqual(123, args.Value);

			Isolate.CleanUp();
		}
	}
}
