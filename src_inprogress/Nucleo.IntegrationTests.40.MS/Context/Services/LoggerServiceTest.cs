using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Nucleo.Logs;


namespace Nucleo.Context.Services
{
	[TestClass]
	public class LoggerServiceTest
	{
		#region " Tests "

		[TestMethod]
		public void LoggingErrorMessagesAsNormalVerbosityWorksOK()
		{
			//Arrange
			var context = ApplicationContext.GetCurrent();

			//Act
			var logger = context.GetService<ILoggerService>();
			logger.LogError(new Exception("An error occurred"), "Test",
				logger.GetMessageTypes().GetByEnum(CommonLogMessageTypes.Error),
				logger.GetVerbosityTypes().GetByEnum(CommonLogVerbosityTypes.Normal));

			//Assert
		}

		#endregion
	}
}
