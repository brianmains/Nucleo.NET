using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Context;
using Nucleo.Context.Services;
using Nucleo.Logs;


namespace Nucleo.Web.Context
{
	public partial class LoggingServiceFirstLook : Nucleo.Framework.TestPage
	{
		protected void btnLog_Click(object sender, EventArgs e)
		{
			ApplicationContext context = ApplicationContext.GetCurrent();
			var service = context.GetService<ILoggerService>();

			service.LogMessage(this.txtMessage.Text, this.txtSource.Text,
				service.GetMessageTypes().GetHighest(),
				service.GetVerbosityTypes().GetHighest());
				
		}
	}
}
