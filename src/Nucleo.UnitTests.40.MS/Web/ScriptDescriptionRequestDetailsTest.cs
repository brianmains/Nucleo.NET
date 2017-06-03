using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Web.Controls;


namespace Nucleo.Web
{
	[TestClass]
	public class ScriptDescriptionRequestDetailsTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingScriptDescriptionRequestWithClientTypeParameterAssignsValuesCorrectly()
		{
			var check = Isolate.Fake.Instance<Check>();
			Isolate.WhenCalled(() => check.ClientID).WillReturn("ctl100_Check");

			var details = new ScriptDescriptionRequestDetails(
				check,
				"Nucleo.CheckControl",
				typeof(BaseAjaxControl),
				check.ClientID);
			Assert.AreEqual(check, details.ControlReference);
			Assert.AreEqual("Nucleo.CheckControl", details.ClientType);
			Assert.AreEqual(typeof(BaseAjaxControl), details.RequestObjectType);
			Assert.AreEqual(check.ClientID, details.TargetID);
		}

		[TestMethod]
		public void CreatingScriptDescriptionRequestWithControlParameterAssignsValuesCorrectly()
		{
			var check = Isolate.Fake.Instance<Check>();
			Isolate.WhenCalled(() => check.ClientID).WillReturn("ctl100_Check");

			var details = new ScriptDescriptionRequestDetails(
				check,
				typeof(BaseAjaxControl),
				check.ClientID);
			Assert.AreEqual(check, details.ControlReference);
			Assert.AreEqual(typeof(BaseAjaxControl), details.RequestObjectType);
			Assert.AreEqual("ctl100_Check", details.TargetID);
		}

		[TestMethod]
		public void CreatingScriptDescriptionWithNoClientTypeReturnsControlType()
		{
			var check = Isolate.Fake.Instance<Check>();
			Isolate.WhenCalled(() => check.ClientID).WillReturn("ctl100_Check");

			var details = new ScriptDescriptionRequestDetails(
				check,
				typeof(BaseAjaxControl),
				check.ClientID);
			Assert.AreEqual(typeof(Check).FullName, details.ClientType);
		}

		#endregion
	}
}
