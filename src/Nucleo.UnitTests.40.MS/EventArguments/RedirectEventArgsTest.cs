using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.EventArguments
{
	[TestClass]
	public class RedirectEventArgsTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingEventArgsWithRedirectWorksOK()
		{
			//Arrange
			var args = default(RedirectEventArgs);

			//Act
			args = new RedirectEventArgs("default.aspx", true);

			//Assert
			Assert.AreEqual("default.aspx", args.NavigateUrl);
			Assert.AreEqual(true, args.CancelRedirect);
		}

		[TestMethod]
		public void CreatingEventArgsWorksOK()
		{
			//Arrange
			var args = default(RedirectEventArgs);

			//Act
			args = new RedirectEventArgs("default.aspx");

			//Assert
			Assert.AreEqual("default.aspx", args.NavigateUrl);
			Assert.AreEqual(false, args.CancelRedirect);
		}

		[TestMethod]
		public void GettingAndSettingPropertiesWorksOK()
		{
			//Arrange
			var args = new RedirectEventArgs("a.aspx");

			//Act
			args.CancelRedirect = true;
			args.NavigateUrl = "default.aspx";

			//Assert
			Assert.AreEqual("default.aspx", args.NavigateUrl);
			Assert.AreEqual(true, args.CancelRedirect);
		}

		#endregion
	}
}
