using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Logs
{
	[TestClass]
	public class LoggerOptionsTest
	{
		[TestMethod]
		public void GettingAndSettingLoggerOptionsWorksOK()
		{
			//Arrange
			

			//Act
			var options = new LoggerOptions
			{
				
				CustomMessageTypes = new LogMessageTypeCollection(),
				CustomVerbosityTypes = new LogVerbosityTypeCollection()
			};

			//Assert

		}
	}
}
