using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Web
{
	[TestClass]
	public class NucleoServiceReferenceTest
	{
		#region " Tests "

		[TestMethod]
		public void ConvertingToScriptReferenceWorksOK()
		{
			//Arrange
			var service = new NucleoServiceReference
			{
				Path = "p.js",
				InlineScript = true,
				InclusionOptions = ServiceReferenceIncludeOptions.UserUnauthenticated
			};

			//Act
			var output = service.ToServiceReference();

			//Assert
			Assert.AreEqual("p.js", output.Path);
			Assert.AreEqual(true, output.InlineScript);
		}

		[TestMethod]
		public void CreatingReferenceWithPathAssignsOK()
		{
			//Arrange
			
			//Act
			var service = new NucleoServiceReference("path.js");

			//Assert
			Assert.AreEqual("path.js", service.Path);
		}

		[TestMethod]
		public void GettingAndSettingPropsWorksOK()
		{
			//Arrange
			var service = new NucleoServiceReference();

			//Act
			service.InclusionOptions = ServiceReferenceIncludeOptions.UserAuthenticated;

			//Assert
			Assert.AreEqual(ServiceReferenceIncludeOptions.UserAuthenticated, service.InclusionOptions);
		}

		#endregion
	}
}
